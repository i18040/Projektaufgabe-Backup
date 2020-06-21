using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using BCrypt.Net;
using Projektaufgabe_WCF.Framework;

namespace Projektaufgabe_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private static string sDB =
            @"C:\Users\MikeSütö\source\repos\Projektaufgabe Client\Projektaufgabe WCF\Database\FleetManagement.db";
        public Repository<BusinessUnit> mBusinessUnitRepository =
            new Repository<BusinessUnit>(sDB);

        public Repository<Employee> mEmployeeRepository = new Repository<Employee>(sDB);
        public Repository<User> mUserRepository = new Repository<User>(sDB);
        public Repository<Vehicle> mVehicleRepository = new Repository<Vehicle>(sDB);

        public Repository<VehicleToEmployeeRelation> mVehicleToEmployeeRelationRepository =
            new Repository<VehicleToEmployeeRelation>(sDB);

        #region DBReads

        public User LoginUser(string Username, string Password) //TODO UNIT TESTS
        {
            var users = mUserRepository.GetAll();
            var query =
                from user in users
                where string.Equals(user.Username, Username)
                select user;
            if (query.Count() == 1 &&
                query.Select(user => BCrypt.Net.BCrypt.Verify(Password, user.Password)).FirstOrDefault())
            {
                foreach (var user in query)
                {
                    return user;
                }
                return null;
            }
            return null;
        }

        public List<User> GetUsers() => mUserRepository.GetAll();

        public List<BusinessUnit> GetBusinessUnits() => mBusinessUnitRepository.GetAll();

        public List<Employee> GetEmployees() => mEmployeeRepository.GetAll();

        public List<Vehicle> GetVehicles() => mVehicleRepository.GetAll();

        public List<VehicleToEmployeeRelation> GetEmployeesForVehicleTab(string licensePlate)
        {
            var employeeList = new List<VehicleToEmployeeRelation>();
            var VehicleId = getVehicleIdFromLicensePlate(licensePlate);
            var vehicleToEmployeeRelations = mVehicleToEmployeeRelationRepository.GetAll();
            var v2eQuery =
                from v2e in vehicleToEmployeeRelations
                where v2e.VehicleId == VehicleId
                select v2e;
            if (!v2eQuery.Any()) return null;
            var employees = mEmployeeRepository.GetAll();
            foreach (var v2e in v2eQuery)
            {
                var emplId = v2e.EmployeeId;

                var emplQuery =
                    from empl in employees
                    where empl.Id == emplId
                    select empl;
                if (emplQuery.Any())
                {
                    foreach (var empl in emplQuery)
                    {
                        v2e.Fullname = empl.Fullname;
                        employeeList.Add(v2e);
                    }
                }
            }

            return employeeList;
        }

        public List<Employee> GetEmployeesForNewVehicleRelation(string licensePlate)
        {
            var employeeList = new List<Employee>();
            var units = mBusinessUnitRepository.GetAll();
            var vehicleId = getVehicleIdFromLicensePlate(licensePlate);
            var vehicleToEmployeeRelations = mVehicleToEmployeeRelationRepository.GetAll();
            var v2eQuery =
                from v2e in vehicleToEmployeeRelations
                where v2e.VehicleId == vehicleId
                select v2e;
            if (!v2eQuery.Any()) return null;
            var employees = mEmployeeRepository.GetAll();
            foreach (var v2e in v2eQuery)
            {
                var emplId = v2e.EmployeeId;
                var emplQuery =
                    from empl in employees
                    where empl.Id != emplId
                    select empl;
                if (emplQuery.Any())
                {
                    foreach (var empl in emplQuery)
                    {
                        v2e.Fullname = empl.Fullname;
                        var unitQuery =
                            from unit in units
                            where unit.Id == empl.BusinessUnitId
                            select unit;
                        var UnitName = "";
                        foreach (var unit in unitQuery) UnitName = unit.Name;
                        empl.BusinessUnit = UnitName;
                        employeeList.Add(empl);
                    }
                }
            }
            return employeeList;
        }

        public List<MonthlyCost> GetMonthlyCosts()
        {
            var vehicles = mVehicleRepository.GetAll();
            var leasingFromQuery =
                from vcl in vehicles
                group vcl by vcl.LeasingFrom
                into g
                select g.Key;
            var leasingToQuery =
                from vcl in vehicles
                group vcl by vcl.LeasingTo
                into g
                select g.Key;
            var monthlyCosts = new List<MonthlyCost>();
            foreach (var month in leasingToQuery)
            {
                var monthlyCost = new MonthlyCost
                {
                    Month = month
                };
                var countQuery =
                    from vcl in vehicles
                    where vcl.LeasingFrom <= month || vcl.LeasingTo >= month
                    select vcl;
                monthlyCost.Count = 0;
                monthlyCost.Cost = 0;
                foreach (var entry in countQuery)
                {
                    monthlyCost.Count++;
                    monthlyCost.Cost += entry.LeasingRate + entry.Insurance / 12;
                }

                monthlyCosts.Add(monthlyCost);
                foreach (var otherMonth in leasingFromQuery)
                {
                    if (month == otherMonth) continue;
                    var otherMonthlyCost = new MonthlyCost
                    {
                        Month = otherMonth
                    };
                    var otherCountQuery =
                        from vcl in vehicles
                        where vcl.LeasingFrom <= month || vcl.LeasingTo >= month
                        select vcl;
                    monthlyCost.Count = 0;
                    monthlyCost.Cost = 0;
                    foreach (var entry in otherCountQuery)
                    {
                        monthlyCost.Count++;
                        monthlyCost.Cost += entry.LeasingRate;
                        monthlyCost.Cost += entry.Insurance / 12;
                    }

                    monthlyCosts.Add(otherMonthlyCost);
                }
            }

            return monthlyCosts;
        }

        public List<MonthlyBusinessUnitCost> GetMonthlyBusinessUnitCosts()
        {
            var vehicles = mVehicleRepository.GetAll();
            var businessUnits = mBusinessUnitRepository.GetAll();
            var employees = mEmployeeRepository.GetAll();
            var vehicleToEmployees = mVehicleToEmployeeRelationRepository.GetAll();
            var leasingFromQuery =
                from vcl in vehicles
                join vclemp in vehicleToEmployees on vcl.Id equals vclemp.VehicleId
                join emp in employees on vclemp.EmployeeId equals emp.Id
                join bu in businessUnits on emp.BusinessUnitId equals bu.Id
                group vcl by vcl.LeasingFrom
                into g
                select g.Key;
            var leasingToQuery =
                from vcl in vehicles
                group vcl by vcl.LeasingTo
                into g
                select g.Key;
            var monthlyBusinessUnitCosts = new List<MonthlyBusinessUnitCost>();
            foreach (var month in leasingToQuery)
            {
                var monthlyBusinessUnitCost = new MonthlyBusinessUnitCost()
                {
                    Month = month
                };
                var countQuery =
                    from vcl in vehicles
                    where vcl.LeasingFrom <= month || vcl.LeasingTo >= month
                    select vcl;
                monthlyBusinessUnitCost.Cost = 0;
                foreach (var entry in countQuery)
                {
                    monthlyBusinessUnitCost.Cost += entry.LeasingRate + entry.Insurance / 12;
                }

                monthlyBusinessUnitCosts.Add(monthlyBusinessUnitCost);
                foreach (var otherMonth in leasingFromQuery)
                {
                    if (month == otherMonth) continue;
                    var otherMonthlyBusinessUnitCost = new MonthlyBusinessUnitCost()
                    {
                        Month = otherMonth
                    };
                    var otherCountQuery =
                        from vcl in vehicles
                        where vcl.LeasingFrom <= month || vcl.LeasingTo >= month
                        select vcl;
                    monthlyBusinessUnitCost.Cost = 0;
                    foreach (var entry in otherCountQuery)
                    {
                        monthlyBusinessUnitCost.Cost += entry.LeasingRate;
                        monthlyBusinessUnitCost.Cost += entry.Insurance / 12;
                    }

                    monthlyBusinessUnitCosts.Add(otherMonthlyBusinessUnitCost);
                }
            }

            return monthlyBusinessUnitCosts;
        }

        #endregion

        #region DBManipulation

        public bool ChangePassword(string username, string oldPassword, string newPassword) //TODO UNIT TESTS
        {
            var users = mUserRepository.GetAll();
            var query =
                from usr in users
                where string.Equals(usr.Username, username)
                select usr;
            if (query.Count() != 1) return false;
            foreach (var user in query)
            {
                try
                {
                    var newPW = BCrypt.Net.BCrypt.ValidateAndReplacePassword(oldPassword, user.Password, newPassword);
                    user.Password = BCrypt.Net.BCrypt.HashPassword(newPW);
                    mUserRepository.Update(user);
                }
                catch (BcryptAuthenticationException)
                {
                    return false;
                }
            }

            return true;
        }


        #region User

        public User NewUser(string username, string firstname, string lastname,
            bool isAdmin) //TODO Optimistic Locking & UNIT TESTS
        {
            var user = new User
            {
                Username = username, Firstname = firstname, Lastname = lastname,
                Password = BCrypt.Net.BCrypt.HashPassword("geheim"), isAdmin = isAdmin, Version = 1
            };
            var users = mUserRepository.GetAll();
            var query =
                from usr in users
                where string.Equals(usr.Username, username)
                select usr;
            if (query.Count() != 0) return null;
            mUserRepository.Save(user);
            return user;
        }

        public bool DeleteUser(string username) //TODO Optimistic Locking & UNIT TESTS
        {
            var users = mUserRepository.GetAll();
            var query =
                from usr in users
                where string.Equals(usr.Username, username)
                select usr;
            if (query.Count() != 1) return false;
            foreach (var user in query) mUserRepository.Delete(user);
            return true;
        }

        public bool UpdateUser(string username, string newUsername, string firstname, string lastname,
            bool isAdmin) //TODO Optimistic Locking & UNIT TESTS
        {
            var users = mUserRepository.GetAll();
            var query =
                from usr in users
                where string.Equals(usr.Username, username)
                select usr;
            if (query.Count() != 1) return false;
            foreach (var user in query)
            {
                if (username != newUsername)
                    user.Username = newUsername;
                user.Firstname = firstname;
                user.Lastname = lastname;
                user.isAdmin = isAdmin;
                mUserRepository.Update(user);
            }

            return true;
        }

        #endregion

        #region BusinessUnit

        public BusinessUnit NewBusinessUnit(string name, string description) //TODO Optimistic Locking & UNIT TESTS
        {
            var businessUnit = new BusinessUnit {Name = name, Description = description, Version = 1};
            var businessUnits = mBusinessUnitRepository.GetAll();
            var query =
                from unit in businessUnits
                where string.Equals(unit.Name, name)
                select unit;
            if (query.Count() != 0) return null;
            mBusinessUnitRepository.Save(businessUnit);
            return businessUnit;
        }

        public bool DeleteBusinessUnit(string name) //TODO Optimistic Locking & UNIT TESTS
        {
            var businessUnits = mBusinessUnitRepository.GetAll();
            var query =
                from unit in businessUnits
                where string.Equals(unit.Name, name)
                select unit;
            if (query.Count() != 1) return false;
            foreach (var unit in query)
            {
                var employees = mEmployeeRepository.GetAll();
                var emplQuery =
                    from empl in employees
                    where empl.BusinessUnitId == unit.Id
                    select empl;
                if (emplQuery.Count() != 0) return false;
                mBusinessUnitRepository.Delete(unit);
            }

            return true;
        }

        public bool UpdateBusinessUnit(string name, string newName, string description) //TODO Optimistic Locking & UNIT TESTS
        {
            var businessUnits = mBusinessUnitRepository.GetAll();
            var query =
                from unit in businessUnits
                where string.Equals(unit.Name, name)
                select unit;
            if (query.Count() != 1) return false;
            foreach (var unit in query)
            {
                if (name != newName)
                    unit.Name = newName;
                unit.Description = description;
                mBusinessUnitRepository.Update(unit);
            }

            return true;
        }

        #endregion

        #region Employee

        public Employee NewEmployee(string firstname, string lastname, int employeeNumber, string salutation, string title,
            int businessUnitId) //TODO Optimistic Locking & UNIT TESTS
        {
            var employee = new Employee
            {
                Firstname = firstname, Lastname = lastname, EmployeeNumber = employeeNumber, Salutation = salutation,
                Title = title, BusinessUnitId = businessUnitId, Version = 1
            };
            var employees = mEmployeeRepository.GetAll();
            var query =
                from empl in employees
                where empl.EmployeeNumber == employeeNumber
                select empl;
            if (query.Count() != 0) return null;
            mEmployeeRepository.Save(employee);
            return employee;
        }

        public bool DeleteEmployee(int employeeNumber) //TODO Optimistic Locking & UNIT TESTS
        {
            var employees = mEmployeeRepository.GetAll();
            var query =
                from empl in employees
                where empl.EmployeeNumber == employeeNumber
                select empl;
            if (query.Count() != 1) return false;
            foreach (var empl in query)
            {
                var vehicleToEmployee = mVehicleToEmployeeRelationRepository.GetAll();
                var v2eQuery =
                    from v2e in vehicleToEmployee
                    where v2e.EmployeeId == empl.Id
                    select v2e;
                if (v2eQuery.Count() != 0) return false;
                mEmployeeRepository.Delete(empl);
            }

            return true;
        }

        public bool UpdateEmployee(string firstname, string lastname, int employeeNumber, int newEmployeeNumber,
            string salutation, string title, int businessUnitId) //TODO Optimistic Locking & UNIT TESTS
        {
            var employees = mEmployeeRepository.GetAll();
            var query =
                from empl in employees
                where empl.EmployeeNumber == employeeNumber
                select empl;
            if (query.Count() != 1) return false;
            foreach (var empl in query)
            {
                if (employeeNumber != newEmployeeNumber)
                    empl.EmployeeNumber = newEmployeeNumber;
                empl.Firstname = firstname;
                empl.Lastname = lastname;
                empl.Salutation = salutation;
                empl.Title = title;
                empl.BusinessUnitId = businessUnitId;
                mEmployeeRepository.Update(empl);
            }

            return true;
        }

        #endregion

        #region Vehicle

        public Vehicle NewVehicle(string licensePlate, string brand, string model, decimal insurance, DateTime leasingFrom,
            DateTime leasingTo, decimal leasingRate) //TODO Optimistic Locking & UNIT TESTS
        {
            var vehicle = new Vehicle
            {
                LicensePlate = licensePlate, Brand = brand, Model = model, Insurance = insurance,
                LeasingFrom = leasingFrom, LeasingTo = leasingTo, LeasingRate = leasingRate, Version = 1
            };
            var vehicles = mVehicleRepository.GetAll();
            var query =
                from vcl in vehicles
                where string.Equals(vcl.LicensePlate, licensePlate)
                select vcl;
            if (query.Count() != 0) return null;
            mVehicleRepository.Save(vehicle);
            return vehicle;
        }

        public bool DeleteVehicle(string licensePlate) //TODO Optimistic Locking & UNIT TESTS
        {
            var vehicles = mVehicleRepository.GetAll();
            var query =
                from vcl in vehicles
                where string.Equals(vcl.LicensePlate, licensePlate)
                select vcl;
            if (query.Count() != 1) return false;
            foreach (var vcl in query)
            {
                var vehicleToEmployee = mVehicleToEmployeeRelationRepository.GetAll();
                var v2eQuery =
                    from v2e in vehicleToEmployee
                    where v2e.VehicleId == vcl.Id
                    select v2e;
                if (v2eQuery.Count() != 0)
                    foreach (var v2e in v2eQuery)
                        mVehicleToEmployeeRelationRepository.Delete(v2e);
                mVehicleRepository.Delete(vcl);
            }

            return true;
        }

        public bool UpdateVehicle(string licensePlate, string newLicensePlate, string brand, string model,
            decimal insurance, DateTime leasingFrom, DateTime leasingTo,
            decimal leasingRate) //TODO Optimistic Locking & UNIT TESTS
        {
            var vehicles = mVehicleRepository.GetAll();
            var query =
                from vcl in vehicles
                where string.Equals(vcl.LicensePlate, licensePlate)
                select vcl;
            if (query.Count() != 1) return false;
            foreach (var vcl in query)
            {
                if (licensePlate != newLicensePlate)
                    vcl.LicensePlate = newLicensePlate;
                vcl.Brand = brand;
                vcl.Model = model;
                vcl.Insurance = insurance;
                vcl.LeasingFrom = leasingFrom;
                vcl.LeasingTo = leasingTo;
                vcl.LeasingRate = leasingRate;
                mVehicleRepository.Update(vcl);
            }

            return true;
        }

        #endregion

        #region Vehicle2EmployeeRelation

        public VehicleToEmployeeRelation NewVehicle2EmployeeRelation(DateTime startDate, DateTime endDate, string licensePlate,
            int employeeNumber) //TODO Optimistic Locking & UNIT TESTS
        {
            var vehicleId = getVehicleIdFromLicensePlate(licensePlate);
            var employeeId = getEmployeeIdFromEmployeeNumber(employeeNumber);

            var vehicleToEmployeeRelation = new VehicleToEmployeeRelation
                {StartDate = startDate, EndDate = endDate, VehicleId = vehicleId, EmployeeId = employeeId};
            var vehicleToEmployee = mVehicleToEmployeeRelationRepository.GetAll();
            var v2eQuery =
                from v2e in vehicleToEmployee
                where v2e.VehicleId == vehicleId && v2e.EmployeeId == employeeId
                select v2e;
            if (v2eQuery.Count() != 0) return null;
            mVehicleToEmployeeRelationRepository.Save(vehicleToEmployeeRelation);
            return vehicleToEmployeeRelation;
        }

        public bool DeleteVehicle2EmployeeRelation(string licensePlate,
            int employeeId) //TODO Optimistic Locking & UNIT TESTS
        {
            var vehicleId = getVehicleIdFromLicensePlate(licensePlate);

            var vehicleToEmployee = mVehicleToEmployeeRelationRepository.GetAll();
            var v2eQuery =
                from v2e in vehicleToEmployee
                where v2e.VehicleId == vehicleId && v2e.EmployeeId == employeeId
                select v2e;
            if (v2eQuery.Count() != 1) return false;
            foreach (var v2e in v2eQuery) mVehicleToEmployeeRelationRepository.Delete(v2e);
            return true;
        }

        #endregion

        #endregion

        #region Helpers

        private int getVehicleIdFromLicensePlate(string LicensePlate)
        {
            var vehicles = mVehicleRepository.GetAll();
            var vclQuery =
                from vcl in vehicles
                where string.Equals(vcl.LicensePlate, LicensePlate)
                select vcl;
            if (vclQuery.Count() != 1) return -1;
            var VehicleId = -1;
            foreach (var vcl in vclQuery) VehicleId = vcl.Id;

            return VehicleId;
        }

        private int getEmployeeIdFromEmployeeNumber(int EmployeeNumber)
        {
            var employees = mEmployeeRepository.GetAll();
            var emplQuery =
                from empl in employees
                where empl.EmployeeNumber == EmployeeNumber
                select empl;
            if (emplQuery.Count() != 1) return -1;
            var EmployeeId = -1;
            foreach (var empl in emplQuery) EmployeeId = empl.Id;
            return EmployeeId;
        }

        private string getBusinessUnitNameFromId(int BusinessUnitId)
        {
            var units = mBusinessUnitRepository.GetAll();
            var unitQuery =
                from unit in units
                where unit.Id == BusinessUnitId
                select unit;
            if (unitQuery.Count() != 1) return "";
            var UnitName = "";
            foreach (var unit in unitQuery) UnitName = unit.Name;
            return UnitName;
        }

        #endregion
    }
}
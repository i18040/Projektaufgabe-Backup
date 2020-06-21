using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Projektaufgabe_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        User LoginUser(string Username, string Password);

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        List<BusinessUnit> GetBusinessUnits();

        [OperationContract]
        List<Employee> GetEmployees();

        [OperationContract]
        List<Vehicle> GetVehicles();

        [OperationContract]
        List<VehicleToEmployeeRelation> GetEmployeesForVehicleTab(string licensePlate);

        [OperationContract]
        List<Employee> GetEmployeesForNewVehicleRelation(string licensePlate);

        [OperationContract]
        List<MonthlyCost> GetMonthlyCosts();

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        User NewUser(string username, string firstname, string lastname, bool isAdmin);

        [OperationContract]
        bool DeleteUser(string username);

        [OperationContract]
        bool UpdateUser(string username, string newUsername, string firstname, string lastname, bool isAdmin);

        [OperationContract]
        BusinessUnit NewBusinessUnit(string name, string description);

        [OperationContract]
        bool DeleteBusinessUnit(string name);

        [OperationContract]
        bool UpdateBusinessUnit(string name, string newName, string description);

        [OperationContract]
        Employee NewEmployee(string firstname, string lastname, int employeeNumber, string salutation, string title,
            int businessUnitId);

        [OperationContract]
        bool DeleteEmployee(int employeeNumber);

        [OperationContract]
        bool UpdateEmployee(string firstname, string lastname, int employeeNumber, int newEmployeeNumber,
            string salutation, string title, int businessUnitId);

        [OperationContract]
        Vehicle NewVehicle(string licensePlate, string brand, string model, decimal insurance, DateTime leasingFrom,
            DateTime leasingTo, decimal leasingRate);

        [OperationContract]
        bool DeleteVehicle(string licensePlate);

        [OperationContract]
        bool UpdateVehicle(string licensePlate, string newLicensePlate, string brand, string model, decimal insurance,
            DateTime leasingFrom, DateTime leasingTo, decimal leasingRate);

        [OperationContract]
        VehicleToEmployeeRelation NewVehicle2EmployeeRelation(DateTime startDate, DateTime endDate, string licensePlate, int employeeNumber);

        [OperationContract]
        bool DeleteVehicle2EmployeeRelation(string licensePlate, int employeeId);

        // TODO: Add your service operations here
    }
}
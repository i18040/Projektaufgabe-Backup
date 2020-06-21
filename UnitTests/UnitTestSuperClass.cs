using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projektaufgabe;
using Moq;
using Projektaufgabe_WCF;
using Projektaufgabe_WCF.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class UnitTestSuperClass
    {
        private Mock<Service> serviceMock = new Mock<Service>();
        [TestMethod]
        public void LoginWithInvalid()
        {
            serviceMock.Setup(x => x.LoginUser("", "")).Returns((User) null);
            Assert.IsNull(serviceMock.Object.LoginUser("",""));
        }

        public void LoginWithValid()
        {
            serviceMock.Setup(x => x.LoginUser("admin", "admin")).Returns(() => new User());
            Assert.IsNotNull(serviceMock.Object.LoginUser("admin", "admin"));
        }

        public void LoginWithValidUsernameInvalidPassword()
        {
            serviceMock.Setup(x => x.LoginUser("admin", "dawdawwdawdawdawd")).Returns((User) null);
            Assert.IsNull(serviceMock.Object.LoginUser("admin", "dawdawwdawdawdawd"));
        }

        public void ResetPasswordWithInvalidUser()
        {
            serviceMock.Setup(x => x.ChangePassword("ewwrrr", "awdaw", "dawdaweaweawe")).Returns(false);
            Assert.IsFalse(serviceMock.Object.ChangePassword("ewwrrr", "awdaw", "dawdaweaweawe"));
        }

        public void ResetPasswordWithValid()
        {
            serviceMock.Setup(x => x.ChangePassword("admin", "admin", "nichtadmin")).Returns(true);
            Assert.IsTrue(serviceMock.Object.ChangePassword("admin", "admin", "nichtadmin"));
        }

        public void ResetPasswordWithOld()
        {
            serviceMock.Setup(x => x.ChangePassword("admin", "admin", "admin")).Returns(false);
            Assert.IsFalse(serviceMock.Object.ChangePassword("admin", "admin", "admin"));
        }
        public void CreateInvalidUser()
        {
            serviceMock.Setup(x => x.NewUser("admin", null, "admin", true)).Returns((User) null);
            Assert.IsNull(serviceMock.Object.NewUser("admin", null, "admin", true));
        }

        public void CreateValidUser()
        {
            serviceMock.Setup(x => x.NewUser("Schmeeegt", "admin", "nichtadmin", true)).Returns(() => new User());
            Assert.IsNotNull(serviceMock.Object.NewUser("Schmeeegt", "admin", "nichtadmin", true));
        }

        public void CreateNullUser()
        {
            serviceMock.Setup(x => x.NewUser(null, null, null, false)).Returns((User)null);
            Assert.IsNull(serviceMock.Object.NewUser(null, null, null, false));
        }
        public void CreateInvalidBusinessUnit()
        {
            serviceMock.Setup(x => x.NewBusinessUnit("Zirkus", null)).Returns((BusinessUnit)null);
            Assert.IsNull(serviceMock.Object.NewBusinessUnit("Zirkus", null));
        }

        public void CreateValidBusinessUnit()
        {
            serviceMock.Setup(x => x.NewBusinessUnit("Hütte", "Es gitb Hüttenkäse hier.")).Returns(() => new BusinessUnit());
            Assert.IsNotNull(serviceMock.Object.NewBusinessUnit("Hütte", "Es gitb Hüttenkäse hier."));
        }

        public void CreateNullBusinessUnit()
        {
            serviceMock.Setup(x => x.NewBusinessUnit(null, null)).Returns((BusinessUnit)null);
            Assert.IsNull(serviceMock.Object.NewBusinessUnit(null, null));
        }
        public void CreateInvalidEmployee()
        {
            serviceMock.Setup(x => x.NewEmployee("John", null, -2, "divers", "Apache Kampfhelikopter", 69)).Returns((Employee)null);
            Assert.IsNull(serviceMock.Object.NewEmployee("John", null, -2, "divers", "Apache Kampfhelikopter", 69));
        }

        public void CreateValidEmployee()
        {
            serviceMock.Setup(x => x.NewEmployee("John", "CENAAAAAAAAAAA", 1, "divers", "DU DU DU DUUUUUUU", 420)).Returns(() => new Employee());
            Assert.IsNotNull(serviceMock.Object.NewEmployee("John", "CENAAAAAAAAAAA", 1, "divers", "DU DU DU DUUUUUUU", 420));
        }

        public void CreateNullEmployee()
        {
            serviceMock.Setup(x => x.NewEmployee(null, null, 0, null, null, 0)).Returns((Employee)null);
            Assert.IsNull(serviceMock.Object.NewEmployee(null, null, 0, null, null, 0));
        }
        public void CreateInvalidVehicle()
        {
            serviceMock.Setup(x => x.NewVehicle("https://www.youtube.com/watch?v=dQw4w9WgXcQ", null, "laufsteg", 0, DateTime.Now, DateTime.Today, -2)).Returns((Vehicle)null);
            Assert.IsNull(serviceMock.Object.NewVehicle("https://www.youtube.com/watch?v=dQw4w9WgXcQ", null, "laufsteg", 0, DateTime.Now, DateTime.Today, -2));
        }

        public void CreateValidVehicle()
        {
            serviceMock.Setup(x => x.NewVehicle("https://www.youtube.com/watch?v=dQw4w9WgXcQ", "Astley", "Rick", 150, DateTime.Now, DateTime.Today, 330)).Returns(() => new Vehicle());
            Assert.IsNotNull(serviceMock.Object.NewVehicle("https://www.youtube.com/watch?v=dQw4w9WgXcQ", "Astley", "Rick", 150, DateTime.Now, DateTime.Today, 330));
        }

        public void CreateNullVehicle()
        {
            serviceMock.Setup(x => x.NewVehicle(null, null, null, 0, DateTime.Now, DateTime.Now, 0)).Returns((Vehicle)null);
            Assert.IsNull(serviceMock.Object.NewVehicle(null, null, null, 0, DateTime.Now, DateTime.Now, 0));
        }
        public void CreateInvalidVehicle2EmployeeRelation()
        {
            serviceMock.Setup(x => x.NewVehicle2EmployeeRelation(DateTime.Now, new DateTime(2008,8,26), "R16K R011", 0815)).Returns((VehicleToEmployeeRelation)null);
            Assert.IsNull(serviceMock.Object.NewVehicle2EmployeeRelation(DateTime.Now, new DateTime(2008, 8, 26), "R16K R011", 0815));
        }

        public void CreateValidVehicle2EmployeeRelation()
        {
            serviceMock.Setup(x => x.NewVehicle2EmployeeRelation(new DateTime(2008, 8, 26), DateTime.Now, "R16K R011", 1)).Returns(() => new VehicleToEmployeeRelation());
            Assert.IsNotNull(serviceMock.Object.NewVehicle2EmployeeRelation(new DateTime(2008, 8, 26), DateTime.Now, "R16K R011", 1));
        }

        public void CreateNullVehicle2EmployeeRelation()
        {
            serviceMock.Setup(x => x.NewVehicle2EmployeeRelation(DateTime.Now, DateTime.Now, null, 0)).Returns((VehicleToEmployeeRelation)null);
            Assert.IsNull(serviceMock.Object.NewVehicle2EmployeeRelation(DateTime.Now, DateTime.Now, null, 0));
        }
    }
}

using NUnit.Framework;
using Pyvvo.Logistics.Core;
using Pyvvo.Logistics.Model;
using System;
namespace Pyvvo.Logistics.Test
{

    public class SignUpUnitTest
    {
        private readonly ICoreTenant _tenantCore;
        private readonly ICoreDatabaseEntity _databaseEntity;
        private readonly DatabaseContext _context;
 
        public SignUpUnitTest()
        { 
            this._tenantCore = new TenantCore(new DatabaseContext());
            _databaseEntity=new DatabaseEntityCore(new DatabaseContext());
            _context = new DatabaseContext();

        }

        [TestCase]
        public void SignUp()
        {
            var Address = new Model.Address()
            {
                Address1 = "Address 1 - N° et rue",
                Address2 = "Address 2",
                Country = "France",
                Province = "Province",
                Zip = "11111",
            };
            var Contact = new Model.Contact()
            {
                AcceptTermsOfService = true,
                Email = "Tenant_1@mail.com",
                Facebook = "facebook url",
                FirstName = "John",
                LastName = "Doe",
                IsActive = true,
                Language = "Fr",
                Linkedin = "LinkedinUrl",
                Phone = "0707070707",
                Viadeo = "viadeoUrl",
                Website = "websiteUrl",
            };
            Contact.Status.Id = 1;
            var tenant = new Tenant();
            tenant.CreatedOn = DateTime.Now;
            tenant.UpdatedOn = DateTime.Now;
            tenant.IsActive = true;
            tenant.StatusId = 1;
            var isCreated = _tenantCore.Create(tenant).Result;
            Assert.IsTrue(isCreated);

        }
        [TestCase]
        public void DatabaseEntityGet()
        {
             Boolean test =false;
             Console.WriteLine(test);

            // var result = _databaseEntity.Get(1).Result;
            // Assert.IsTrue(result[0].Id == 1);
        }
        [Test]
        public void TenantCreate()
        {
            Boolean test =false;
             Console.WriteLine(test);
            var Contact = new Model.Contact()
            {
                AcceptTermsOfService = true,
                Email = "Tenant_100@mail.com",
                Facebook = "facebook url",
                FirstName = "John",
                LastName = "Doe",
                IsActive = true,
                Language = "Fr",
                Linkedin = "LinkedinUrl",
                Phone = "0707070707",
                Viadeo = "viadeoUrl",
                Website = "websiteUrl",
                StatusId = 3,
                Image = new Model.Image(){
                    CreatedById = 1,
                    CreatedOn = DateTime.Now,
                    PathUrl =""
                }
            };
            var Address = new Model.Address()
            {
                Address1 = "Address 1 - N° et rue",
                Address2 = "Address 2",
                Country = "France",
                Province = "Province",
                Zip = "11111",
                CreatedById = 1
            };
            var Address1 = new Model.Address()
            {
                Address1 = "Address 1 - N° et rue",
                Address2 = "Address 2",
                Country = "France",
                Province = "Province",
                Zip = "11111",
                CreatedById = 1
            };
            Tenant _tenant = new Tenant
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = true,
                StatusId = 3,
                BillingAddress = Address,
                ShippingAddress = Address1,
                Contact = Contact,
                CurrencyId =2
            };

            var isCreated = _tenantCore.Create(_tenant).Result;
            Assert.IsTrue(isCreated);
        }
         [Test]
        public void TenantDelete()
        {
            Boolean result = false;
            try
            {
                 result =  _tenantCore.Delete(7).Result;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Assert.IsTrue(result);

        }
    }
}

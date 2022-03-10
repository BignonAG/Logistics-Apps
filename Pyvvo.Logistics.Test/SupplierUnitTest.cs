// using NUnit.Framework;
// using Pyvvo.Logistics.Core;
// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace Pyvvo.Logistics.Test
// {
//     public class SupplierUnitTest
//     {
//         private SupplierCore core;

//         public SupplierUnitTest()
//         {
//             core = new SupplierCore();
//         }

//         [Test]
//         public void GetSuppliers()
//         {
//             var result = core.GetSuppliers(1).Result;
//             Assert.IsTrue(result.Count > 0);
//         }

//         [Test]
//         public void CreateSupplierTest() {
//             var supplier = new Model.Supplier();
//             var createdBy = new UserCore().GetUser(Convert.ToInt64(1)).Result;
//             var Address = new Model.Address()
//             {
//                 Address1 = "Address 1 - N° et rue",
//                 Address2 = "Address 2",
//                 Country = "France",
//                 Province = "Province",
//                 Zip = "11111",
//             };
//             supplier.Contact = new Model.Contact()
//             {
//                 AcceptTermsOfService = true,
//                 Email = "supplier@mail.com",
//                 Facebook = "facebook url",
//                 FirstName = "John",
//                 LastName = "Doe",
//                 IsActive = true,
//                 Language = "Fr",
//                 Linkedin = "LinkedinUrl",
//                 Phone = "0707070707",
//                 Viadeo = "viadeoUrl",
//                 Website = "websiteUrl",
//                 Status = new Model.Status()
//                 {
//                     Description = "Supplier status",
//                     IsActive = true,
//                     Name = "Verified",
//                     CreateDon = DateTime.Now,
//                     UpdateDon = DateTime.Now,
//                     StatusCategory = new Model.StatusCategory()
//                     {
//                         CreateDon = DateTime.Now,
//                         UpdateDon = DateTime.Now,
//                         Name = "Supplier"
//                     }
//                 }
//             };
//             supplier.RefUser = new Model.User()
//             {
//                 CreateDon = DateTime.Now,
//                 UpdateDon = DateTime.Now
//             };
//             Address.CreatedBy = supplier.RefUser;
//             supplier.CreatedBy = createdBy;
//             supplier.Address = Address;
//             //var result = core.CreateSupplier(supplier,1,3).Result;
//             //Assert.IsTrue(result);
//         }

//         [Test] 
//         public void UpdateSupplierWithId3()
//         {
//             var supplier = core.GetSupplier(3).Result;
//             var result = core.UpdateSupplier(supplier).Result;
//             Assert.IsTrue(result);
//         }

//         [Test]
//         public void DeleteSupplier5()
//         {
//             var supplier = core.GetSupplier(5).Result;
//             //var result = core.DeleteSupplier(supplier).Result;
//             //Assert.IsTrue(result);
//         }


//         [Test]
//         public void DeleteSupplier4ThatDeleteContact4AndAddress4()
//         {
  
//             var result = core.DeleteSupplier(4).Result;
//             Assert.IsTrue(result);
//         }
//     }
// }

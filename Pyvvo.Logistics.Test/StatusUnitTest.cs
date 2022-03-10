using NUnit.Framework;
using Pyvvo.Logistics.Model;
using Pyvvo.Logistics.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Test
{
    public class StatusUnitTest
    {
        //[Test]
        //public void CreateVerifiedStatusForUser()
        //{
        //    // Create new status for user
        //    Status status = new Status
        //    {
        //        CreateDon = DateTime.Now,
        //        Description = "Status for verified user",
        //        IsActive = true,
        //        Name = "Verified",
        //    };

        //    var statusCategCore = new StatusCategoryCore();
        //    // In test case i can use order status categ. it doesn't matter. 
        //    // In good context create user status categ 
        //    var statusCateg = statusCategCore.GetStatusCategory(1).Result;
        //    if (statusCateg != null)
        //        status.StatusCategory = statusCateg;

        //    var statusCore = new StatusCore();
        //    var isCreated = statusCore.CreateStatus(status);
        //    Assert.IsTrue(isCreated.Result);
        //}
    }
}

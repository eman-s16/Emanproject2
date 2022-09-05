using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Emanproject.Models;
using Emanproject;
using Emanproject.Controllers;
using System.Web.Mvc;
using System.Text;
using System.Net;

namespace EmanprojectUnitTestProject.Controller
{
    [TestClass]
    public class CountriesControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            CountriesController controller = new CountriesController();
            ViewResult result = controller.Index() as ViewResult;
           

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "one");
        }
        [TestMethod]
        public void Create()
        {
            // Arrange
            CountriesController controller = new CountriesController();

            // Act
            ViewResult result = controller.Create(new Emanproject.Models.Country()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit(int? id)
        {
            // Arrange
            CountriesController controller = new CountriesController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete(int? id)
        {
            // Arrange
            CountriesController controller = new CountriesController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }






    }
}

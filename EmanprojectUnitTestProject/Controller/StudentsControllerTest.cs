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
    public class StudentsControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            StudentsController controller = new StudentsController();
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
            StudentsController controller = new StudentsController();

            // Act
            ViewResult result = controller.Create(new Emanproject.Models.Student()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit(int? id)
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete(int? id)
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }






    }
}

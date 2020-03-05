using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using NUnit.Framework;
using PaintCalculator.Controllers;
using PaintCalculator.Models;
using System;

namespace PaintCalculator.Tests
{
    public class Tests
    {
        // Note each Unit Test tests one result
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalculateArea() 
        {
            // Arrange
            int length = 1;
            int width = 2;
            int height = 3;
            PaintModel model = new PaintModel // model uses numbers as string since also used on front end
            {
                Length = length.ToString(),
                Width = width.ToString(),
                Height = height.ToString()
            };
            var logger = new Object() as ILogger<HomeController>;
            var ctrlr = new HomeController(logger);

            // Act
            var jsonResult = (JsonResult)ctrlr.Calculate(model); // this is the method being tested in the controller
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Result result = serializer.Deserialize<Result>(serializer.Serialize(jsonResult.Value));

            // Assert
            Assert.IsNotNull(jsonResult.Value);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Area);
            Assert.AreEqual(result.Area, (length * width).ToString());
        }
        public class Result
        {
            public bool Success;
            public string Area;
            public string Paint;
            public string Volume;
        }
    }
}
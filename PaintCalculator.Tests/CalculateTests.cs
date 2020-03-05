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
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Area, (length * width).ToString());
        }

        [Test]
        public void TestCalculatePaint()
        {
            // Arrange
            int length = 1;
            int width = 2;
            int height = 3;
            var factor = 3.321M;

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
            Assert.IsNotNull(result.Paint);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Paint, (2 * height * (length + width) * factor).ToString());
        }

        [Test]
        public void TestCalculateVolume()
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
            Assert.IsNotNull(result.Volume);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Volume, (length * width * height).ToString());
        }

        [Test]
        public void TestNullOrMissingData()
        {
            // Arrange
            PaintModel model = new PaintModel // model uses numbers as string since also used on front end
            {
                Length = null,
                Width = null,
                Height = null
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
            Assert.IsNotNull(result.Volume);
            Assert.AreEqual(result.Success, true);
            Assert.AreEqual(result.Area, "0");
            Assert.AreEqual(result.Paint, "0");
            Assert.AreEqual(result.Volume, "0");
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
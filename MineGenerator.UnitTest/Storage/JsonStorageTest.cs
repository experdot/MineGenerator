using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineGenerator.Core.Storage;
using MineGenerator.Storage;

namespace MineGenerator.UnitTest
{
    [TestClass]
    public class JsonStorageTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new JsonStorageService();
            var package = new Package();
            Package newPackage;
            using (var stream = new MemoryStream())
            {
                service.Write(stream, package);
                newPackage = service.Read(stream);
            }
            Assert.AreEqual(package.Id, newPackage.Id);
        }
    }
}

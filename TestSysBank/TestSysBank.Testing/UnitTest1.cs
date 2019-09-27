using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSysBank.BL;
using TestSysBank.EN;

namespace TestSysBank.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodInsert()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "Alexander";
            cliente.Apellido = "Leiva";
            Assert.AreEqual(1, ClienteBL.Insert(cliente));
        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = 10020;
            cliente.Nombre = "Alexander";
            cliente.Apellido = "Leiva Arevalo";
            Assert.AreEqual(1, ClienteBL.Update(cliente));
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            Cliente cliente = new Cliente();
            Assert.AreEqual(1, ClienteBL.Delete(10020));
        }

        [TestMethod]
        public void TestMethodGetAll()
        {
            Assert.AreEqual(11, ClienteBL.GetAll().Count);
        }

        [TestMethod]
        public void TestMethodGetById()
        {
            Assert.AreEqual(17, ClienteBL.GetById(17).IdCliente);
        }
    }
}

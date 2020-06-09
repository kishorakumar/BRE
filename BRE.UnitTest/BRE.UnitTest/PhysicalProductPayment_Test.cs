using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;

namespace BRE.UnitTest
{
    public class PhysicalProductPayment_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustGeneratePackagingSlip()
        {
            IProduct physicalProduct = new ProductPhysical();

            physicalProduct.ProductName = "Basket";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Packaging Slip"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustGenerateCommissionToAgent()
        {
            IProduct physicalProduct = new ProductPhysical();

            physicalProduct.ProductName = "Basket";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustGenerateCommissionToAgent_AND_MustGeneratePackagingSlip()
        {
            IProduct physicalProduct = new ProductPhysical();

            physicalProduct.ProductName = "Basket";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
            Assert.IsTrue(statuses.Contains("Generated Packaging Slip"));
        }
    }
}
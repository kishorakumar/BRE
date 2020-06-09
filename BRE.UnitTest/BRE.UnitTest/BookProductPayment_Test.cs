using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;

namespace BRE.UnitTest
{
    public class BookProductPayment_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateDuplicateSlipForRoyalty()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Good Book";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Duplicate packing slip for the royalty department"));
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateCommissionToAgent()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Good Book";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateCommissionToAgent_AND_MustGenerateDuplicateSlipForRoyalty()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Good Book";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
            Assert.IsTrue(statuses.Contains("Generated Duplicate packing slip for the royalty department"));
        }
    }
}
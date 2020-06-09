using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;

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

            string status = physicalProduct.PaymentDone();

            Assert.AreEqual("Generated Packaging Slip", status);
        }
    }
}
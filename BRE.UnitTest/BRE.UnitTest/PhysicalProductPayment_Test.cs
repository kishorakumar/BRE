using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;
using BRE.Core.Actions;

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

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();
            mockPackagingSlipGenerator.Setup(m => m.GeneratePackingSlip(physicalProduct))
                                    .Returns("Generated Packaging Slip");
            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();
            
            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object, 
                                                   mockComisionGenerator.Object,mockDuplicatePackagingSlipGenerator.Object, 
                                                   mockPackagingSlipGenerator.Object,mockMembershipUpgrade.Object, 
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains("Generated Packaging Slip"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustGenerateCommissionToAgent()
        {
            IProduct physicalProduct = new ProductPhysical();

            physicalProduct.ProductName = "Basket";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();
            mockPackagingSlipGenerator.Setup(m => m.GeneratePackingSlip(physicalProduct))
                                    .Returns("Generated Packaging Slip");
            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();

            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustGenerateCommissionToAgent_AND_MustGeneratePackagingSlip()
        {
            IProduct physicalProduct = new ProductPhysical();

            physicalProduct.ProductName = "Basket";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();
            mockPackagingSlipGenerator.Setup(m => m.GeneratePackingSlip(physicalProduct))
                                    .Returns("Generated Packaging Slip");
            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();

            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
            Assert.IsTrue(statuses.Contains("Generated Packaging Slip"));
        }
    }
}
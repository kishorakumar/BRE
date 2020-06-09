using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;
using BRE.Core.Actions;

namespace BRE.UnitTest
{
    public class BookProductPayment_Test
    {
        private IPostPaymentActions postPaymentHandler;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateDuplicateSlipForRoyalty()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Basket";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();
            mockDuplicatePackagingSlipGenerator.Setup(m => m.GenerateDuplicatePackingSlipForRoyalty(physicalProduct))
                                    .Returns("Generated Duplicate packing slip for the royalty department");

            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);


            Assert.IsTrue(statuses.Contains("Generated Duplicate packing slip for the royalty department"));
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateCommissionToAgent()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Basket";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();
            mockDuplicatePackagingSlipGenerator.Setup(m => m.GenerateDuplicatePackingSlipForRoyalty(physicalProduct))
                                    .Returns("Generated Duplicate packing slip for the royalty department");

            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
        }

        [Test]
        public void PaymentFor_BookProduct_MustGenerateCommissionToAgent_AND_MustGenerateDuplicateSlipForRoyalty()
        {
            IProduct physicalProduct = new ProductBook();

            physicalProduct.ProductName = "Basket";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            mockComisionGenerator.Setup(m => m.GeneratePackingCommisionToAgent(physicalProduct))
                                    .Returns("Generated Commision To Agent");

            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();
            mockDuplicatePackagingSlipGenerator.Setup(m => m.GenerateDuplicatePackingSlipForRoyalty(physicalProduct))
                                    .Returns("Generated Duplicate packing slip for the royalty department");

            var mockMembershipNew = new Mock<IActivateMembership>();
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);


            Assert.IsTrue(statuses.Contains("Generated Commision To Agent"));
            Assert.IsTrue(statuses.Contains("Generated Duplicate packing slip for the royalty department"));
        }
    }
}
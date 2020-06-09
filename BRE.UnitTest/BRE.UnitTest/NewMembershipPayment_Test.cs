using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;
using BRE.Core.Actions;

namespace BRE.UnitTest
{
    public class NewMembershipPayment_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentFor_NewMembership_MustActivateMembership()
        {
            IProduct physicalProduct = new MembershipNew();

            physicalProduct.ProductName = "New Member - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();
           

            var mockMembershipNew = new Mock<IActivateMembership>();
            mockMembershipNew.Setup(m => m.ActivateMembership(physicalProduct))
                                   .Returns($"Activated { physicalProduct.ProductName }'s membership");
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin",physicalProduct.ProductName,"Activated"))
                                   .Returns($"Sent Email to {physicalProduct.ProductName}");
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);


            Assert.IsTrue(statuses.Contains($"Activated {physicalProduct.ProductName }'s membership"));
        }

        [Test]
        public void PaymentFor_NewMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipNew();

            physicalProduct.ProductName = "New Member - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();
            mockMembershipNew.Setup(m => m.ActivateMembership(physicalProduct))
                                   .Returns($"Activated { physicalProduct.ProductName }'s membership");
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin", physicalProduct.ProductName, "Activated"))
                                   .Returns($"Sent Email to {physicalProduct.ProductName}");
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustActivateMembership_AND_NewMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipNew();

            physicalProduct.ProductName = "New Member - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();
            mockMembershipNew.Setup(m => m.ActivateMembership(physicalProduct))
                                   .Returns($"Activated { physicalProduct.ProductName }'s membership");
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin", physicalProduct.ProductName, "Activated"))
                                   .Returns($"Sent Email to {physicalProduct.ProductName}");
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains($"Activated {physicalProduct.ProductName }'s membership"));
            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }
    }
}
using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;
using BRE.Core.Actions;

namespace BRE.UnitTest
{
    public class UpgradeMembershipPayment_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentFor_UpgradeMembership_MustUpgradeMembership()
        {
            IProduct physicalProduct = new MembershipUpgrade();

            physicalProduct.ProductName = "Upgrade - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();
            
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            mockMembershipUpgrade.Setup(m => m.UpgradeMembership(physicalProduct))
                                   .Returns($"Upgraded { physicalProduct.ProductName }'s membership");
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin", physicalProduct.ProductName, "Upgraded"))
                                   .Returns($"Sent Email to {physicalProduct.ProductName}");
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);


            Assert.IsTrue(statuses.Contains($"Upgraded {physicalProduct.ProductName }'s membership"));
        }

        [Test]
        public void PaymentFor_UpgradeMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipUpgrade();

            physicalProduct.ProductName = "Upgrade - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();

            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            mockMembershipUpgrade.Setup(m => m.UpgradeMembership(physicalProduct))
                                   .Returns($"Upgraded { physicalProduct.ProductName }'s membership");
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin", physicalProduct.ProductName, "Upgraded"))
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
        public void PaymentFor_UpgradeMembership_MustUpgradeMembership_AND_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipUpgrade();

            physicalProduct.ProductName = "Upgrade - Harry";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();

            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            mockMembershipUpgrade.Setup(m => m.UpgradeMembership(physicalProduct))
                                   .Returns($"Upgraded { physicalProduct.ProductName }'s membership");
            var mockEmailSender = new Mock<ISendEmail>();
            mockEmailSender.Setup(m => m.SendEmail("Admin", physicalProduct.ProductName, "Upgraded"))
                                   .Returns($"Sent Email to {physicalProduct.ProductName}");
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(statuses.Contains($"Upgraded {physicalProduct.ProductName }'s membership"));
            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }
    }
}
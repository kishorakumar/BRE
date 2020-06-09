using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;
using BRE.Core.Actions;

namespace BRE.UnitTest
{
    public class VideoPayment_Test
    {
        [Test]
        public void PaymentFor_VideoLearningSki_MustAddFirstAidVideoForFree()
        {
            IProduct physicalProduct = new ProductVideo();

            physicalProduct.ProductName = "Learning to Ski";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();
            
            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();
            
            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();
            mockAddFreeProducts.Setup(m => m.AddEligibleFreeProducts(physicalProduct))
                                   .Returns($"Added 'First Aid' for free (as per court decision 1997) ");

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);


            Assert.IsTrue(statuses.Contains($"Added 'First Aid' for free (as per court decision 1997) "));
        }

        [Test]
        public void PaymentFor_VideoOtherThanLearningSki_MustNotAddFirstAidVideoForFree()
        {
            IProduct physicalProduct = new ProductVideo();

            physicalProduct.ProductName = "Other than Learning to Ski";

            var mockPackagingSlipGenerator = new Mock<IGeneratePackagingSlip>();

            var mockComisionGenerator = new Mock<IGenerateCommisionToAgent>();
            var mockDuplicatePackagingSlipGenerator = new Mock<IGenerateDuplicatePackingSlipForRoyalty>();


            var mockMembershipNew = new Mock<IActivateMembership>();

            var mockMembershipUpgrade = new Mock<IUpgradeMembership>();
            var mockEmailSender = new Mock<ISendEmail>();

            var mockAddFreeProducts = new Mock<IAddEligibleFreeProducts>();
            mockAddFreeProducts.Setup(m => m.AddEligibleFreeProducts(physicalProduct))
                                   .Returns($"");

            var postPaymentHandler = new PostPaymentActions(mockMembershipNew.Object, mockAddFreeProducts.Object,
                                                   mockComisionGenerator.Object, mockDuplicatePackagingSlipGenerator.Object,
                                                   mockPackagingSlipGenerator.Object, mockMembershipUpgrade.Object,
                                                   mockEmailSender.Object);

            List<IProduct> products = new List<IProduct>() { physicalProduct };
            List<string> statuses = postPaymentHandler.PerformPostPaymentActions(products);

            Assert.IsTrue(!statuses.Contains($"Added 'First Aid' for free (as per court decision 1997) "));
        }
                
    }
}
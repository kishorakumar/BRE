using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;

namespace BRE.UnitTest
{
    public class VideoPayment_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PaymentFor_VideoLearningSki_MustAddFirstAidVideoForFree()
        {
            IProduct physicalProduct = new ProductVideo();

            physicalProduct.ProductName = "Learning to Ski";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Added 'First Aid' for free (as per court decision 1997) "));
        }

        [Test]
        public void PaymentFor_VideoOtherThanLearningSki_MustNotAddFirstAidVideoForFree()
        {
            IProduct physicalProduct = new ProductVideo();

            physicalProduct.ProductName = "Other than Learning to Ski";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(!statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }
                
    }
}
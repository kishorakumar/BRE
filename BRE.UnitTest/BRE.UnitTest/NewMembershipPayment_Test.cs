using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;

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

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Activated {physicalProduct.ProductName }'s membership"));
        }

        [Test]
        public void PaymentFor_NewMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipNew();

            physicalProduct.ProductName = "New Member - Harry";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }

        [Test]
        public void PaymentFor_PhysicalProduct_MustActivateMembership_AND_NewMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipNew();

            physicalProduct.ProductName = "New Member - Harry";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Activated {physicalProduct.ProductName }'s membership"));
            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }
    }
}
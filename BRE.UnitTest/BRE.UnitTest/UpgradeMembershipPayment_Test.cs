using NUnit.Framework;
using BRE.Core;
using BRE.Core.Models;
using Moq;
using System.Collections.Generic;

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

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Upgraded {physicalProduct.ProductName }'s membership"));
        }

        [Test]
        public void PaymentFor_UpgradeMembership_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipUpgrade();

            physicalProduct.ProductName = "Upgrade - Harry";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }

        [Test]
        public void PaymentFor_UpgradeMembership_MustUpgradeMembership_AND_MustSendEmail()
        {
            IProduct physicalProduct = new MembershipUpgrade();

            physicalProduct.ProductName = "Upgrade - Harry";

            List<string> statuses = physicalProduct.PaymentDone();

            Assert.IsTrue(statuses.Contains($"Upgraded {physicalProduct.ProductName }'s membership"));
            Assert.IsTrue(statuses.Contains($"Sent Email to {physicalProduct.ProductName}"));
        }
    }
}
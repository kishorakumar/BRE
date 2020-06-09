using BRE.Core.Actions;
using BRE.Core.Actions.Implementations;
using BRE.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRE.Core
{
    public class PostPaymentActions : IPostPaymentActions
    {
        IActivateMembership _activateMembership;
        IAddEligibleFreeProducts _addEligibleFreeProducts;
        IGenerateCommisionToAgent _generateCommisionToAgent;
        IGenerateDuplicatePackingSlipForRoyalty _generateDuplicatePackingSlipForRoyalty;
        IGeneratePackagingSlip _generatePackagingSlip;
        IUpgradeMembership _upgradeMembership;
        ISendEmail _sendEmail;
        public PostPaymentActions(IActivateMembership activateMembership,
                                  IAddEligibleFreeProducts addEligibleFreeProducts,
                                  IGenerateCommisionToAgent generateCommisionToAgent,
                                  IGenerateDuplicatePackingSlipForRoyalty generateDuplicatePackingSlipForRoyalty,
                                  IGeneratePackagingSlip generatePackagingSlip,
                                  IUpgradeMembership upgradeMembership,
                                  ISendEmail sendEmail)
        {
            _activateMembership = activateMembership;
            _addEligibleFreeProducts = addEligibleFreeProducts;
            _generateCommisionToAgent = generateCommisionToAgent;
            _generateDuplicatePackingSlipForRoyalty = generateDuplicatePackingSlipForRoyalty;
            _generatePackagingSlip = generatePackagingSlip;
            _upgradeMembership = upgradeMembership;
            _sendEmail = sendEmail;
        }
        public List<string> PerformPostPaymentActions(List<IProduct> products)
        {
            List<string> statues = new List<string>();
            foreach(IProduct product in products)
            {
                switch (product.ProductType)
                {
                    case ProductTypes.PhyscialProduct:
                        statues.Add(_generatePackagingSlip.GeneratePackingSlip(product));
                        statues.Add(_generateCommisionToAgent.GeneratePackingCommisionToAgent(product));
                        break;
                    case ProductTypes.Book:
                        statues.Add(_generateDuplicatePackingSlipForRoyalty.GenerateDuplicatePackingSlipForRoyalty(product));
                        statues.Add(_generateCommisionToAgent.GeneratePackingCommisionToAgent(product));
                        break;
                    case ProductTypes.NewMembership:
                        statues.Add(_activateMembership.ActivateMembership(product));
                        statues.Add(_sendEmail.SendEmail("Admin", product.ProductName, "Activated"));
                        break;
                    case ProductTypes.UpgradeMembership:
                        statues.Add(_upgradeMembership.UpgradeMembership(product));
                        statues.Add(_sendEmail.SendEmail("Admin", product.ProductName, "Upaded"));
                        break;
                    case ProductTypes.Video:
                        //No Special cases to handle.
                        //Free product has been handled in default case to make adding free products flwxible.
                        break;
                    default:
                        string status = _addEligibleFreeProducts.AddEligibleFreeProducts(product);
                        if (!string.IsNullOrEmpty(status))
                            statues.Add(status);
                        break;
                }
            }

            return statues;
        }
    }
}

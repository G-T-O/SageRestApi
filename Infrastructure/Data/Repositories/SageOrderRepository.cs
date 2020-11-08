using System;
using System.Threading.Tasks;
using Application.Interfaces.Access;
using Application.Interfaces.Sage.Repositories;
using Core.Dto;
using Infrastructure.Data.Mapper;
using Objets100cLib;

namespace Infrastructure.Data.Repositories
{
    public class SageOrderRepository : ISageOrderRepository
    {
        private ISageAccess _sageAccess;
        public SageOrderRepository(ISageAccess sageAccess)
        {
            _sageAccess = sageAccess;
        }
        public async Task<int> AddAsync(Order order)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return  1;
                }
                IBODocumentVente3 orderHeader = _sageAccess.GetSageDatabase.FactoryDocumentVente.CreateType(DocumentType.DocumentTypeVenteCommande);
                IBOClient3 tiersPayeur = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(order.DO_Tiers);
                IBODocumentVenteLigne3 orderLines;

                try
                {
                    orderHeader.SetDefaultClient(tiersPayeur);
                    orderHeader.DO_Ref = order.DO_Ref;
                    orderHeader.DO_Date = DateTime.Now;
                    orderHeader.DO_Statut = DocumentStatutType.DocumentStatutTypeConfirme;
                    orderHeader.SetDefaultDO_Piece();
                    orderHeader.WriteDefault();
                    orderHeader.CouldModified();
                    orderHeader.Write();

                    foreach (var article in order.Articles)
                    {
                        if (_sageAccess.GetSageDatabase.FactoryArticle.ExistReference(article.ArticleCode))
                        {
                            orderLines = (IBODocumentVenteLigne3)orderHeader.FactoryDocumentLigne.Create();
                            orderLines.SetDefaultArticle(_sageAccess.GetSageDatabase.FactoryArticle.ReadReference(article.ArticleCode), article.ArticleQte);
                            orderLines.WriteDefault();
                        }
                        else
                        {
                           //Log
                        }
                    }
                    return 0;
                }
                catch (Exception e)
                {
                    return 1;
                }
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return 1;
                }

                if(_sageAccess.GetSageDatabase.FactoryDocumentVente.ExistPiece(DocumentType.DocumentTypeVenteCommande, id) == false)
                {
                    return 1;
                }
                IBODocumentVente3 docEntete = _sageAccess.GetSageDatabase.FactoryDocumentVente.ReadPiece(DocumentType.DocumentTypeVenteCommande,id);
                try
                {
                    docEntete.Remove();
                    return 0;
                }
                catch (Exception e)
                {
                    return 1;
                }
            }
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            lock (_sageAccess.DatabaseLock)
            {
                Order sageOrder=null;
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return sageOrder;
                }

                if (_sageAccess.GetSageDatabase.FactoryDocumentVente.ExistPiece(DocumentType.DocumentTypeVenteCommande, id) == false)
                {
                    return sageOrder;
                }
                IBODocumentVente3 orderHeader = _sageAccess.GetSageDatabase.FactoryDocumentVente.ReadPiece(DocumentType.DocumentTypeVenteCommande, id);
                
                try
                {
                    sageOrder = ObjectMapper.IboOrderToOrder(orderHeader);
                    return sageOrder;
                }
                catch (Exception e)
                {
                    return sageOrder;
                }
            }
          
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
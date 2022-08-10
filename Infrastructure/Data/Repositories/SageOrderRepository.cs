using System;
using System.Threading.Tasks;
using Infrastructure.Data.IDBAccess;
using Core.Dto;
using Objets100cLib;
using Infrastructure.IRepositories.Sage;
using Core.Dto.Requests;

namespace Infrastructure.Data.Repositories
{
    public class SageOrderRepository : ISageOrderRepository
    {
        private ISageAccess _sageAccess;
        public SageOrderRepository(ISageAccess sageAccess)
        {
            _sageAccess = sageAccess;
        }
        public Task<string> Create(OrderRequest order)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    Utility.ComObject.Close(_sageAccess);
                    throw new Exception("Error while opening the com database");
                }
                IBODocumentVente3 orderHeader = _sageAccess.GetSageDatabase.FactoryDocumentVente.CreateType(DocumentType.DocumentTypeVenteCommande);
                IBOClient3 tiersPayeur = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(order.SageCodeClient);
                IBODocumentVenteLigne3 orderLines;

                try
                {
                    orderHeader.SetDefaultClient(tiersPayeur);
                    orderHeader.DO_Ref = order.Reference;
                    orderHeader.DO_Date = DateTime.Now;
                    orderHeader.DO_Statut = DocumentStatutType.DocumentStatutTypeConfirme;
                    orderHeader.SetDefaultDO_Piece();
                    orderHeader.WriteDefault();
                    orderHeader.CouldModified();
                    orderHeader.Write();

                    foreach (Article article in order.Articles)
                    {
                        if (_sageAccess.GetSageDatabase.FactoryArticle.ExistReference(article.ArticleCode))
                        {
                            orderLines = (IBODocumentVenteLigne3)orderHeader.FactoryDocumentLigne.Create();
                            orderLines.SetDefaultArticle(_sageAccess.GetSageDatabase.FactoryArticle.ReadReference(article.ArticleCode), article.ArticleQte);
                            orderLines.Remise.Remise[1].REM_Type = RemiseType.RemiseTypePourcent;
                            orderLines.Remise.Remise[1].REM_Valeur = article.FirstDiscount;
                            orderLines.Remise.Remise[2].REM_Type = RemiseType.RemiseTypePourcent;
                            orderLines.Remise.Remise[2].REM_Valeur = article.SecondDiscount;
                            orderLines.WriteDefault();
                        }
                        else
                        {
                            //Log
                        }
                    }
                    string result = orderHeader.DO_Piece;
                    Utility.ComObject.Close(_sageAccess);
                    return Task.FromResult(result);
                }
                catch (Exception e)
                {
                    Utility.ComObject.Close(_sageAccess);
                    throw;
                }
            }
        }

        public Task<int> Delete(string id)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    throw new Exception("Error while opening the com database");
                }

                if (_sageAccess.GetSageDatabase.FactoryDocumentVente.ExistPiece(DocumentType.DocumentTypeVenteCommande, id) == false)
                {
                    throw new Exception("Order code not found");
                }
                IBODocumentVente3 docEntete = _sageAccess.GetSageDatabase.FactoryDocumentVente.ReadPiece(DocumentType.DocumentTypeVenteCommande, id);
                try
                {
                    foreach (IBODocumentLigne3 line in docEntete.FactoryDocumentLigne.List)
                    {
                        line.Remove();
                    }
                    docEntete.Remove();

                    Utility.ComObject.Close(_sageAccess);
                    return Task.FromResult(0);
                }
                catch (Exception e)
                {
                    Utility.ComObject.Close(_sageAccess);
                    throw;
                }
            }
        }
    }
}
using Core.Dto;
using Objets100cLib;
using System;

namespace Infrastructure.Data.Mapper
{
    public static class ObjectMapper
    {
        public static IBOClient3 ClientToNewIboClient(Client client,IBOClient3 sageClient)
        {
            sageClient.CT_Intitule = client.CT_Intitule;
            sageClient.CT_Qualite = client.CT_Qualite;
            sageClient.Telecom.EMail = client.Email;
            sageClient.Telecom.Portable = client.Portable;
            sageClient.Telecom.Telecopie = client.Telecopie;
            sageClient.Telecom.Telephone = client.Telephone;
            sageClient.Adresse.Adresse = client.Adresse;
            sageClient.Adresse.Complement = client.Complement;
            sageClient.Adresse.CodePostal = client.CodePostal;
            sageClient.Adresse.Ville = client.Ville;
            sageClient.Adresse.Pays = client.Pays;
            sageClient.CT_Identifiant = client.CT_Identifiant;
           return sageClient;
        }

        public static IBOClient3 ClientToIboClient(Client client, IBOClient3 sageClient)
        {
            sageClient.CT_Num = client.CT_Num;
            sageClient.CT_Siret = client.CT_Siret;
            sageClient.CT_Intitule = client.CT_Intitule;
            sageClient.CT_Qualite = client.CT_Qualite;
            sageClient.Telecom.EMail = client.Email;
            sageClient.Telecom.Portable = client.Portable;
            sageClient.Telecom.Telecopie = client.Telecopie;
            sageClient.Telecom.Telephone = client.Telephone;
            sageClient.Adresse.Adresse = client.Adresse;
            sageClient.Adresse.Complement = client.Complement;
            sageClient.Adresse.CodePostal = client.CodePostal;
            sageClient.Adresse.Ville = client.Ville;
            sageClient.Adresse.Pays = client.Pays;
            sageClient.CT_Identifiant = client.CT_Identifiant;
            return sageClient;
        }

        public static Client IboClientToClient(IBOClient3 sageClient)
        {
            Client client = new Client();
            client.CT_Num = sageClient.CT_Num;
            client.CT_Siret = sageClient.CT_Siret;
            client.CT_Intitule = sageClient.CT_Intitule;
            client.CT_Qualite = sageClient.CT_Qualite;
            client.Email = sageClient.Telecom.EMail;
            client.Portable = sageClient.Telecom.Portable;
            client.Telecopie = sageClient.Telecom.Telecopie;
            client.Telephone = sageClient.Telecom.Telephone;
            client.Adresse = sageClient.Adresse.Adresse;
            client.Complement = sageClient.Adresse.Complement;
            client.CodePostal = sageClient.Adresse.CodePostal;
            client.Ville = sageClient.Adresse.Ville;
            client.Pays = sageClient.Adresse.Pays;
            client.CT_Identifiant = sageClient.CT_Identifiant;
            return client;
        }

        public static Order IboOrderToOrder(IBODocumentVente3 orderHeader)
        {
            Order sageOrder = new Order();
            try
            {
                sageOrder.DO_Piece = orderHeader.DO_Piece;
                sageOrder.DO_Ref = orderHeader.DO_Ref;
                sageOrder.DO_Statut = orderHeader.DO_Statut.ToString();
                sageOrder.DO_Tiers = orderHeader.Tiers.CT_Num;
                sageOrder.CT_NumPayeur = orderHeader.TiersPayeur.CT_Num;
                sageOrder.DO_Date = orderHeader.DO_Date;
                sageOrder.DO_DateLivr = orderHeader.DO_DateLivr;
                sageOrder.DO_TotalHT = Convert.ToDecimal(orderHeader.DO_TotalHT);
                sageOrder.DO_TotalHTNet = Convert.ToDecimal(orderHeader.DO_TotalHTNet);
                sageOrder.DO_TotalTTC = Convert.ToDecimal(orderHeader.DO_TotalTTC);
                sageOrder.DO_NetAPayer = Convert.ToDecimal(orderHeader.DO_NetAPayer);
                sageOrder.DO_MontantRegle = Convert.ToDecimal(orderHeader.DO_MontantRegle);

                foreach (IBODocumentVenteLigne3 orderLine in orderHeader.FactoryDocumentLigne.List)
                {
                    DocLine docLine = new DocLine();
                    docLine.AR_Ref = orderLine.Article.AR_Ref;
                    docLine.DL_Design = orderLine.DL_Design;
                    docLine.DL_MontantHT = Convert.ToDecimal(orderLine.DL_MontantHT);
                    docLine.DL_MontantTTC = Convert.ToDecimal(orderLine.DL_MontantTTC);
                    docLine.DL_PrixUnitaire = Convert.ToDecimal(orderLine.DL_PrixUnitaire);
                    docLine.DL_PUTTC = Convert.ToDecimal(orderLine.DL_PUTTC);
                    docLine.DL_Qte = orderLine.DL_Qte;
                    //docLine.DL_Taxe1 = orderLine.Taxe.TA_GrilleTaxe.1
                    //docLine.DL_TypeTaxe1 = orderLine.Taxe.TA_Type;
                    docLine.DO_Date = orderLine.DO_Date;
                    docLine.DO_Domaine = Convert.ToByte(orderLine.DO_Domaine);
                    docLine.DO_Piece = orderLine.DL_PieceBC;
                    docLine.DO_Type = Convert.ToByte(orderLine.DO_Type);

                    sageOrder.DocLines.Add(docLine);
                }
                return sageOrder;
            }
            catch(Exception e)
            {

                return sageOrder;
            }
        }
    }
}

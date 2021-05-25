using Core.Dto;
using Core.Entities;
using Objets100cLib;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Mapper
{
    public static class ObjectMapper
    {
        public static IBOClient3 CreateClientToIboClient(Client client,IBOClient3 sageClient)
        {
            sageClient.CT_Siret = client.Siret;
            sageClient.CT_Intitule = client.CompanyName;
            sageClient.CT_Qualite = client.LegalForm;
            sageClient.CT_Classement = client.CompanyName.Length > 17 ? client.CompanyName.Substring(0, 17) : client.CompanyName;
            sageClient.CT_Identifiant = client.VatIdentifier;
            sageClient.CT_Ape = client.Naf;
            
            sageClient.Telecom.EMail = client.CompanyEmail;
            sageClient.Telecom.Portable = client.CompanyPhoneNumber;
            sageClient.Telecom.Telecopie = client.CompanyFax;
            sageClient.Telecom.Telephone = client.CompanyMobile;

            sageClient.Adresse.Adresse = client.MainAddress.MainAddress;
            sageClient.Adresse.Complement = client.MainAddress.AdressAdditional;
            sageClient.Adresse.CodePostal = client.MainAddress.ZipCode;
            sageClient.Adresse.Ville = client.MainAddress.City;
            sageClient.Adresse.Pays = client.MainAddress.Country;
            sageClient.WriteDefault();

            foreach (var contact in client.Contacts)
            {
                IBOTiersContact3 sageContact = (IBOTiersContact3)sageClient.FactoryTiersContact.Create();
                sageContact.CouldModified();
                sageContact.Civilite = (ContactCivilite)contact.Civility;
                sageContact.Nom = contact.LastName;
                sageContact.Prenom = contact.FirstName;
                sageContact.Telecom.Telephone = contact.PhoneNumber;
                sageContact.Telecom.Portable = contact.MobileNumber;
                sageContact.Telecom.EMail = contact.Email;
                sageContact.Fonction = contact.Position;
                sageContact.Write();
            }
            sageClient.Read();
            return sageClient;
        }
        public static Task<Client> ClientEntityToDtoClient(ClientEntity clientEntity)
        {
            Client customer = new Client();
            customer.CompanyName = clientEntity.CT_Intitule;
            customer.SageCode = clientEntity.CT_Num;
            customer.Siret = clientEntity.CT_Siret;
            customer.VatIdentifier = clientEntity.CT_Identifiant;
            customer.LeaderCivility = clientEntity.CT_Civilite;
            customer.LeaderFirstName = clientEntity.CT_Prenom;
            customer.LeaderLastName = clientEntity.CT_Nom;
            customer.LegalForm = clientEntity.CT_Qualite;
            customer.MainAddress.MainAddress = clientEntity.CT_Adresse;
            customer.MainAddress.AdressAdditional = clientEntity.CT_Complement;
            customer.MainAddress.City = clientEntity.CT_Ville;
            customer.MainAddress.Country = clientEntity.CT_Pays;
            customer.MainAddress.ZipCode = clientEntity.CT_CodePostal;
            customer.Naf = clientEntity.CT_Ape;
            customer.CompanyEmail = clientEntity.CT_Email;
            customer.OwnerPhoneNumber = clientEntity.CT_Telephone;
            return Task.FromResult(customer);
        }

       public static IBOClient3 UpdateClientToIboClient(Client client, IBOClient3 sageClient)
        {
            sageClient.CT_Siret = client.Siret; // check 
            sageClient.CT_Intitule = client.CompanyName; // check
            sageClient.CT_Qualite = client.LegalForm;
            sageClient.CT_Ape = client.Naf;
            sageClient.CT_Classement = client.CompanyName.Length > 17 ? client.CompanyName.Substring(0, 17) : client.CompanyName;
            sageClient.CT_Identifiant = client.VatIdentifier;

            sageClient.Telecom.EMail = client.CompanyEmail;
            sageClient.Telecom.Telephone = client.OwnerPhoneNumber;
            sageClient.Telecom.EMail = client.CompanyEmail;
            sageClient.Telecom.Portable = client.CompanyMobile;
            sageClient.Telecom.Telecopie = client.CompanyFax;
            sageClient.Telecom.Telephone = client.CompanyMobile;

            sageClient.Adresse.Adresse = client.MainAddress.MainAddress;
            sageClient.Adresse.Complement = client.MainAddress.AdressAdditional;
            sageClient.Adresse.CodePostal = client.MainAddress.ZipCode;
            sageClient.Adresse.Ville = client.MainAddress.City;
            sageClient.Adresse.Pays = client.MainAddress.Country;
            sageClient.CT_Identifiant = client.VatIdentifier;
            sageClient.WriteDefault();
            // To do add delivery add
            return sageClient;
        }
/* 
        public static Client IboClientToClient(IBOClient3 sageClient)
        {
            Client client = new Client();
            client.SageCode = sageClient.CT_Num;
            client.Siret = sageClient.CT_Siret;
            client.CompanyName = sageClient.CT_Intitule;
            client.LegalForm = sageClient.CT_Qualite;
            client.CompanyEmail = sageClient.Telecom.EMail;
            client.Portable = sageClient.Telecom.Portable;
            client.CompanyFax = sageClient.Telecom.Telecopie;
            client.CompanyMobile = sageClient.Telecom.Telephone;
            client.MainAddress.MainAddress = sageClient.Adresse.Adresse;
            client.MainAddress.AdressAdditional = sageClient.Adresse.Complement;
            client.MainAddress.ZipCode = sageClient.Adresse.CodePostal;
            client.MainAddress.City = sageClient.Adresse.Ville;
            client.MainAddress.Country = sageClient.Adresse.Pays;
            client.VatIdentifier = sageClient.CT_Identifiant;
            return client;
        }*/

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
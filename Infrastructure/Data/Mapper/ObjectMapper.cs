using Core.Dto;
using Objets100cLib;

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
    }
}

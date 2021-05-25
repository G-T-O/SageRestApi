using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ClientEntity
    {
        public string CT_Num { get; set; }
        public string CT_Intitule { get; set; }
        public string CT_Type { get; set; }
        public string CG_NumPrinc { get; set; }
        public string CT_Qualite { get; set; }
        public string CT_Siret { get; set; }
        public string CT_Ape { get; set; }
        public string CT_Contact { get; set; }
        public string CT_Prenom { get; set; }
        public string CT_Nom { get; set; }
        public string Email { get; set; }
        public string EmailCertificat { get; set; }
        public string CT_Email { get; set; }
        public string CT_Portable { get; set; }
        public string CT_Telecopie { get; set; }
        public string CT_Telephone { get; set; }
        public string CT_Identifiant { get; set; }
        public int CT_Civilite { get; set; }
        public string CT_Adresse { get; set; }
        public string CT_Complement { get; set; }
        public string CT_CodePostal { get; set; }
        public string CT_Ville { get; set; }
        public string CT_Pays { get; set; }
        public string CT_Sommeil { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime cbModification { get; set; }
        public DateTime cbCreation { get; set; }
        public IEnumerable<ContactEntity> Contacts { get; set; }
    }
}
using System;

namespace Core.Entities
{
   public class ContactEntity
    {
        public string CT_Nom { get; set; }
        public string CT_Prenom { get; set; }
        public string CT_Fonction { get; set; }
        public string CT_Telephone { get; set; }
        public string CT_TelPortable { get; set; }
        public string CT_Telecopie { get; set; }
        public string CT_Email { get; set; }
        public int CT_Civilite { get; set; }
        public int N_Service { get; set; }
        public int N_Contact { get; set; }
        public DateTime cbModification { get; set; }
        public DateTime cbCreation { get; set; }
    }
}
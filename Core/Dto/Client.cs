namespace Core.Dto
{
    public class Client
    {
        public string CT_Num { get; set; }
        public string CT_Intitule { get; set; }
        public string CT_Qualite { get; set; }
        public string CT_Siret { get; set; }
        public string Email { get; set; }
        public string Portable { get; set; }
        public string Telecopie { get; set; }
        public string Telephone { get; set; }
        public string CT_Identifiant { get; set; }
        public int Civ { get; set; }
        public string Adresse { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Activated { get; set; } = "True";
    }
}
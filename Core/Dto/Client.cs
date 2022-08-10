using System.Collections.Generic;

namespace Core.Dto
{
    public class Client
    {
        public string SageCode { get; set; }
        public string Siret { get; set; }
        public string CompanyName { get; set; }
        public string LegalForm { get; set; }
        public string Naf { get; set; }
        public int LeaderCivility { get; set; }
        public string LeaderLastName { get; set; }
        public string LeaderFirstName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyMobile { get; set; }
        public string VatIdentifier { get; set; }
        public Address MainAddress { get; set; } = new Address();
        public List<Contact> Contacts { get; set; }
        public string Activated { get; set; } = "True";
    }
}
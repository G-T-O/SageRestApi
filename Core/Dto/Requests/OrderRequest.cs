using System.Collections.Generic;

namespace Core.Dto.Requests
{
    public class OrderRequest
    {
        public string SageCodeClient { get; set; }
        public List<Article> Articles { get; set; }
        public decimal TotalPaid { get; set; }
        public string Reference { get; set; }
    }
}
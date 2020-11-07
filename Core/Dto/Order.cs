using System.Collections.Generic;

namespace Core.Dto
{
    public class Order
    {
        private List<Article> _articles;
        public string CT_Num { get; set; }
        public string OrderNum { get; set; }
        public string QualCode { get; set; }
        public string DO_Date { get; set; }
        public List<Article> Articles
        {
            set { _articles = value; }
            get { return _articles; }
        }
    }
}
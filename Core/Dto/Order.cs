using System;
using System.Collections.Generic;

namespace Core.Dto
{
    public class Order
    {
        private List<DocLine> _docLines = new List<DocLine>();

        public string DO_Ref { get; set; }
        public string DO_Tiers { get; set; }
        public string CT_NumPayeur { get; set; }
        public string DO_Piece { get; set; }
        public string DO_Statut { get; set; }
        public DateTime DO_Date { get; set; }
        public DateTime DO_DateLivr { get; set; }
        public decimal DO_TotalHT { get; set; }
        public decimal DO_TotalHTNet { get; set; }
        public decimal DO_TotalTTC { get; set; }
        public decimal DO_NetAPayer { get; set; }
        public decimal DO_MontantRegle{ get; set; }
        public List<DocLine> DocLines
        {
            set { _docLines = value; }
            get { return _docLines; }
        }
    }
}
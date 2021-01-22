using System;

namespace Core.Dto
{
   public class DocLine
    {
        public byte DO_Domaine { get; set; }
        public byte DO_Type { get; set; }
        public string DO_Piece { get; set; }
        public DateTime DO_Date { get; set; }
        public string AR_Ref { get; set; }
        public string DL_Design { get; set; }
        public double DL_Qte { get; set; }
        public decimal DL_PrixUnitaire { get; set; }
        public decimal DL_Taxe1 { get; set; }
        public byte DL_TypeTaxe1 { get; set; }
        public decimal DL_PUTTC { get; set; }
        public decimal DL_MontantHT { get; set; }
        public decimal DL_MontantTTC { get; set; }
    }
}
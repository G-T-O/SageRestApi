using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
   public class Article
    {
        public string AR_Ref { get; set; }
        public string AR_Design { get; set; }
        public double ArticleQte { get; set; }
        public double AR_PrixTTC { get; set; }
        public double MontantHT { get; set; }
        public int Remise { get; set; }
    }
}

using System.Collections.Generic;

namespace Core.Dto
{
    public class Payment
    {
        public List<string> InvoiceRef { get; set; }
        public string Date { get; set; }
        public string Method { get; set; }
        public double Amount { get; set; }
        public string TransacNumber { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceApp.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Stock Name")]
        public string StockName { get; set; }
        [DisplayName("Stock Ticker")]
        public string StockTicker { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Sell Price")]
        public float SellPrice { get; set; }
        [DisplayName("Buy Price")]
        public float BuyPrice { get; set; }
        public DateTime Date { get; set; }

    }
}

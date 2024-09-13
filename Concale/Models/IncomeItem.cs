using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concale.Models
{
    public class IncomeItem
    {
        public string IncomeFile { get; set; }
        public string IncomeName { get; set; }
        public string IncomeDetail { get; set; }
        public string IncomeMoney { get; set; }

        public DateTime Date { get; set; }
    }
}

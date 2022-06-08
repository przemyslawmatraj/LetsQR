using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsQR
{
    public class LogModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Base64QR { get; set; }
        public string FullLog
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", Id, Date, Type, Base64QR);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeDbRequestsNetCore.Models
{
        public partial class cardholderUsers
        {
            public int id { get; set; }
            public string cardholderName { get; set; }
            public string cardNumber { get; set; }
            public string expDate { get; set; }
            public string cvc { get; set; }
        }

}
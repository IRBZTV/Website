using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazaar.BusinessLayer
{
    public  class ContactUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Datetime_Insert { get; set; }
        public DateTime Datetime_Check { get; set; }
        public bool Isread { get; set; }
        public string FilePath { get; set; }
        public int Kind { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
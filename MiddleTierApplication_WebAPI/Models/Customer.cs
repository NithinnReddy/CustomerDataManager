using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiddleTierApplication_WebAPI.Models
{
    public class Customer
    {
        public long Id { set; get; }

        [Required]
        public string FirstName { set; get; }

        [Required]
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }

        [Required]
        public string Zip{ set; get; }

    }
}
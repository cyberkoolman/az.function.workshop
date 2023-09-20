using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace User.API.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }
        public bool Active { get; set; }
    }
}

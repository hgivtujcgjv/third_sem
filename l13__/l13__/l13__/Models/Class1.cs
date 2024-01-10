using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace l13__.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
    }

    public class Mobile_Tariff
    {
        [Key]
        public int Id { get; set; }
        public string Name_of_Tariff { get; set; }
        public int Price { get; set; }
        public string Description { get; set;}
    }
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_of_Tariff { get; set; }
        public long Phone_Number { get; set; }
    }
}

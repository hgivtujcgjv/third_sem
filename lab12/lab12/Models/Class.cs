using System.ComponentModel.DataAnnotations;

namespace models_for_l12;

    public class users_tr
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }

    }

    public class tariffs
    {
        [Key]
        public int Id { get; set; }
        public int price { get; set; }
        public string name_of_tarif { get; set; } 
        public string description { get; set; }

    }

    public class subscribers
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string name_of_tarif { get; set; }
        public string email { get; set; }
        public int discount { get; set; }
    //https://www.youtube.com/watch?v=GNulA12ZTbI
}

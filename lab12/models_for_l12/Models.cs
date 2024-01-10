using System.ComponentModel.DataAnnotations;

namespace models_for_l12
{
    public class users_tr
    {
        [Key]
        public int Id { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }

    }

    public class Tariffs
    {
        [Key]
        public int Id { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Adminsınıf
    {
        [Key]
        public int ID { get; set; }
        public required string Kullanici { get; set; }
        public required string Sifre { get; set; }
        public string Rol { get; set; } = "Admin"; // varsayılan olarak "admin"
    }
}

using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; } 
        public string FotoUrl { get; set; }
        public string Aciklama { get; set; }
    }
}

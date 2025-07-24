using System.ComponentModel.DataAnnotations;

namespace TravelTripProje.Models.Sınıflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Mail { get; set; }
        public string? Yorum { get; set; }
        public int BlogID { get; set; }


        // public Yorumlar(int blogid) => Blogid = blogid;

        public virtual Blog Blog { get; set; }
    }
}

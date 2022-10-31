using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    public class HangHoaModel
    {
        //Inital Entities
        [Key] // Primary key
        public Guid MaHh { get; set; }
        [Required] //because string must be input
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string Mota { get; set; }
        [Range(0, double.MaxValue)] //maxvalue of double
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
    }
}

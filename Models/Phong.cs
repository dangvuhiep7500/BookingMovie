using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Phong
    {
        public Phong()
        {
            ChiTietChieus = new HashSet<ChiTietChieu>();
        }

        public int IdPhong { get; set; }
        public string TenPhong { get; set; }
        public int SoGheToiDa { get; set; }

        public virtual ICollection<ChiTietChieu> ChiTietChieus { get; set; }
    }
}

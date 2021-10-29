using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Phim
    {
        public Phim()
        {
            ChiTietChieus = new HashSet<ChiTietChieu>();
        }

        public int IdPhim { get; set; }
        public int? IdTheLoai { get; set; }
        public string TenPhim { get; set; }
        public string ThoiLuong { get; set; }
        public string Image { get; set; }

        public virtual TheLoai IdTheLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietChieu> ChiTietChieus { get; set; }
    }
}

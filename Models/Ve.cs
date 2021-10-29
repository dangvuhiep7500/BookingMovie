using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Ve
    {
        public int MaVe { get; set; }
        public int? IdUser { get; set; }
        public int? IdChiTietChieu { get; set; }
        public int? SoGhe { get; set; }

        public virtual ChiTietChieu IdChiTietChieuNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}

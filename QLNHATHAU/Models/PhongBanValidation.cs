using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNHATHAU.Models
{
    public class PhongBanValidation
    {
        [Required(ErrorMessage = "Nhập ID phòng ban")]
        public int? IDPhongBan { get; set; }

        [Required(ErrorMessage = "Nhập tên viết tắt không dấu")]
        [MaxLength(10, ErrorMessage = "vượt quá số kí tự 10")]
        public string TenVT { get; set; }

        [Required(ErrorMessage = "Nhập tên BP/NM")]
        [MaxLength(150, ErrorMessage = "vượt quá số kí tự 150")]
        public string TenDai { get; set; }
        public bool PCHN { get; set; }
    }
}
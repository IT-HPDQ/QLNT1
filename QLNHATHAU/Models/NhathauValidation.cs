using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNHATHAU.Models
{
    public class NhathauValidation
    {
        [Required(ErrorMessage = "Nhập ID nhà thầu")]
        public int? IDNhaThau { get; set; }

        [Required(ErrorMessage = "Nhập mã Customer (SAP)")]
        [MaxLength(10, ErrorMessage = "vượt quá số kí tự 10")]
        [Remote("IsAlreadyMaNT", "Contractors", HttpMethod = "POST", ErrorMessage = "Mã nhà thầu đã tồn tại.")]
        public string MaNT { get; set; }

        [Required(ErrorMessage = "Nhập mã số thuế")]
        [MaxLength(10, ErrorMessage = "vượt quá số kí tự 10")]

        [Remote("IsAlreadyMST", "Contractors", HttpMethod = "POST", ErrorMessage = "Mã số thuế đã tồn tại.")]
        public string MST { get; set; }

        [Required(ErrorMessage = "Nhập tên nhà thầu")]
        [MaxLength(250, ErrorMessage = "vượt quá số kí tự 250")]
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }

    }
}
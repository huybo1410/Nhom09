using MessagePack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nhom09.Models
{
    public class Admin
    {
        
        public int Id { get; set; }

        public string Admin_name { get; set; }

        public bool Sex { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} từ 6-20 kí tự")]
        public string Password { get; set; }
    }
}

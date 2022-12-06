using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom09.Areas.Admin.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [DisplayName("Loại sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

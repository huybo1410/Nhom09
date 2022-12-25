using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom09.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }


        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Name { get; set; }

        [DisplayName("Giá (VNĐ)")]
        [DisplayFormat(DataFormatString = "{0:n0} đ")]
        public int Price { get; set; }


        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }


        [DisplayName("Ảnh Minh Họa")]
        public string Image { get; set; }

        [DisplayName("Loại sản phẩm")]
        public int ProductTypeId { get; set; }

        // Reference navigation property cho khóa ngoại đến ProductType
        [DisplayName("Loại sản phẩm")]
        public ProductType ProductType { get; set; }

        //public List<InvoiceDetail> Invoice_Details { get; set; }
        

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public string Chip { get; set; }
        public string RAM { get; set; }
        public string ScreenSize { get; set; }

        public string Pin { get; set; }

    }
}

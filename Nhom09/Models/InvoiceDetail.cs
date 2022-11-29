using System.ComponentModel;

namespace Nhom09.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }


        [DisplayName("Sản phẩm")]
        public int ProductId { get; set; }

        // Reference navigation property cho khóa ngoại đến Product
        [DisplayName("Sản phẩm")]
        public Product Product { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Đơn giá")]
        public int Price { get; set; }

        [DisplayName("Hóa đơn")]
        public int InvoiceId { get; set; }

        // Reference navigation property cho khóa ngoại đến Invoice
        [DisplayName("Hóa đơn")]
        public Invoice Invoice { get; set; }

    }
}

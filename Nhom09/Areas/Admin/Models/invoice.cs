using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom09.Admin.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [DisplayName("Mã hóa đơn")]
        public string Code { get; set; }

        [DisplayName("Khách hàng")]
        public int CustomerId { get; set; }

        // Reference navigation property cho khóa ngoại đến Customer 
        [DisplayName("Khách hàng")]
        public Customer Customer { get; set; }

        [DisplayName("Ngày lập")]
        public DateTime Purchase_date { get; set; }


        [DisplayName("Địa chỉ giao hàng")]
        public string Address { get; set; }

        [DisplayName("SĐT giao hàng")]
        public string Phone { get; set; }

        [DisplayName("Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int Total { get; set; }

        


        public List<InvoiceDetail> Invoice_Details{ get; set; }
    }
}

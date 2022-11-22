namespace Nhom09.Models
{
    public class invoice
    {
        public int Id { get; set; }

        public DateTime Purchase_date { get; set; }

        public string Address { get; set; }

        public string Phone_number { get; set; }

        public float Total_price { get; set; }

        public string Customer_Id { get; set; }
        public customer customer { get; set; }


        public List<invoice_detail> Invoice_Details{ get; set; }
    }
}

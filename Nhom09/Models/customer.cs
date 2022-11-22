namespace Nhom09.Models
{
    public class customer
    {
        public int Id { get; set; }

        public string Customer_name { get; set; } 
        
        public string Address{ get; set; }

        public string Birthday { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool Sex { get; set; }

        public string Phone_number { get; set; }

        public List<invoice> invoices { get; set; }
    }
}

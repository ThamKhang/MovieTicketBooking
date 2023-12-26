using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    internal class User
    {
        public User() {
            chair = new List<int>();
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime BookingTime { get; set; }
        public List<int> chair { get; set; }
        public string CalculatorFormatted
        {
            get
            {
                int totalAmount = chair.Count * 100000;
                return totalAmount.ToString("C0", new System.Globalization.CultureInfo("vi-VN"));
            }
        }
        public override string ToString()
        {
            return Name +" - "+ Phone;
        }

    }
}

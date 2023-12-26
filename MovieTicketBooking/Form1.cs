using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;
using System.Reflection.Metadata;

namespace MovieTicketBooking
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();
            handle100chairs();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            if (userInfo.ShowDialog() == DialogResult.OK)
            {
                User user = new User();
                user.Name = userInfo.textBox1.Text;
                user.Phone = userInfo.textBox2.Text;
                user.BookingTime = DateTime.Now;
                for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
                {
                    Label lbl = tableLayoutPanel1.Controls[i] as Label;
                    if (lbl != null && lbl.BackColor == Color.Green)
                    {
                        lbl.BackColor = Color.Yellow;
                        int seat = int.Parse(lbl.Text);
                        user.chair.Add(seat);
                    }
                }
                label8.Text = user.CalculatorFormatted;
                users.Add(user);
                TotalShow();
                UserShow();
            }
        }

        private void UserShow()
        {
            listBox1.Items.Clear();
            foreach (User user in users)
                listBox1.Items.Add(user);
        }

        private void TotalShow()
        {
            int total = 0;
            foreach (User user in users)
            {
                total += int.Parse(user.CalculatorFormatted, NumberStyles.Currency, new CultureInfo("vi-VN"));
            }
            label9.Text = total.ToString("C0", new CultureInfo("vi-VN"));
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void handle100chairs()
        {
            tableLayoutPanel1.Controls.Clear();
            int numCols = tableLayoutPanel1.ColumnCount;
            int numRows = tableLayoutPanel1.RowCount;
            int chair = 1;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Label lbl = new Label();
                    lbl.Text = chair.ToString();
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.Fill;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Width = 50;
                    lbl.BackColor = Color.White;
                    lbl.Click += SeatLabel_Click;
                    tableLayoutPanel1.Controls.Add(lbl, col, row);
                    chair++;
                }
            }
        }
        private void SeatLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                // Toggle between White (empty) and Green (selected)
                if (clickedLabel.BackColor == Color.White)
                {
                    clickedLabel.BackColor = Color.Green;
                }
                else if (clickedLabel.BackColor == Color.Green)
                {
                    clickedLabel.BackColor = Color.White;
                }
                else if (clickedLabel.BackColor == Color.Yellow)
                {
                    MessageBox.Show("Seat [" + clickedLabel.Text + "] has already been reserved");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0)
            {
                User user = listBox1.SelectedItem as User;
                label8.Text = user.CalculatorFormatted;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                User user1 = listBox1.SelectedItem as User;
                List<int> seatsToRemove = new List<int>();

                for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
                {
                    Label lbl = tableLayoutPanel1.Controls[i] as Label;
                    int number = int.Parse(lbl.Text);

                    if (user1.chair.Contains(number))
                    {
                        lbl.BackColor = Color.White;
                        seatsToRemove.Add(number);
                    }
                }

                foreach (int seat in seatsToRemove)
                {
                    user1.chair.Remove(seat);
                }

                users.Remove(user1);
                UserShow();
            }
        }

    }
}

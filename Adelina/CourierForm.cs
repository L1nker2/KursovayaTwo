using System.Data;
namespace Adelina
{
    public partial class CourierForm : Form
    {
        public string id;
        public void LoadData()
        {
            using (SqlDbContext context = new())
            {
                var couriers = context.Couriers.ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер курьера", typeof(int));
                dataTable.Columns.Add("Имя курьера", typeof(string));
                dataTable.Columns.Add("Фамилия курьера", typeof(string));
                dataTable.Columns.Add("Телефон курьера", typeof(string));
                foreach (var courier in couriers)
                {
                    dataTable.Rows.Add(courier.courierId, courier.courierFirstName, courier.courierSecondName, courier.courierPhone);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        public CourierForm()
        {
            InitializeComponent();
            LoadData();
            panel1.Visible = false;
            panel2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Location = new Point(22, 497);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер курьера"].Value.ToString();
                Methods.DeleteCourier(int.Parse(id));
                LoadData();
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.Location = new Point(22, 497);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер курьера"].Value.ToString();
                var fname = row.Cells["Имя курьера"].Value.ToString();
                var sname = row.Cells["Фамилия курьера"].Value.ToString();
                var phone = row.Cells["Телефон курьера"].Value.ToString();
                textBox6.Text = fname;
                textBox9.Text = sname;
                textBox8.Text = phone;
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var findvalue = textBox1.Text;
            if (findvalue == "")
            {
                MessageBox.Show("Пустое поле поиска");
                return;
            }
            using (SqlDbContext context = new())
            {
                List<Courier> rows = context.Couriers.Where(t => t.courierFirstName == findvalue || t.courierSecondName == findvalue || t.courierPhone == findvalue).ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер курьера", typeof(int));
                dataTable.Columns.Add("Имя курьера", typeof(string));
                dataTable.Columns.Add("Фамилия курьера", typeof(string));
                dataTable.Columns.Add("Телефон курьера", typeof(string));
                foreach (var courier in rows)
                {
                    dataTable.Rows.Add(courier.courierId, courier.courierFirstName, courier.courierSecondName, courier.courierPhone);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var fname = textBox5.Text;
            var sname = textBox2.Text;
            var phone = textBox3.Text;
            if (fname == "" || sname == "" || phone == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Methods.AddCourier(fname, sname, phone);
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            panel1.Visible = false;
            LoadData();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var fname = textBox6.Text;
            var sname = textBox9.Text;
            var phone = textBox8.Text;
            if (fname == "" || sname == "" || phone == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Methods.EditCourier(int.Parse(id), fname, sname, phone);
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            panel2.Visible = false;
            LoadData();
        }
    }
}

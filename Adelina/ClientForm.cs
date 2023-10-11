using System.Data;
namespace Adelina
{
    public partial class ClientForm : Form
    {
        public string id;
        public void LoadData()
        {
            using (SqlDbContext context = new())
            {
                var clients = context.Clients.ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер клиента", typeof(int));
                dataTable.Columns.Add("Имя клиента", typeof(string));
                dataTable.Columns.Add("Фамилия клиента", typeof(string));
                dataTable.Columns.Add("Телефон клиента", typeof(string));
                dataTable.Columns.Add("Адресс клиента", typeof(string));
                foreach (var client in clients)
                {
                    dataTable.Rows.Add(client.clientId, client.clientFirstName, client.clientSecondName, client.clientPhone, client.clientAddress);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        public ClientForm()
        {
            InitializeComponent();
            LoadData();
            panel1.Visible = false;
            panel2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Location = new Point(20, 460);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                var id = row.Cells["Номер клиента"].Value.ToString();
                Methods.DeleteClient(int.Parse(id));
                LoadData();
            }
            else MessageBox.Show("Неоюходимо выбрать запись");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.Location = new Point(20, 460);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер клиента"].Value.ToString();
                var fname = row.Cells["Имя клиента"].Value.ToString();
                var sname = row.Cells["Фамилия клиента"].Value.ToString();
                var phone = row.Cells["Телефон клиента"].Value.ToString();
                var address = row.Cells["Адресс клиента"].Value.ToString();
                textBox6.Text = fname;
                textBox9.Text = sname;
                textBox8.Text = phone;
                textBox7.Text = address;
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var findvalue = textBox1.Text;
            if(findvalue == "")
            {
                MessageBox.Show("Пустое поле поиска");
                return;
            }
            using (SqlDbContext context = new())
            {
                List<Client> rows = context.Clients.Where(t => t.clientFirstName == findvalue || t.clientSecondName == findvalue || t.clientAddress == findvalue || t.clientPhone == findvalue).ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер клиента", typeof(int));
                dataTable.Columns.Add("Имя клиента", typeof(string));
                dataTable.Columns.Add("Фамилия клиента", typeof(string));
                dataTable.Columns.Add("Телефон клиента", typeof(string));
                dataTable.Columns.Add("Адресс клиента", typeof(string));
                foreach (var client in rows)
                {
                    dataTable.Rows.Add(client.clientId, client.clientFirstName, client.clientSecondName, client.clientPhone, client.clientAddress);
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
            var address = textBox4.Text;
            if (fname == "" || sname == "" || phone == "" || address == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Methods.AddClient(fname, sname, phone, address);
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
            var address = textBox7.Text;
            if (fname == "" || sname == "" || phone == "" || address == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Methods.EditClient(int.Parse(id), fname, sname, phone, address);
            textBox6.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            panel2.Visible = false;
            LoadData();
        }
    }
}

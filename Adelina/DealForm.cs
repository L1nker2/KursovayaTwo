using System.Data;

namespace Adelina
{
    public partial class DealForm : Form
    {
        public string id;
        public void LoadCB()
        {
            using (SqlDbContext context = new())
            {
                var products = context.Products.ToList();
                var couriers = context.Couriers.ToList();
                var clients = context.Clients.ToList();
                foreach (var product in products)
                {
                    comboBox1.Items.Add(product.productName);
                    comboBox6.Items.Add(product.productName);
                }
                foreach (var courier in couriers)
                {
                    comboBox2.Items.Add(courier.courierFirstName + " " + courier.courierSecondName);
                    comboBox5.Items.Add(courier.courierFirstName + " " + courier.courierSecondName);
                }
                foreach (var client in clients)
                {
                    comboBox3.Items.Add(client.clientFirstName + " " + client.clientSecondName);
                    comboBox4.Items.Add(client.clientFirstName + " " + client.clientSecondName);
                }
            }
        }
        public void LoadData()
        {
            using (SqlDbContext context = new())
            {
                var deals = context.Deals.ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер сделки", typeof(int));
                dataTable.Columns.Add("Продукт", typeof(string));
                dataTable.Columns.Add("Курьер", typeof(string));
                dataTable.Columns.Add("Клиент", typeof(string));
                foreach (var deal in deals)
                {
                    var product = context.Products.FirstOrDefault(el => el.productId == deal.productId);
                    var courier = context.Couriers.FirstOrDefault(el => el.courierId == deal.courierId);
                    var client = context.Clients.FirstOrDefault(el => el.clientId == deal.clientId);
                    dataTable.Rows.Add(deal.dealId, product.productName, courier.courierFirstName + " " + courier.courierSecondName, client.clientFirstName + " " + client.clientSecondName);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        public DealForm()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            LoadData();
            LoadCB();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Location = new Point(12, 502);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер сделки"].Value.ToString();
                Methods.DeleteDeal(int.Parse(id));
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
                panel2.Location = new Point(22, 502);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер сделки"].Value.ToString();
                var product = row.Cells["Продукт"].Value.ToString();
                var courier = row.Cells["Курьер"].Value.ToString();
                var client = row.Cells["Клиент"].Value.ToString();
                comboBox6.SelectedItem = product;
                comboBox5.SelectedItem = courier;
                comboBox4.SelectedItem = client;
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var _product = comboBox1.SelectedItem.ToString();
            var _courier = comboBox2.SelectedItem.ToString().Split();
            var _client = comboBox3.SelectedItem.ToString().Split();
            using (SqlDbContext context = new())
            {
                var product = context.Products.FirstOrDefault(el => el.productName == _product);
                var courier = context.Couriers.FirstOrDefault(el => el.courierFirstName == _courier[0] && el.courierSecondName == _courier[1]);
                var client = context.Clients.FirstOrDefault(el => el.clientFirstName == _client[0] && el.clientSecondName == _client[1]);
                Methods.AddDeal(product.productId, courier.courierId, client.clientId);
            }
            panel1.Visible = false;
            LoadData();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var _product = comboBox1.SelectedItem.ToString();
            var _courier = comboBox2.SelectedItem.ToString().Split();
            var _client = comboBox3.SelectedItem.ToString().Split();
            using (SqlDbContext context = new())
            {
                var product = context.Products.FirstOrDefault(el => el.productName == _product);
                var courier = context.Couriers.FirstOrDefault(el => el.courierFirstName == _courier[0] && el.courierSecondName == _courier[1]);
                var client = context.Clients.FirstOrDefault(el => el.clientFirstName == _client[0] && el.clientSecondName == _client[1]);
                Methods.EditDeal(int.Parse(id), product.productId, courier.courierId, client.clientId);
            }
            panel2.Visible = false;
            LoadData();
        }
    }
}

using System.Data;
namespace Adelina
{
    public partial class ProductForm : Form
    {
        public string id;
        public void LoadData()
        {
            using (SqlDbContext context = new())
            {
                var products = context.Products.ToList();
                var providers = context.Providers.ToList();
                foreach (var provider in providers)
                {
                    comboBox1.Items.Add(provider.providerName);
                    comboBox2.Items.Add(provider.providerName);
                }
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер товара", typeof(int));
                dataTable.Columns.Add("Название поставщика", typeof(string));
                dataTable.Columns.Add("Название товара", typeof(string));
                dataTable.Columns.Add("Цена товара", typeof(string));
                foreach (var product in products)
                {
                    var provider = context.Providers.FirstOrDefault(el => el.providerId == product.providerId);
                    dataTable.Rows.Add(product.productId, provider.providerName, product.productName, product.productPrice);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        public ProductForm()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            LoadData();
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
                id = row.Cells["Номер товара"].Value.ToString();
                Methods.DeleteProduct(int.Parse(id));
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
                id = row.Cells["Номер товара"].Value.ToString();
                var provider = row.Cells["Название поставщика"].Value.ToString();
                var productname = row.Cells["Название товара"].Value.ToString();
                var price = row.Cells["Цена товара"].Value.ToString();
                textBox6.Text = productname;
                textBox8.Text = price;
                comboBox2.SelectedItem = provider;
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string findvalue = textBox1.Text;
            if (findvalue == "")
            {
                MessageBox.Show("Пустое поле поиска");
                return;
            }
            using (SqlDbContext context = new())
            {
                List<Product> rows = context.Products.Where(t => t.productName == findvalue || t.productPrice == findvalue).ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер товара", typeof(int));
                dataTable.Columns.Add("Название поставщика", typeof(string));
                dataTable.Columns.Add("Название товара", typeof(string));
                dataTable.Columns.Add("Цена товара", typeof(string));
                foreach (var product in rows)
                {
                    var provider = context.Providers.FirstOrDefault(el => el.providerId == product.providerId);
                    dataTable.Rows.Add(product.productId, provider.providerName, product.productName, product.productPrice);
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
            var providername = comboBox1.SelectedItem.ToString();
            var productname = textBox5.Text;
            var price = textBox3.Text;
            if (productname == "" || price == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            using (SqlDbContext context = new())
            {
                var provider = context.Providers.FirstOrDefault(el => el.providerName == providername);
                Methods.AddProduct(productname, price, provider.providerId);
            }
            textBox5.Text = "";
            textBox3.Text = "";
            panel1.Visible = false;
            LoadData();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var providername = comboBox2.SelectedItem.ToString();
            var productname = textBox6.Text;
            var price = textBox8.Text;
            if (productname == "" || price == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            using(SqlDbContext context = new())
            {
                var provider = context.Providers.FirstOrDefault(el => el.providerName == providername);
                Methods.EditProduct(int.Parse(id), productname, price, provider.providerId);
            }
            textBox6.Text = "";
            textBox8.Text = "";
            panel2.Visible = false;
            LoadData();
        }
    }
}

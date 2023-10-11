using System.Data;
namespace Adelina
{
    public partial class ProviderForm : Form
    {
        public string id;
        public void LoadData()
        {
            using (SqlDbContext context = new())
            {
                var providers = context.Providers.ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер поставщика", typeof(int));
                dataTable.Columns.Add("Название поставщика", typeof(string));
                dataTable.Columns.Add("Телефон поставщика", typeof(string));
                foreach (var provider in providers)
                {
                    dataTable.Rows.Add(provider.providerId, provider.providerName, provider.providerPhone);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
            }
        }
        public ProviderForm()
        {
            InitializeComponent();
            LoadData();
            panel1.Visible = false;
            panel2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Location = new Point(22, 538);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер поставщика"].Value.ToString();
                Methods.DeleteProvider(int.Parse(id));
            }
            else MessageBox.Show("Необходимо выбрать запись");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.Location = new Point(22, 538);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                id = row.Cells["Номер поставщика"].Value.ToString();
                var name = row.Cells["Название поставщика"].Value.ToString();
                var phone = row.Cells["Телефон поставщика"].Value.ToString();
                textBox6.Text = name;
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
                List<Provider> rows = context.Providers.Where(t => t.providerName == findvalue || t.providerPhone == findvalue).ToList();
                DataTable dataTable = new();
                dataTable.Columns.Add("Номер поставщика", typeof(int));
                dataTable.Columns.Add("Название поставщика", typeof(string));
                dataTable.Columns.Add("Телефон поставщика", typeof(string));
                foreach (var provider in rows)
                {
                    dataTable.Rows.Add(provider.providerId, provider.providerName, provider.providerPhone);
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
            var name = textBox5.Text;
            var phone = textBox3.Text;
            if (name == "" || phone == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            Methods.AddProvider(name, phone);
            textBox3.Text = "";
            textBox5.Text = "";
            panel1.Visible = false;
            LoadData();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var name = textBox6.Text;
            var phone = textBox8.Text;
            if(name == "" || phone == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }
            Methods.EditProvider(int.Parse(id), name, phone);
            textBox6.Text = "";
            textBox8.Text = "";
            panel2.Visible = false;
            LoadData();
        }
    }
}

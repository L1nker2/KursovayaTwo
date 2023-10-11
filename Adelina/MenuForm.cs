namespace Adelina
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClientForm f = new();
            f.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CourierForm f = new();
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProviderForm f = new();
            f.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ProductForm f = new();
            f.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DealForm f = new();
            f.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсовую работу выполнил студент группы 404-ИС\n... Аделина ...");
        }
    }
}

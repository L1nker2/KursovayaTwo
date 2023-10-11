using Microsoft.EntityFrameworkCore;

namespace Adelina
{
    public class Provider
    {
        public int providerId { get; set; }
        public string providerName { get; set; }
        public string providerPhone { get; set; }
    }
    public class Client
    {
        public int clientId { get; set; }
        public string clientFirstName { get; set; }
        public string clientSecondName { get; set; }
        public string clientPhone { get; set; }
        public string clientAddress { get; set; }
    }
    public class Courier
    {
        public int courierId { get; set; }
        public string courierFirstName { get; set; }
        public string courierSecondName { get; set; }
        public string courierPhone { get; set; }
    }
    public class Product
    {
        public int productId { get; set; }
        public int providerId { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
    }
    public class Deal
    {
        public int dealId { get; set; }
        public int productId { get; set; }
        public int courierId { get; set; }
        public int clientId { get; set; }
    }
    public class SqlDbContext : DbContext
    {
        public static string sqlstr = "";//сюда впиши строку подключения к файлу Adelina.mdf
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Deal> Deals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlstr);
        }
    }
    static public class Methods
    {
        #region Providers
        public static void AddProvider(string _Name, string _Phone)
        {
            using (SqlDbContext context = new())
            {
                Provider provider = new()
                {
                    providerName = _Name,
                    providerPhone = _Phone
                };
                context.Providers.Add(provider);
                context.SaveChanges();
                MessageBox.Show("Provider added");
            }
        }
        public static void DeleteProvider(int _Id)
        {
            using (SqlDbContext context = new())
            {
                var provider = context.Providers.FirstOrDefault(el => el.providerId == _Id);
                if (provider != null)
                {
                    context.Providers.Remove(provider);
                    context.SaveChanges();
                    MessageBox.Show("Provider deleted");
                }
                else MessageBox.Show("Error provider is null");
            }
        }
        public static void EditProvider(int _Id, string _Name, string _Phone)
        {
            using (SqlDbContext context = new())
            {
                var provider = context.Providers.FirstOrDefault(el => el.providerId == _Id);
                if(provider != null)
                {
                    provider.providerName = _Name;
                    provider.providerPhone = _Phone;
                    context.SaveChanges();
                    MessageBox.Show("Provider edited");
                }
                else MessageBox.Show("Error provider is null");
            }
        }
        #endregion
        #region Clients
        public static void AddClient(string _fName, string _sName, string _Phone, string _Address)
        {
            using (SqlDbContext context = new())
            {
                Client client = new()
                {
                    clientFirstName = _fName,
                    clientSecondName = _sName,
                    clientPhone = _Phone,
                    clientAddress = _Address
                };
                context.Clients.Add(client);
                context.SaveChanges();
                MessageBox.Show("Client added");
            }
        }
        public static void DeleteClient(int _Id)
        {
            using (SqlDbContext context = new())
            {
                var client = context.Clients.FirstOrDefault(el => el.clientId == _Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                    MessageBox.Show("Client deleted");
                }
                else MessageBox.Show("Error client is null");
            }
        }
        public static void EditClient(int _Id, string _fName, string _sName, string _Phone, string _Address)
        {
            using (SqlDbContext context = new())
            {
                var client = context.Clients.FirstOrDefault(el => el.clientId == _Id);
                if (client != null)
                {
                    client.clientFirstName = _fName;
                    client.clientSecondName = _sName;
                    client.clientPhone = _Phone;
                    client.clientAddress = _Address;
                    context.SaveChanges();
                    MessageBox.Show("Client edited");
                }
                else MessageBox.Show("Error client is null");
            }
        }
        #endregion
        #region Couriers
        public static void AddCourier(string _fName, string _sName, string _Phone)
        {
            using (SqlDbContext context = new())
            {
                Courier courier = new()
                {
                    courierFirstName = _fName,
                    courierSecondName = _sName,
                    courierPhone = _Phone
                };
                context.Couriers.Add(courier);
                context.SaveChanges();
                MessageBox.Show("Courier added");
            }
        }
        public static void DeleteCourier(int _Id)
        {
            using (SqlDbContext context = new())
            {
                var courier = context.Couriers.FirstOrDefault(el => el.courierId == _Id);
                if (courier != null)
                {
                    context.Couriers.Remove(courier);
                    context.SaveChanges();
                    MessageBox.Show("Courier deleted");
                }
                else MessageBox.Show("Error courier is null");
            }
        }
        public static void EditCourier(int _Id, string _fName, string _sName, string _Phone)
        {
            using (SqlDbContext context = new())
            {
                var courier = context.Couriers.FirstOrDefault(el => el.courierId == _Id);
                if (courier != null)
                {
                    courier.courierFirstName = _fName;
                    courier.courierSecondName = _sName;
                    courier.courierPhone = _Phone;
                    context.SaveChanges();
                    MessageBox.Show("Courier edited");
                }
                else MessageBox.Show("Error courier is null");
            }
        }
        #endregion
        #region Products
        public static void AddProduct(string _Name, string _Price, int _providerId)
        {
            using (SqlDbContext context = new())
            {
                Product product = new()
                {
                    productName = _Name,
                    productPrice = _Price,
                    providerId = _providerId
                };
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Product added");
            }
        }
        public static void DeleteProduct(int _Id)
        {
            using (SqlDbContext context = new())
            {
                var product = context.Products.FirstOrDefault(el => el.productId == _Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    MessageBox.Show("Product deleted");
                }
                else MessageBox.Show("Error product is null");
            }
        }
        public static void EditProduct(int _Id, string _Name, string _Price, int _providerId)
        {
            using (SqlDbContext context = new())
            {
                var product = context.Products.FirstOrDefault(el => el.productId == _Id);
                if (product != null)
                {
                    product.productName = _Name;
                    product.productPrice = _Price;
                    product.providerId = _providerId;
                    context.SaveChanges();
                    MessageBox.Show("Product edited");
                }
                else MessageBox.Show("Error product is null");
            }
        }
        #endregion
        #region Deals
        public static void AddDeal(int _productId, int _courierId, int _clientId)
        {
            using(SqlDbContext context = new())
            {
                Deal deal = new()
                {
                    productId = _productId,
                    courierId = _courierId,
                    clientId = _clientId
                };
                context.Deals.Add(deal);
                context.SaveChanges();
                MessageBox.Show("Deal added");
            }
        }
        public static void DeleteDeal(int _dealId)
        {
            using(SqlDbContext context = new())
            {
                var deal = context.Deals.FirstOrDefault(el => el.dealId == _dealId);
                if (deal != null)
                {
                    context.Deals.Remove(deal);
                    context.SaveChanges();
                    MessageBox.Show("Deal deleted");
                }
                else MessageBox.Show("Error deal is null");
            }
        }
        public static void EditDeal(int _dealId, int _productId, int _courierId, int _clientId)
        {
            using(SqlDbContext context = new())
            {
                var deal = context.Deals.FirstOrDefault(el => el.dealId == _dealId);
                if (deal != null)
                {
                    deal.productId = _productId;
                    deal.courierId = _courierId;
                    deal.clientId = _courierId;
                    context.SaveChanges();
                    MessageBox.Show("Deal edited");
                }
                else MessageBox.Show("Error deal is null");
            }
        }
        #endregion
    }
}
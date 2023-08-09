using BLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        private string _img;
        private string _name;
        private string _describe;
        private string _color;
        private string _size;
        private string _category;
        private double _price;
        private int _inventory;
        private double _discount;

        public Product()
        {
            discount = 0;
            price = 0;
            inventory = 0;
            describe = "";
        }
        public Product(string img, string name, string describe, string color, string size, double price, int inventory, double discount , string category)
        {
            this.img = img;
            this._name = name;
            this.describe = describe;
            this._color = color;
            this._size = size;
            this.price = price;
            this.inventory = inventory;
            this.discount = discount;
            this.category = category;
        }
        public Product(JToken jToken)
        {
            this.img = jToken["img"].ToString();
            this._name = jToken["name"].ToString();
            this.describe = jToken["describe"].ToString();
            this.category = jToken["category"].ToString();
            this._color = jToken["color"].ToString();
            this._size = jToken["size"].ToString();
            this.price = double.Parse(jToken["price"].ToString());
            this.inventory = int.Parse(jToken["inventory"].ToString());
            this.discount = double.Parse(jToken["discount"].ToString());
        }
        public string color { get => _color; }
        public string size { get => _size; }
        public string name { get => _name; }
        public string describe { get => _describe; set => _describe = value; }
        public string category { get => _category; set => _category = value; }
        public string img { get => _img; set => _img = value; }
        public double price { get => _price; set => _price = value; }
        public int inventory { get => _inventory; set => _inventory = value; }
        public double discount { get => _discount; set => _discount = value; }
        #region Method Private
        private static List<Product> ConvertJTokenToDTO(JToken jToken)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < jToken.Count(); i++)
            {
                products.Add(new Product(jToken[i]));
            }
            return products;
        }
        #endregion

        #region Method Public
        public async void Delete()
        {
            await CRUD.Instance.Delete(this);
        }
        public async void Update()
        {
            await CRUD.Instance.Update(this);
        }
        public async void Create()
        {
            await CRUD.Instance.Create(this);
        }
        #endregion

        #region Method Static
        public static async Task<Product> FindOne(string name , string color , string size)
        {
            return null;
        }

        public static async Task<List<Product>> FindAll()
        {
            try
            {
                JToken jToken = await CRUD.Instance.FindAll(new Product());
                return ConvertJTokenToDTO(jToken);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static async Task<List<Product>> FindProductGroupbyName()
        {
            Product_BLL bll = new Product_BLL();
            JToken res = await bll.FindProductGroupbyName();
            return ConvertJTokenToDTO(res);
        }
        public static async Task<string[]> FindCategory()
        {
            Product_BLL bll = new Product_BLL();
            JToken res = await bll.FindCategory();
            string[] categorys = new string[res.Count()];
            for (int i = 0; i < categorys.Length; i++)
            {
                categorys[i] = res[i]["category"].ToString();
            }
            return categorys;
        }
        public static async Task<List<Product>> findProductByCategory(string category)
        {
            Product_BLL bll = new Product_BLL();
            JToken res = await bll.FindProductByCategory(category);
            return ConvertJTokenToDTO(res);
        }
        public static async Task<List<Product>> FindProductByName(string name)
        {
            Product_BLL bll = new Product_BLL();
            JToken res = await bll.FindProductByName(name);
            return ConvertJTokenToDTO(res);
        }
        public static async Task<List<Product>> FindProductByWord(string word)
        {
            Product_BLL bll = new Product_BLL();
            JToken res = await bll.FindProductByWord(word);
            return ConvertJTokenToDTO(res);
        }
        #endregion
    }
}

using BLL;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillingDetails
    {
        private int _id;
        private string _idBill;
        private string _nameProduct;
        private string _sizeProduct;
        private string _colorProduct;
        private double _price;
        private int _quantity;

        public BillingDetails(string idBill, string nameProduct, string sizeProduct, string colorProduct, double price, int quantity)
        {   
            this.idBill = idBill;
            this.nameProduct = nameProduct;
            this.sizeProduct = sizeProduct;
            this.colorProduct = colorProduct;
            this.price = price;
            this.quantity = quantity;
        }
        public BillingDetails(JToken jToken)
        {
            this._id = int.Parse(jToken["id"].ToString());
            this.idBill = jToken["idBill"].ToString();
            this.nameProduct = jToken["nameProduct"].ToString();
            this.sizeProduct = jToken["sizeProduct"].ToString();
            this.colorProduct = jToken["colorProduct"].ToString();
            this.price = double.Parse(jToken["price"].ToString());
            this.quantity = int.Parse(jToken["quantity"].ToString());
        }

        public BillingDetails()
        {
           
        }

        public int id { get => _id; }
        public string idBill { get => _idBill;
            set 
            { 
                if (value.Length > 10) { throw new Exception("Fail"); }
                _idBill = value;
            }
        }
        public string nameProduct { get => _nameProduct; set => _nameProduct = value; }
        public string sizeProduct { get => _sizeProduct; set => _sizeProduct = value; }
        public string colorProduct { get => _colorProduct; set => _colorProduct = value; }
        public double price { get => _price; 
            set 
            {
                if (value <= 0) { throw new Exception("Fail"); }
                _price = value;
            } 
        }
        public int quantity { get => _quantity;
            set
            {
                if (value <= 0) { throw new Exception("Fail"); }
                _quantity = value;
            }
        }
        #region Method Private
        private static List<BillingDetails> ConvertJTokenToDTO(JToken jToken)
        {
            List<BillingDetails> bills = new List<BillingDetails>();
            for (int i = 0; i < jToken.Count(); i++)
            {
                bills.Add(new BillingDetails(jToken[i]));
            }
            return bills;
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
        public static async Task<Bill> FindOne(int id)
        {
           if(id < 0) { throw new ArgumentOutOfRangeException("id"); }
            return null;
        }
        public static async Task<List<BillingDetails>> FindAll()
        {
            JToken jToken = await CRUD.Instance.FindAll(new BillingDetails());
            return ConvertJTokenToDTO(jToken);
        }
        public static async Task<List<BillingDetails>> FindBillingDetailsByIdBill(string idbill)
        {
            if (idbill.Length > 10 | idbill.Length == 0) { throw new Exception("Fail"); }
            BillingDetails_BLL bll = new BillingDetails_BLL();
            JToken jToken = await bll.FindBillingDetailsByIdBill(idbill);
            return ConvertJTokenToDTO(jToken);
        }
        #endregion
    }
}

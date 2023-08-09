using BLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        private string _id;
        private string _status;
        private DateTime _date;
        private double _discount;
        private string _note;
        public Bill(string id = null) {
            _id = id != null ? id:GenerateRandomString(10);
            if (_id.Length > 10) { throw new Exception("Fail"); }
            status = "unpaid";
            date = DateTime.Now;
            discount = 0;
            note = "";
        }
        public Bill(string id, string status, DateTime date, double discount, string note)
        {
            if(id.Length > 10) { throw new Exception("Fail"); }
            if(discount < 0) { throw new Exception("Fail"); }
            _id = id;
            this.status = status;
            this.date = date;
            this.discount = discount;
            this.note = note;
        }
        public Bill(JToken jToken)
        {
            _id =jToken["id"].ToString();
            status = jToken["status"].ToString();
            date = DateTime.Parse(jToken["date"].ToString());
            discount = double.Parse(jToken["discount"].ToString());
            note = jToken["note"].ToString();
        }
        public string id { get => _id;}
        public string status { get => _status; set => _status = value; }
        public DateTime date { get => _date; set => _date = value; }
        public double discount { get => _discount; set => _discount = value; }
        public string note { get => _note; set => _note = value; }
        public Task<List<BillingDetails>> billingDetails()
        {
            return BillingDetails.FindBillingDetailsByIdBill(this.id);
        }
        #region Method Private
        private static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
        private static List<Bill> ConvertJTokenToDTO(JToken jToken)
        {
            List<Bill> bills = new List<Bill>();
            for (int i = 0; i < jToken.Count(); i++)
            {
                bills.Add(new Bill(jToken[i]));
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
        public static async Task<Bill> FindOne(string id)
        {
            if (id.Length > 10 | id.Length == 0) { throw new Exception("Fail"); }
            return null;
        }
        public static async Task<List<Bill>> FindAll()
        {
            JToken jToken = await CRUD.Instance.FindAll(new Bill());
            return ConvertJTokenToDTO(jToken);
        }
       
        public static async Task<List<Bill>> FindAllBillByStatus(string status)
        {
            if(status == null) { throw new ArgumentNullException("status"); }
            Bill_BLL bll = new Bill_BLL();
            JToken jToken = await bll.FindAllBillByStatus(status);
            return ConvertJTokenToDTO(jToken);
        }
        #endregion
    }
}

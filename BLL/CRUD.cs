using BLL.Interface;
using DAL;
using DAL.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CRUD : ICRUD
    {
        private static CRUD instance;
        public static CRUD Instance
        {
            get { if (instance == null) { instance = new CRUD(); } return CRUD.instance; }
            private set { CRUD.instance = value; }
        }
        private CRUD() { }
        private ICRUD_DAL cRUD_DAL(object obj)
        {
            ICRUD_DAL dal;
            string objType = obj.GetType().Name;
            switch (objType)
            {
                case "Bill":
                    {
                        dal = new Bill_DAL();
                        break;
                    }
                case "BillingDetails":
                    {
                        dal = new BillingDetails_DAL();
                        break;
                    }
                case "Product":
                    {
                        dal = new Product_DAL();
                        break;
                    }
                default: { throw new ArgumentOutOfRangeException(nameof(objType), $"Chưa thiết lập case {objType} tại lớp CRUD"); }
            }
            return dal;
        }
        public async Task<JToken> FindAll(object obj)
        {
            ICRUD_DAL dal = cRUD_DAL(obj);
            object data = await dal.findAll();
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> Create(object obj)
        {
            ICRUD_DAL dal = cRUD_DAL(obj);
            object data = await dal.Create(obj);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken; 
        }
        public async Task<JToken> Delete(object obj)
        {
            ICRUD_DAL dal = cRUD_DAL(obj);
            object data = await dal.Delete(obj);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> Update(object obj)
        {
            ICRUD_DAL dal = cRUD_DAL(obj);
            object data = await dal.Update(obj);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
    }
}

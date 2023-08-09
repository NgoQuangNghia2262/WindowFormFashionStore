using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillingDetails_DAL : ICRUD_DAL
    {
        public async Task<object> Create(object obj)
        {
            string url = "http://localhost:8080/v1/data/billingdetails/create";
            dynamic res = await fetch.Instance.Post(url, obj);
            if (res["status"] == "200")
            {
                return res["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }

        public async Task<object> Delete(dynamic obj)
        {
            string url = $"http://localhost:8080/v1/data/billingdetails/delete/{obj.id}";
            dynamic res = await fetch.Instance.Delete(url, null);
            if (res["status"] == "200")
            {
                return res["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }

        public async Task<object> findAll()
        {
            string url = $"http://localhost:8080/v1/data/billingdetails/findall";
            dynamic obj = await fetch.Instance.Get(url);
            if (obj["status"] == "200")
            {
                return obj["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }
        public async Task<object> FindBillingDetailsByIdBill(string idbill) 
        {
            string url = $"http://localhost:8080/v1/data/billingdetails/findBillingDetailsByIdBill?idbill={idbill}";
            dynamic obj = await fetch.Instance.Get(url);
            if (obj["status"] == "200")
            {
                return obj["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }

        public async Task<object> FindOne(dynamic obj)
        {
            string url = $"http://localhost:8080/v1/data/billingdetails/findone/{obj.id}";
            dynamic res = await fetch.Instance.Get(url);
            if (res["status"] == "200")
            {
                return res["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }

        public async Task<object> Update(dynamic obj)
        {
            string url = $"http://localhost:8080/v1/data/billingdetails/upadte";
            dynamic res = await fetch.Instance.Put(url, obj);
            if (res["status"] == "200")
            {
                return res["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }
    }
}

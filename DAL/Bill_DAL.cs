using DAL.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bill_DAL : ICRUD_DAL
    {
        public async Task<object> findAll()
        {
            string url = "http://localhost:8080/v1/data/bill/findall";
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
        public async Task<object> findAll(string status)
        {
            string url = $"http://localhost:8080/v1/data/bill/findall?status={status}"; 
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
        public async Task<object> Create(object obj)
        {
            string url = "http://localhost:8080/v1/data/bill/create";
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
            string url = $"http://localhost:8080/v1/data/bill/delete/{obj.id}";
            dynamic res = await fetch.Instance.Delete(url,null);
            if (res["status"] == "200")
            {
                return res["data"];
            }
            else
            {
                throw new Exception("Fail");
            }
        }

        public async Task<object> FindOne(dynamic obj)
        {
            string url = $"http://localhost:8080/v1/data/bill/findone/{obj.id}";
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
            string url = $"http://localhost:8080/v1/data/bill/update";
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

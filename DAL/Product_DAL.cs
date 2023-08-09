using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class Product_DAL : ICRUD_DAL
    {
        public async Task<object> Create(object obj)
        {
            string url = "http://localhost:8080/v1/data/product/create";
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
            string url = $"http://localhost:8080/v1/data/product/delete";
            dynamic res = await fetch.Instance.Delete(url, obj);
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
            string url = $"http://localhost:8080/v1/data/product/findall";
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
            string url = $"http://localhost:8080/v1/data/product/findone?name={obj.name}&color={obj.color}&size={obj.size}";
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
            string url = $"http://localhost:8080/v1/data/product/upadte";
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
        public async Task<object> FindProductGroupbyName()
        {
            string url = $"http://localhost:8080/v1/data/product/findproductgroupbyname";
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
        public async Task<object> FindCategory()
        {
            string url = $"http://localhost:8080/v1/data/product/findCategory";
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
        public async Task<object> FindProductByCategory(string category)
        {

            string url = $"http://localhost:8080/v1/data/product/findProductByCategory?category={category}";
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
        public async Task<object> FindProductByName(string name)
        {

            string url = $"http://localhost:8080/v1/data/product/FindProductByName?name={name}";
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
        public async Task<object> FindProductByWord(string word)
        {
            string url = $"http://localhost:8080/v1/data/product/FindProductByWord?word={word}";
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
    }
}

using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Product_BLL
    {
        private readonly Product_DAL dal = new Product_DAL();
        public async Task<JToken> FindProductGroupbyName()
        {
            object data = await dal.FindProductGroupbyName();
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> FindCategory()
        {
            object data = await dal.FindCategory();
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> FindProductByCategory(string category)
        {
            object data = await dal.FindProductByCategory(category);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> FindProductByName(string name)
        {
            object data = await dal.FindProductByName(name);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
        public async Task<JToken> FindProductByWord(string name)
        {
            object data = await dal.FindProductByWord(name);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
    }
    
}

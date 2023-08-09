using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bill_BLL
    {
        private readonly Bill_DAL dal = new Bill_DAL();
        public async Task<JToken> FindAllBillByStatus(string status)
        {
            object data = await dal.findAll(status);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
    }
}

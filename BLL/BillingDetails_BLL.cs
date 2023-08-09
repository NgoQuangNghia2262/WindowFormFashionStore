using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillingDetails_BLL
    {
        private readonly BillingDetails_DAL dal = new BillingDetails_DAL();
        public async Task<JToken> FindBillingDetailsByIdBill(string idbill)
        {
            object data = await dal.FindBillingDetailsByIdBill(idbill);
            JToken jToken = JToken.Parse(data.ToString());
            return jToken;
        }
    }
}

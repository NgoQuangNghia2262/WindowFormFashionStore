using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICRUD_DAL
    {
        Task<object> FindOne(dynamic obj);
        Task<object> findAll();
        Task<object> Create(object obj);
        Task<object> Delete(dynamic obj);
        Task<object> Update(dynamic obj);
       
    }
}

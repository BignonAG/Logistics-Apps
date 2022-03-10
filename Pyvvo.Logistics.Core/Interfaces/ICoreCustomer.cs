using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreCustomer
    {
        Task<Boolean> CreateCustomer(Customer customer, long userId);
        Task<Boolean> UpdateCustomer(Customer customer);
        Task<Boolean> DeleteCustomer(long id);
        Task<List<Model.Customer>> GetCustomers(long userId);
        Task<Model.Customer> GetCustomer(long id);
          

    }
}
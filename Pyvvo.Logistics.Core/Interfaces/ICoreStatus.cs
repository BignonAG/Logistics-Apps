using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreStatus
    {
        Task<Boolean> CreateStatus(Status status, long statusCategoryId);
        Task<Status> GetStatus(long id);
        Task<List<Status>> GetAllStatus(long categoryId);

    }
}
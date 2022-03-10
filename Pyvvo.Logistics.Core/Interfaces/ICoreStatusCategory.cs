using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreStatusCategory
    {
        Task<Boolean> AddOrdUpdate(StatusCategory statusCategory);
        Task<StatusCategory> GetStatusCategory(long id);
        Task<Boolean> Create(StatusCategory statusCategory);
        Task<Boolean> Update(StatusCategory statusCategory);
        Task<Boolean> Delete(long id);
    }
}
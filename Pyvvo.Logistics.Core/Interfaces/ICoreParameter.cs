using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreParameter
    {
          Task<Model.Parameter> Get(long id);
          Task<List<Model.Parameter>> GetEntities(long userId);
    }
}
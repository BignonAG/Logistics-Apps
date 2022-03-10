using System.Threading.Tasks;
using System.Collections.Generic;
using Pyvvo.Logistics.Model;
using System.Linq.Expressions;
using System;

namespace Pyvvo.Logistics.Core
{
    public interface ICoreProcessing
    {
          Task<Boolean> Create(Model.Processing processing, long userId);
          Task<Boolean> Update(Model.Processing processing);
          Task<List<Model.Processing>> GetEntities(long userId);
          Task<Model.Processing> Get(long Id);
          Task<Boolean> Delete(long id);
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Model.DataAccessLayer
{
    public class ImageDataAccessLayer : DataAccessLayer<Image>
    {
        private  DatabaseContext _context;
        public ImageDataAccessLayer(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<List<Image>> GetEntities(Expression<Func<Image, bool>> predicate)
        {
            List<Image> parameters = null;
            try
            {
                parameters = await _context.Images
                    .Where(predicate)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return parameters;
        }

        public override async Task<Image> Get(object param)
        {
            Image parameter = null;
            try
            {
                parameter = await _context.Images
                    .FirstOrDefaultAsync(x => x.Id == Convert.ToInt64(param));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return parameter;
        }

        public override async Task<List<Image>> GetEntities()
        {
            List<Image> entities = null;
            try
            {
                entities = await _context.Images
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entities;
        }

        public override async Task<Model.Image> GetEntityPredicate(Expression<Func<Image, bool>> predicate)
        {
            Image parameter = null;
            try
            {
                parameter = await _context.Images
                    .FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return parameter;
        }
    }
}

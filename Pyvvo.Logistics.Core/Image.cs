using Microsoft.EntityFrameworkCore;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pyvvo.Logistics.Core
{
    public class Image : IcoreImage
    {
        private readonly DatabaseContext _context;

        public Image(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Model.Image> Get(string filename)
        {
            Model.Image result = null;
            try
            {
                result = await _context.Images
                    .FirstOrDefaultAsync(x => x.FileName == filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public async Task<Model.Image> GetByUrl(string url)
        {
            Model.Image result = null;
            try
            {
                result = await _context.Images
                    .FirstOrDefaultAsync(x => x.PathUrl == url);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<List<Model.Image>> GetEntities(long userId)
        {
            List<Model.Image> images = null;
            try
            {
                var user = await _context.Users.FindAsync(Convert.ToInt64(userId));
                images = await _context.Images
                        .Where(x => x.CreatedBy.Company.Id == user.Company.Id)
                        .OrderByDescending(x => x.CreatedOn)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return images;
        }

        public async Task<Boolean> Create(Model.Image image, long userId)
        {
            Boolean result = false;
            try
            {
                if (image != null)
                {
                    image.CreatedOn = image.UpdatedOn = DateTime.Now;
                    image.CreatedById = userId;
                    _context.Images.Update(image);
                    result = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<Boolean> Delete(string filename)
        {
            Boolean result = false;
            try
            {
                _context.Images.Remove(await _context.Images.FirstOrDefaultAsync(x => x.FileName == filename));
                result = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}

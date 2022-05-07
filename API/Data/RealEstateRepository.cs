using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RealEstateRepository : IRealEstateRepository
    {
        readonly RealEstateContext _context;

        public RealEstateRepository(RealEstateContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<RealEstateVm>> GetRealEstates()
        //{
        //    // use automapper


        //    return await _context.RealEstate.ToListAsync();

        //}

        //public async Task<RealEstate> GetRealEstate(int id)
        //{
        //    return await _context.RealEstate.Include(r => r.RegistrationsOfInterest).FirstOrDefaultAsync(r => r.Id == id );
        //}

        //public async Task AddRealEstate(PostRealEstateVm model)
        //{
        //    var result = await _context.RealEstate.AddAsync(model);
        //    await _context.SaveChangesAsync();
        //    return result.Entity;
        //}

        //public async Task<RealEstate> UpdateRealEstate(RealEstate realEstate)
        //{
        //    var result = await _context.RealEstate.FirstOrDefaultAsync(r => r.Id == realEstate.Id);

        //    if (result != null)
        //    {
        //        result.Address = realEstate.Address;
        //        result.City = realEstate.City;
        //        result.ConstructionYear = realEstate.ConstructionYear;
        //        result.CoverPictureURL = realEstate.CoverPictureURL;
        //        result.Description = realEstate.Description;
        //        result.LivingArea = realEstate.LivingArea;
        //        result.NumberOfRooms = realEstate.NumberOfRooms;
        //        result.Price = realEstate.Price;
        //        result.Address = realEstate.Address;
        //        result.ConstructionYear = realEstate.ConstructionYear;

        //        result.Favourites = realEstate.Favourites;
        //        result.RealEstateImages = realEstate.RealEstateImages;

        //        await _context.SaveChangesAsync();

        //        return result;
        //    }

        //    return null;
        //}

        //public async Task DeleteRealEstateAsync(int id)
        //{
        //    var result = await _context.RealEstate.FirstOrDefaultAsync(r => r.Id == id);
        //    if (result != null)
        //    {
        //        _context.RealEstate.Remove(result);
        //        await _context.SaveChangesAsync();
        //        return result;
        //    }

        //    return null;
        //}
    }
}

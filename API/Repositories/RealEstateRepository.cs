using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.ViewModels;
using API.Data;
using Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace API.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        readonly HomeFinderContext _context;
        readonly IMapper _mapper;

        public RealEstateRepository(HomeFinderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RealEstateVm>> GetAllRealEstatesAsync()
        {
            return await _context.RealEstate.ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider).ToListAsync();
            
        }
        //public async Task<IEnumerable<RealEstateVm>> GetRealEstates(string search)
        //{
            
        //    return await _context.RealEstate.ToListAsync();
        //}

        public async Task<IEnumerable<RealEstateVm>> GetRealEstates()
        {
            throw new System.NotImplementedException();
        }

        public async Task<RealEstateVm> GetRealEstate(int id)
        {
            
            return await _context.RealEstate.Include(r => r.Broker).Include(r => r.RealEstateImages).ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<RealEstateVm> GetRealEstateForBroker(int id)
        {
            return await _context.RealEstate.Include(r => r.Broker).Include(r => r.RealEstateImages).Include(r => r.RegistrationsOfInterest)
                .ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);
        }


        public async Task<RealEstateVm> AddRealEstate(RealEstateVm realEstate)
        {
            var result = await _context.RealEstate.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateRealEstateAsync(RealEstateVm model)
        {
            var result = await _context.RealEstate.FirstOrDefaultAsync(r => r.Id == model.Id);

            if (result != null)
            {
                result.Address = model.Address;
                result.City = model.City;
                result.ConstructionYear = model.ConstructionYear;
                result.CoverPictureURL = model.CoverPictureURL;
                result.Description = model.Description;
                result.LivingArea = model.LivingArea;
                result.NumberOfRooms = model.NumberOfRooms;
                result.Price = model.Price;
                result.Address = model.Address;
                result.ConstructionYear = model.ConstructionYear;

                result.Favourites = model.Favourites;
                result.RealEstateImages = model.RealEstateImages;

                await _context.SaveChangesAsync();

                
            }

        }

        public async Task DeleteRealEstateAsync(int id)
        {
            var result = await _context.RealEstate.FirstOrDefaultAsync(r => r.Id == id);
            if (result is null)
            {
                throw new Exception($"Hittade ingen fastighet med id {id}");
            }

            if (result != null)
            {
                _context.RealEstate.Remove(result);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<RealEstateVm>> GetUserFavourites(string userId)
        {
            var realEstateList = new List<RealEstate>();
            await foreach (var f in _context.Favourites)
            {
                if (f.UserId == userId)
                {
                    realEstateList.Add(f.RealEstate);
                }
            }

            var result = new List<RealEstateVm>();

            for (var i = 0; i < realEstateList.Count; i++)
            {
                
                result.Add(realEstateList[i].ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider));
            }

            foreach (var item in realEstateList)
            {
                result += item.ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider);
            }

            return _context.Favourites.Where(f => f.UserId == userId).I

        }
    }
}

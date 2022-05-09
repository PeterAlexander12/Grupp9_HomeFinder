using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RealEstateRepository : IRealEstateRepository
    {
        readonly RealEstateContext _context;
        readonly IMapper _mapper;

        public RealEstateRepository(RealEstateContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RealEstateVm>> GetRealEstates()
        {
            return await _context.RealEstates.ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<RealEstateVm> GetRealEstateAsync(int id)
        {
            return await _context.RealEstates.Where(r => r.Id == id)
                .ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<RealEstateVm> GetRealEstateAsync(string address)
        {
            return await _context.RealEstates.Where(r => r.Address == address)
                .ProjectTo<RealEstateVm>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task AddRealEstateAsync(PostRealEstateVm model)
        {
            var realEstateToAdd = _mapper.Map<RealEstate>(model);
            await _context.RealEstates.AddAsync(realEstateToAdd);
        }

        public async Task UpdateRealEstateAsync(int id, PostRealEstateVm model)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate is null)
            {
                throw new Exception($"Hittade ingen fastighet med id {id}");
            }

            _mapper.Map(model, realEstate);

        }

        public async Task UpdateRealEstateAsync(int id, PatchRealEstateVm model)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate is null)
            {
                throw new Exception($"Hittade ingen fastighet med id {id}");
            }

            _mapper.Map(model, realEstate);
        }

        public async Task DeleteRealEstateAsync(int id)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate is null)
            {
                throw new Exception($"Hittade ingen fastighet med id {id}");
            }

            _context.RealEstates.Remove(realEstate);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}

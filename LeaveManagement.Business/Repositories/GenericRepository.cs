﻿using LeaveManagement.Business.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Business.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity); //Add entity
            await _context.SaveChangesAsync(); //Save the changes
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);// Find the Type by the id in the parameters
            _context.Set<T>().Remove(entity); //Remove the record
            await _context.SaveChangesAsync(); //Save the changes
            
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Update(entity); 
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
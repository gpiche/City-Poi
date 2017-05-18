using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;
using CityPoi.Services;
using Microsoft.EntityFrameworkCore;

namespace CityPoi.DataAccesLayer
{
    public class CityRepository : ICityRepository
    {
        private readonly ApiDbContext _context;

        public CityRepository(ApiDbContext dbContext)
        {
            _context = dbContext;
        }


        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == cityId);
            city.PointsOfInterests.Add(pointOfInterest);

            _context.Entry(city).State = EntityState.Modified;

             _context.SaveChanges();

        }


        public bool CityExists(int cityId)
        {
           var city = _context.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city != null)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (!includePointsOfInterest) return _context.Cities.FirstOrDefault(x => x.Id == cityId);
            
            return _context.Cities.Include(c => c.PointsOfInterests).FirstOrDefault(x => x.Id == cityId);
            
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointOfInterests.FirstOrDefault(poi => poi.CityId == cityId);
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointOfInterests.Where(poi => poi.CityId == cityId).ToList();
 
        }

 
        public void UpdatePointOfInterest(PointOfInterest pointOfInterest)
        {
        
            _context.Update<PointOfInterest>(pointOfInterest);
            _context.SaveChanges();

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            var city = _context.Cities.Include(c => c.PointsOfInterests).FirstOrDefault(x => x.Id == pointOfInterest.CityId);
            var pointOfInterestToRemove = _context.PointOfInterests.FirstOrDefault(poi => poi == pointOfInterest);

             city.PointsOfInterests.Remove(pointOfInterestToRemove);
            _context.Update(city);
            _context.SaveChanges();

        }
    }
}

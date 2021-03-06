﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityPoi.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CityPoi.DTOs
{
    public class DtosToEntities : Controller
    {
       public PointOfInterest ConvertToEntity(int cityId, int poiId,PoiDTO pointOfInterestDto)
        {
            var pointOfInterest = new PointOfInterest()
            {
                Id = poiId,
                CityId = cityId,
                Descritption = pointOfInterestDto.Descritption,
                FullDescritption = pointOfInterestDto.FullDescription,
                Logo = pointOfInterestDto.Logo,
                Picture = pointOfInterestDto.Picture,
                Longitude = pointOfInterestDto.Longitude,
                Latitude = pointOfInterestDto.Latitude,
                Name = pointOfInterestDto.Name
            };

            return pointOfInterest;
        }

        public PointOfInterest ConvertToEntity(int cityId, PoiDTO pointOfInterestDto)
        {
            var pointOfInterest = new PointOfInterest()
            {
                Id = pointOfInterestDto.Id,
                CityId = cityId,
                Descritption = pointOfInterestDto.Descritption,
                FullDescritption = pointOfInterestDto.FullDescription,
                Logo = pointOfInterestDto.Logo,
                Picture = pointOfInterestDto.Picture,
                Longitude = pointOfInterestDto.Longitude,
                Latitude = pointOfInterestDto.Latitude,
                Name = pointOfInterestDto.Name
            };

            return pointOfInterest;
        }
    }
}

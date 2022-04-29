using AutoMapper;
using mStockAPI.DTOs;
using mStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CompanyDetails, CompanyDetailsRespone>();
            CreateMap<CompanyDetailsWatch, WatchListRequest>().ReverseMap();
            CreateMap<CompanyStocks, StocksResponse>()
                .ForMember(d => d.CompanyName, x => x.MapFrom(s => s.Company.CompanyName));
        }
    }
}
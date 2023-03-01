using AutoMapper;
using StepsStatistic.Models;
using StepsStatistic.Utils;
using System.Collections.Generic;

namespace StepsStatistic.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserJson, UserModel>()
                .ForMember(nameof(UserModel.User), config => config.MapFrom(x => x.User))
                .AfterMap((userStat, userModel, context) =>
                {
                    userModel.Stats = new List<StatModel>();

                    userModel.Stats.Add(context.Mapper.Map<StatModel>(userStat));
                });
            CreateMap<UserJson, StatModel>();
        }
    }
}
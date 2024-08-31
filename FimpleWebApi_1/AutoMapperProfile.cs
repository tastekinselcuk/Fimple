using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;

namespace FimpleWebApi_1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,CharacterResponseDto>();
            CreateMap<CharacterRequestDto,Character>();
            CreateMap<UpdateCharacterDto,Character>();
        }

    }
}
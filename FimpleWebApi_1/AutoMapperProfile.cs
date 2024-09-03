// This class defines mapping profiles for AutoMapper, facilitating object-object mapping between various DTOs.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;
using FimpleWebApi_1.Dtos.Fight;
using FimpleWebApi_1.Dtos.Skill;
using FimpleWebApi_1.Dtos.Weapon;

namespace FimpleWebApi_1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,CharacterResponseDto>();
            CreateMap<CharacterRequestDto,Character>();
            CreateMap<UpdateCharacterDto,Character>();
            CreateMap<WeaponRequestDto,Character>();
            CreateMap<Weapon,WeaponResponseDto>();
            CreateMap<Skill,SkillResponseDto>();
            CreateMap<Character,HighscoreDto>();
        }

    }
}
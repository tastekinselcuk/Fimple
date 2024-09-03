using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;
using FimpleWebApi_1.Dtos.Weapon;

namespace FimpleWebApi_1.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<CharacterResponseDto>> AddWeapon(WeaponRequestDto newWeapon);
        
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Fight;

namespace FimpleWebApi_1.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponse<FightResultDto>> Fight(FightRequestDto request);
        Task<ServiceResponse<List<HighscoreDto>>> GetHighscore();


    }
}
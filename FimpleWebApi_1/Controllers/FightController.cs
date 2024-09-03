using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Fight;
using Microsoft.AspNetCore.Mvc;

namespace FimpleWebApi_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack (WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack (SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }
        
        [HttpPost]
        public async Task<ActionResult<FightResultDto>> Fight (FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HighscoreDto>>>> GetHighscore ()
        {
            return Ok(await _fightService.GetHighscore());
        }
        
    }
}
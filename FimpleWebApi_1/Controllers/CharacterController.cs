using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FimpleWebApi_1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        
        {
            _characterService = characterService;
        }
        
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }
        
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> UpdateCharacter(UpdateCharacterDto updateCharacterDto){
            var response = await _characterService.UpdateCharacter(updateCharacterDto);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponseDto>>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacterById(id);
            if(response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost("skill")]
        public async Task<ActionResult<ServiceResponse<CharacterResponseDto>>> AddCharacterSkill(CharacterSkillRequestDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace FimpleWebApi_1.Controllers
{
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
        public ActionResult<List<Character>> Get(){

            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("GetById")]
        public ActionResult<List<Character>> GetSingle(int id){

            return Ok(_characterService.GetCharacterById(id));
        }
        
        
        [HttpPost]
        public ActionResult<Character> AddCharacter(Character newCharacter){
            return Ok(_characterService.AddCharacter(newCharacter));
        }
        
    }
}
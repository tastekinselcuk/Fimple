using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;
using FimpleWebApi_1.Models;

namespace FimpleWebApi_1.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters();

        Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter);

        Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto);

        Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacterById(int id);
        Task<ServiceResponse<CharacterResponseDto>> AddCharacterSkill(CharacterSkillRequestDto newCharacterSkill);


    }
}
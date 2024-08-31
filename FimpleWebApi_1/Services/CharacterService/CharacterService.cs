global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;


namespace FimpleWebApi_1.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context){
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            try{
                var character = 
                    await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
                if(character is null)
                    throw new Exception($"Character with Id '{id}' not found.");
                
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = 
                    await _context.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters(int userId)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var dbCharacters = await _context.Characters.Where(c =>c.user!.Id == userId).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(dbCharacters);
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            try{
            var character = 
                await _context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacterDto.Id);
            if(character is null)
                throw new Exception($"Character with Id '{updateCharacterDto.Id} not found.");

            _mapper.Map<Character>(updateCharacterDto);
            character.Name = updateCharacterDto.Name;
            character.HitPoints = updateCharacterDto.HitPoints;
            character.Strength = updateCharacterDto.Strength;
            character.Defense = updateCharacterDto.Defense;
            character.Intelligence = updateCharacterDto.Intelligence;
            character.Class = updateCharacterDto.Class;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
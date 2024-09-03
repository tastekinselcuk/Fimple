global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FimpleWebApi_1.Dtos.Character;


namespace FimpleWebApi_1.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor){
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // Retrieves and parses the current user's ID from the HTTP context claims.
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Characters
                .Where(c =>c.User!.Id == GetUserId())
                .Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            try{
                var character = await _context.Characters
                .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
                if(character is null)
                    throw new Exception($"Character with Id '{id}' not found.");
                
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = 
                    await _context.Characters.Where(c => c.User!.Id == GetUserId())
                    .Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
            var dbCharacters = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .Where(c =>c.User!.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            var dbCharacters = await _context.Characters
            .Include(c => c.Weapon)
            .Include(c => c.Skills)
            .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(dbCharacters);
            return serviceResponse;
        }

        public async Task<ServiceResponse<CharacterResponseDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto)
        {
            var serviceResponse = new ServiceResponse<CharacterResponseDto>();
            try{
            var character = 
                await _context.Characters
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == updateCharacterDto.Id);
            if(character is null || character.User!.Id != GetUserId())
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

        public async Task<ServiceResponse<CharacterResponseDto>> AddCharacterSkill(CharacterSkillRequestDto newCharacterSkill)
        {
            var response = new ServiceResponse<CharacterResponseDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.User!.Id == GetUserId());
                if(character is null){
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }
                var skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);
                if(skill is null){
                    response.Success = false;
                    response.Message = "Skill not found.";
                    return response;
                }

                character.Skills!.Add(skill);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<CharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
{
    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
    {
        return await context.Characters.Select(c => new CharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToListAsync();
    }

    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters.Where(c => c.Id == id).Select(c => new CharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).FirstOrDefaultAsync();
        return result; 
    }

    public async Task<CharacterResponse> CreateCharacterAsync(CreateCharacterRequest request)
    {
        var newCharacter = new Character
        {
            Name = request.Name,
            Game = request.Game,
            Role = request.Role
        };
        context.Characters.Add(newCharacter);
        await context.SaveChangesAsync();
        return new CharacterResponse
        {
            Id = newCharacter.Id,
            Name = newCharacter.Name,
            Game = newCharacter.Game,
            Role = newCharacter.Role
        };
    }

    public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest request)
    {
        if (id != request.Id)
        {
            return false;
        }
        var character = await context.Characters.FindAsync(id);
        if (character is null)
        {
            return false;
        }
        character.Name = request.Name;
        character.Game = request.Game;
        character.Role = request.Role;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCharacterAsync(int id)
    {
        var character = await context.Characters.FindAsync(id);
        if (character is null)
        {
            return false;
        }
        context.Characters.Remove(character);
        await context.SaveChangesAsync();
        return true;
    }
}
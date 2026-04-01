using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Services;

public interface IVideoGameCharacterService
{
    Task<List<CharacterResponse>> GetAllCharactersAsync();
    Task<CharacterResponse?> GetCharacterByIdAsync(int id);
    Task<CharacterResponse> CreateCharacterAsync(CreateCharacterRequest request);
    Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest request);
    Task<bool> DeleteCharacterAsync(int id);
}

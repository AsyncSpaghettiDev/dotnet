using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameCharactersController(IVideoGameCharacterService videoGameCharacterService) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
    {
        return Ok(await videoGameCharacterService.GetAllCharactersAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Character?>> GetCharacter(int id)
    {
        var character = await videoGameCharacterService.GetCharacterByIdAsync(id);
        return character is null ? NotFound($"Character with ID {id} not found") : Ok(character);
    }
    
    [HttpPost]
    public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest request)
    {
        var createdCharacter = await videoGameCharacterService.CreateCharacterAsync(request);
        return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CharacterResponse>> UpdateCharacter(int id, UpdateCharacterRequest request)
    {
        var updatedCharacter = await videoGameCharacterService.UpdateCharacterAsync(id, request);
        return updatedCharacter ? NoContent() : NotFound($"Character with ID {id} not found");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteCharacter(int id)
    {
        var deleted = await videoGameCharacterService.DeleteCharacterAsync(id);
        return deleted ? NoContent() : NotFound($"Character with ID {id} not found");
    }
}
 
 
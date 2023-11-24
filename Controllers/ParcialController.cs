using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcialController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public ParcialController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll() {
           var all= _characterService.GetAllCharacters();
            if (all == null)
            {
                return BadRequest("No hay nada");
            }
            else
            {
                return Ok(all);
            }
        }
        [HttpGet("GetId")]

        public IActionResult GetId(int id) {
            var personaje = _characterService.GetCharacterById(id);
            if (personaje == null) {
                return BadRequest();
            }
            return Ok(personaje);
        }


        [HttpPost("addCharacter")]

        public IActionResult Post([FromBody]AddCharacterDto newCharacter) {
            Task<ServiceResponse<List<GetCharacterDto>>> personaje = _characterService.AddCharacter(newCharacter);
            if (personaje == null)
            {
                return BadRequest();
            }
            else {
                return Ok(personaje);
            };
        }

        [HttpDelete]

        public IActionResult Delete(int id) {
            Task<ServiceResponse<List<GetCharacterDto>>> idC= _characterService.DeleteCharacter(id);
            if (idC == null)
            {
                return BadRequest();
            }
            else {
                return Ok(idC);
             }
        }

        [HttpPut]

        public IActionResult UpdateCharacter(UpdateCharacterDto updateCharacter) {
          var modificar= _characterService.UpdateCharacter(updateCharacter);
            if (modificar == null)
            {
                return BadRequest();
            }
            else 
            {
                return Ok(modificar);
            }
        }
    }
}

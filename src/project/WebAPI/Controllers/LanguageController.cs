using Application.Features.Language.Dtos;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetById;
using Application.Features.Languages.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost("Ekle")]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto createLanguageDto = await Mediator.Send(createLanguageCommand);
            return Ok(createLanguageDto);
        }

        [HttpDelete("Sil")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand )
        {           
            DeleteLanguageDto deleteLanguageDto = await Mediator.Send(deleteLanguageCommand);
            return Ok(deleteLanguageDto);
        }

        [HttpPut("Güncelle")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdateLanguageDto updateLanguageDto = await Mediator.Send(updateLanguageCommand);
            return Ok(updateLanguageDto);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest )
        {
            GetListLanguageQuery getListLanguageQuery = new() {PageRequest = pageRequest };
            GetListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            GetByIdDto getByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(getByIdDto);
        }
    }
}

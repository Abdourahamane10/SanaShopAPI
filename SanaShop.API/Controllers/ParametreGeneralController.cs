using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanaShop.API.DTOs;
using SanaShop.API.ExtensionMethods;
using SanaShop.Applications.DTOs.ParametresGeneraux;
using SanaShop.Applications.Features.ParametresGeneraux.Commands;

namespace SanaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors(SecurityMethods.DEFAULT_POLICY)]
    public class ParametreGeneralController : ControllerBase
    {
        #region Attributs privés

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        #endregion Attributs privés

        #region Constructeurs
        public ParametreGeneralController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion Constructeurs

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] // Créé avec succès
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //erreur client (Exemple : données invalides)
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)] // erreur serveur
        public async Task<IActionResult> Create(CreateParametreGeneralDto oCreateParametreGeneralDto)
        {
            var oCreateParametreGeneralCommand = new CreateParametreGeneralCommand(
                oCreateParametreGeneralDto.Raison_sociale,
                oCreateParametreGeneralDto.CodePays_telephone_mobile,
                oCreateParametreGeneralDto.Numero_telephone_mobile,
                oCreateParametreGeneralDto.CodePays_telephone_fixe,
                oCreateParametreGeneralDto.Numero_telephone_fixe,
                oCreateParametreGeneralDto.Email,
                oCreateParametreGeneralDto.Texte_Entete,
                oCreateParametreGeneralDto.Texte_Pied_De_Page,
                oCreateParametreGeneralDto.Texte_PageAccueil,
                oCreateParametreGeneralDto.Texte_APropos,
                oCreateParametreGeneralDto.UrlLogo
            );

            var parametreGeneralId =  await _mediator.Send(oCreateParametreGeneralCommand);

            return CreatedAtAction(nameof(GetById), new { id = parametreGeneralId }, null);
        }

        [HttpGet]
        public async Task<ActionResult<CreateParametreGeneralDto>> GetById(int iParametreGeneralId)
        {
            // Pour l'instant, on retourne juste un statut 200 OK vide
            return Ok();
        }
    }
}

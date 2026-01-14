using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SanaShop.Applications.Features.ParametresGeneraux.Commands
{
    public record CreateParametreGeneralCommand(
        string NomSociete,
        string CodePaysTelephoneMobile,
        string NumContactMobile,
        string CodePaysTelephoneFixe,
        string NumContactFixe,
        string EmailContact,
        string? TexteEntete,
        string? TextePiedDePage,
        string? TextePageAccueil,
        string? TexteAPropos,
        string? UrlLogoSociete
    ) : IRequest<int>;
}

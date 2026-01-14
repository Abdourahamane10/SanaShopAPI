using MediatR;
using SanaShop.Applications.Base;
using SanaShop.Applications.Interfaces;
using SanaShop.Domain.Models;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Features.ParametresGeneraux.Commands
{
    public class CreateParametreGeneralCommandHandler : IRequestHandler<CreateParametreGeneralCommand, int>
    {
        #region Propriétés privées

        private readonly IBaseRepository<ParametreGeneral> _parametreGeneralRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Propriétés privées

        #region Constructeurs
        public CreateParametreGeneralCommandHandler(IBaseRepository<ParametreGeneral> parametreGeneralRepository, 
            IUnitOfWork unitOfWork)
        {
            _parametreGeneralRepository = parametreGeneralRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructeurs

        public async Task<int> Handle(CreateParametreGeneralCommand request, CancellationToken cancellationToken)
        {
            Telephone oMobileContact = new Telephone(request.CodePaysTelephoneMobile, request.NumContactMobile);
            Telephone oFixeContact = new Telephone(request.CodePaysTelephoneFixe, request.NumContactFixe);
            Email oEmailContact = new Email(request.EmailContact);

            ParametreGeneral oParametreGeneral = new ParametreGeneral(request.NomSociete, oMobileContact, oFixeContact,
                oEmailContact);
            oParametreGeneral.DefinirOuModifierParagrapheEntete(request.TexteEntete);
            oParametreGeneral.DefinirOuModifierParagraphePiedDePage(request.TextePiedDePage);
            oParametreGeneral.DefinirOuModifierParagraphePageAccueil(request.TextePageAccueil);
            oParametreGeneral.DefinirOuModifierParagrapheAPropos(request.TexteAPropos);
            oParametreGeneral.DefinirOuModifierUrlLogoSociete(request.UrlLogoSociete);

            await _parametreGeneralRepository.AddAsync(oParametreGeneral);

            await _unitOfWork.SaveChangesAsync();

            return oParametreGeneral.Id;
        }
    }
}

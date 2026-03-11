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

namespace SanaShop.Applications.Features.Commands.ParametresGeneraux
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
            Telephone oMobileContact = Telephone.Create(request.CodePaysTelephoneMobile, request.NumContactMobile);
            Telephone oFixeContact = Telephone.Create(request.CodePaysTelephoneFixe, request.NumContactFixe);
            Email oEmailContact = new Email(request.EmailContact);

            ParametreGeneral oParametreGeneral = new ParametreGeneral(request.NomSociete, oMobileContact, oFixeContact,
                oEmailContact);
            oParametreGeneral.ModifierParagrapheEntete(request.TexteEntete);
            oParametreGeneral.ModifierParagraphePiedDePage(request.TextePiedDePage);
            oParametreGeneral.ModifierParagraphePageAccueil(request.TextePageAccueil);
            oParametreGeneral.ModifierParagrapheAPropos(request.TexteAPropos);
            oParametreGeneral.ModifierUrlLogoSociete(request.UrlLogoSociete);

            await _parametreGeneralRepository.AddAsync(oParametreGeneral);

            await _unitOfWork.SaveChangesAsync();

            return oParametreGeneral.Id;
        }
    }
}

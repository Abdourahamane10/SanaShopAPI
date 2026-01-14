using FluentValidation;
using SanaShop.Applications.Features.ParametresGeneraux.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Features.ParametresGeneraux.Validators
{
    public class CreateParametreGeneralCommandValidator : AbstractValidator<CreateParametreGeneralCommand>
    {
        public CreateParametreGeneralCommandValidator() 
        {
            RuleFor(p => p.NomSociete)
                .NotEmpty().WithMessage("Le nom de la société est requis.")
                .MaximumLength(200).WithMessage("Le nom de la société ne peut pas dépasser 200 caractères.");

            RuleFor(p => p.CodePaysTelephoneMobile)
                .NotEmpty().WithMessage("Le code pays du téléphone mobile est requis.")
                .MaximumLength(4).WithMessage("Le code pays du téléphone mobile ne peut pas dépasser 4 caractères.");

            RuleFor(p => p.NumContactMobile)
                .NotEmpty().WithMessage("Le numéro de contact mobile est requis.")
                .MaximumLength(20).WithMessage("Le numéro de contact mobile ne peut pas dépasser 20 caractères.");

            RuleFor(p => p.CodePaysTelephoneFixe)
                .NotEmpty().WithMessage("Le code pays du téléphone fixe est requis.")
                .MaximumLength(4).WithMessage("Le code pays du téléphone fixe ne peut pas dépasser 4 caractères.");

            RuleFor(p => p.NumContactFixe)
                .NotEmpty().WithMessage("Le numéro de contact fixe est requis.")
                .MaximumLength(20).WithMessage("Le numéro de contact fixe ne peut pas dépasser 20 caractères.");

            RuleFor(p => p.EmailContact)
                .NotEmpty().WithMessage("L'email de contact est requis.")
                .EmailAddress().WithMessage("L'email de contact n'est pas valide.")
                .MaximumLength(100).WithMessage("L'email de contact ne peut pas dépasser 100 caractères.");
        }
    }
}

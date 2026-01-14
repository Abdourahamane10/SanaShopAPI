using AutoMapper;
using SanaShop.Applications.DTOs.ParametresGeneraux;
using SanaShop.Applications.Features.ParametresGeneraux.Commands;
using SanaShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Domain.Profiles
{
    public class ParametreGeneralProfile : Profile
    {
        public ParametreGeneralProfile()
        {
            //Domain -> DTO (sortie API)
            CreateMap<ParametreGeneral, GetAllParametreGeneralDto>()
                .ForMember(dest => dest.Raison_sociale, opt => opt.MapFrom(src => src.NomSociete))
                .ForMember(dest => dest.CodePays_telephone_mobile, opt => opt.MapFrom(src => src.MobileContact.IndicatifPays))
                .ForMember(dest => dest.Numero_telephone_mobile, opt => opt.MapFrom(src => src.MobileContact.NumTelephone))
                .ForMember(dest => dest.CodePays_telephone_fixe, opt => opt.MapFrom(src => src.FixeContact.IndicatifPays))
                .ForMember(dest => dest.Numero_telephone_fixe, opt => opt.MapFrom(src => src.FixeContact.NumTelephone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailContact.Adresse))
                .ForMember(dest => dest.Texte_Entete, opt => opt.MapFrom(src => src.ParagrapheEntete))
                .ForMember(dest => dest.Texte_Pied_De_Page, opt => opt.MapFrom(src => src.ParagraphePiedDePage))
                .ForMember(dest => dest.Texte_PageAccueil, opt => opt.MapFrom(src => src.ParagraphePageAccueil))
                .ForMember(dest => dest.Texte_APropos, opt => opt.MapFrom(src => src.ParagrapheAPropos))
                .ForMember(dest => dest.UrlLogo, opt => opt.MapFrom(src => src.UrlLogoSociete));
        }
    }
}

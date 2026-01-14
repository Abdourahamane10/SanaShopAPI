using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanaShop.Domain.Models;
using SanaShop.Domain.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Infrastructure.Database.EntityConfigurations
{
    public class ParametreGeneralConfiguration : IEntityTypeConfiguration<ParametreGeneral>
    {
        public void Configure(EntityTypeBuilder<ParametreGeneral> builder)
        {
            builder.ToTable("parametresGeneraux");
            builder.HasKey(pg => pg.Id);
            builder.Property(pg => pg.Id)
                .HasColumnName("idParamGeneral")
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(pg => pg.NomSociete)
                .HasColumnName("raisonSociale")
                .IsRequired()
                .HasMaxLength(200);

            builder.OwnsOne(pg => pg.MobileContact, mc =>
            {
               mc.Property(t => t.IndicatifPays)
                  .HasColumnName("indicatifPaysMobile")
                  .IsRequired()
                  .HasMaxLength(4);

                mc.Property(t => t.NumTelephone)
                .HasColumnName("mobileContact")
                .IsRequired()
                .HasMaxLength(20);
            });

            builder.OwnsOne(pg => pg.FixeContact, mc =>
            {
                mc.Property(t => t.IndicatifPays)
                   .HasColumnName("indicatifPaysFixe")
                   .IsRequired()
                   .HasMaxLength(4);

                mc.Property(t => t.NumTelephone)
                .HasColumnName("fixeContact")
                .IsRequired()
                .HasMaxLength(20);
            });

            builder.Property(pg => pg.EmailContact) //Conversion pour le type Email (1er lambda pour l'écriture en base et le 2e lambda pour la lecture depuis la base)
                .HasConversion(
                    email => email.Adresse,
                    dbValue => new Email(dbValue)
                )
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pg => pg.ParagrapheEntete)
                .HasColumnName("generiqueEntetePage");

            builder.Property(pg => pg.ParagraphePiedDePage)
                .HasColumnName("generiquePiedPage");

            builder.Property(pg => pg.ParagraphePageAccueil)
                .HasColumnName("generiquePageAccueil");

            builder.Property(pg => pg.ParagrapheAPropos)
                .HasColumnName("generiqueAPropos");

            builder.Property(pg => pg.UrlLogoSociete)
                .HasColumnName("logoEntreprise");
        }
    }
}

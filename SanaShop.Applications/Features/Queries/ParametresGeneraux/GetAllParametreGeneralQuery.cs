using MediatR;
using SanaShop.Applications.DTOs.ParametresGeneraux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Features.Queries.ParametresGeneraux
{
    public record GetAllParametreGeneralQuery() : IRequest<List<GetAllParametreGeneralDto>>;
}

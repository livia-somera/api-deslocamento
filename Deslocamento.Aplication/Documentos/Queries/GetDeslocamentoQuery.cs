using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Queries
{
    public class GetDeslocamentoQuery : IRequest<Deslocamento>
    {
        public long DeslocamentoId { get; set; }
    }

    public class GetDeslocamentoQueryHandler : IRequestHandler<GetDeslocamentoQuery, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(GetDeslocamentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
                .FindBy(d => d.Id == request.DeslocamentoId)
                .FirstAsync(cancellationToken);

            return deslocamento;
        }
    }
}
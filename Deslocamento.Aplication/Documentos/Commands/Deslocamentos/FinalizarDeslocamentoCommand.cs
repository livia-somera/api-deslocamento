using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Commands.Deslocamentos
{
    public class FinalizarDeslocamentoCommand : IRequest
    {
        public long DeslocamentoId { get; set; }
        public string Observacao { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }

    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            FinalizarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();
            var deslocamento = await repositoryDeslocamento
               .FindBy(d => d.Id == request.DeslocamentoId)
               .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(request.Observacao, request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}

using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.Deslocamentos
{
    public class IniciarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }
        public long ClienteId { get; set; }
        public long CondutorId { get; set; }
        public decimal QuilometragemInicial { get; set; }
    }

    public class IniciarDeslocamentoCommandHandler :
        IRequestHandler<IniciarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IniciarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(
            IniciarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamento(
                 request.CarroId,
                 request.ClienteId,
                 request.CondutorId,
                 request.QuilometragemInicial);

            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }
}

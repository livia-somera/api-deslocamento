using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.Carros
{
    public class AdicionarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }

    public class AdicionarCarroCommandHandler :
        IRequestHandler<AdicionarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            AdicionarCarroCommand request,
            CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(
                 request.Placa,
                 request.Descricao);

            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}

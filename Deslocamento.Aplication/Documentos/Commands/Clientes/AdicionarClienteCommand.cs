using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.AdicionarCliente
{
    public class AdicionarClienteCommand : IRequest<Cliente>
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

    }

    public class AdicionarClienteCommandHandler : IRequestHandler<AdicionarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(AdicionarClienteCommand request,
            CancellationToken cancellationToken)
        {
            var adicionarCliente = new Cliente(
                 request.CPF,
                 request.Nome);

            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(adicionarCliente);

            await _unitOfWork.CommitAsync();

            return adicionarCliente;
        }
    }
}

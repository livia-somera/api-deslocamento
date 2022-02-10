using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.Condutores
{
    public class AdicionarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; set; }

        public string Email { get; set; }
    }

    public class AdicionarCondutorCommandHandler :
        IRequestHandler<AdicionarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(
            AdicionarCondutorCommand request,
            CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(
                 request.Nome,
                 request.Email);

            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unitOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}

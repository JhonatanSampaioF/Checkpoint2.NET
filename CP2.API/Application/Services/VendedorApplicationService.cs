using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }
        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public VendedorEntity? EditarDadosVendedor(int id, VendedorDto entity)
        {
            var vendedor = new VendedorEntity
            {
                id = id,
                nome = entity.nome,
                email = entity.email,
                telefone = entity.telefone,
                dataNascimento = entity.dataNascimento,
                endereco = entity.endereco,
                dataContratacao = entity.dataContratacao,
                comissaoPercentual = entity.comissaoPercentual,
                metaMensal = entity.metaMensal,
                criadoEm = entity.criadoEm
            };

            return _repository.EditarDados(vendedor);
        }

        public VendedorEntity? ObterVendedorporId(int id)
        {
            return _repository.ObterporId(id);
        }

        public IEnumerable<VendedorEntity>? ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? SalvarDadosVendedor(VendedorDto entity)
        {
            var vendedor = new VendedorEntity
            {
                nome = entity.nome,
                email = entity.email,
                telefone = entity.telefone,
                dataNascimento = entity.dataNascimento,
                endereco = entity.endereco,
                dataContratacao = entity.dataContratacao,
                comissaoPercentual = entity.comissaoPercentual,
                metaMensal = entity.metaMensal,
                criadoEm = entity.criadoEm
            };

            return _repository.SalvarDados(vendedor);
        }

        
    }
}

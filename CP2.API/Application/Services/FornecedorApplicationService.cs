using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, FornecedorDto entity)
        {
            var fornecedor = new FornecedorEntity
            {
                id = id,
                nome = entity.nome,
                cnpj = entity.cnpj,
                endereco = entity.endereco,
                telefone = entity.telefone,
                email = entity.email,
                criadoEm = entity.criadoEm
            };

            return _repository.EditarDados(fornecedor);
        }

        public FornecedorEntity? ObterFornecedorporId(int id)
        {
            return _repository.ObterporId(id);
        }

        public IEnumerable<FornecedorEntity>? ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? SalvarDadosFornecedor(FornecedorDto entity)
        {
            var fornecedor = new FornecedorEntity
            {
                nome = entity.nome,
                cnpj = entity.cnpj,
                endereco = entity.endereco,
                telefone = entity.telefone,
                email = entity.email,
                criadoEm = entity.criadoEm
            };

            return _repository.SalvarDados(fornecedor);
        }
    }
}

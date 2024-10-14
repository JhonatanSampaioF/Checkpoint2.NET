using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor is not null)
                {
                    _context.Remove(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }
                throw new Exception("Não foi possível localizar o fornecedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FornecedorEntity? EditarDados(FornecedorEntity entity)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(entity.id);

                if (fornecedor is not null)
                {
                    fornecedor.nome = entity.nome;
                    fornecedor.cnpj = entity.cnpj;
                    fornecedor.endereco = entity.endereco;
                    fornecedor.telefone = entity.telefone;
                    fornecedor.email = entity.email;
                    fornecedor.criadoEm = entity.criadoEm;

                    _context.Update(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                throw new Exception("Não foi possível localizar o fornecedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FornecedorEntity? ObterporId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor is not null)
            {
                return fornecedor;
            }
            return null;
        }

        public IEnumerable<FornecedorEntity>? ObterTodos()
        {
            var fornecedors = _context.Fornecedor.ToList();

            if (fornecedors.Any())
                return fornecedors;

            return null;
        }

        public FornecedorEntity? SalvarDados(FornecedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o fornecedor ");
            }
        }
    }
}

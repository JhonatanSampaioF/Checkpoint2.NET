using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(id);

                if (vendedor is not null)
                {
                    _context.Remove(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }
                throw new Exception("Não foi possível localizar o vendedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VendedorEntity? EditarDados(VendedorEntity entity)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(entity.id);

                if (vendedor is not null)
                {
                    vendedor.nome = entity.nome;
                    vendedor.email = entity.email;
                    vendedor.telefone = entity.telefone;
                    vendedor.dataNascimento = entity.dataNascimento;
                    vendedor.endereco = entity.endereco;
                    vendedor.dataContratacao = entity.dataContratacao;
                    vendedor.comissaoPercentual = entity.comissaoPercentual;
                    vendedor.metaMensal = entity.metaMensal;
                    vendedor.criadoEm = entity.criadoEm;

                    _context.Update(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                throw new Exception("Não foi possível localizar o vendedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VendedorEntity? ObterporId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                return vendedor;
            }
            return null;
        }

        public IEnumerable<VendedorEntity>? ObterTodos()
        {
            var vendedors = _context.Vendedor.ToList();

            if (vendedors.Any())
                return vendedors;

            return null;
        }

        public VendedorEntity? SalvarDados(VendedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o vendedor ");
            }
        }
    }
}

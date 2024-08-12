using Microsoft.EntityFrameworkCore;
using Servidor.Datos.Repositorios.IRepositorios;

namespace Servidor.Datos.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MonedaDbContext _context;

        public UnitOfWork(MonedaDbContext context)
        {
            _context = context;
            AlertaRepository = new AlertaRepository(_context);
            CotizacionRepository = new CotizacionRepository(_context);
            MonedaRepository = new MonedaRepository(_context);
            PaisRepository = new PaisRepository(_context);
            UsuarioRepository = new UsuarioRepository(_context);
        }

        public IAlertaRepository AlertaRepository { get; private set; }
        public ICotizacionRepository CotizacionRepository { get; private set; }
        public IMonedaRepository MonedaRepository { get; private set; }
        public IPaisRepository PaisRepository { get; private set; }
        public IUsuarioRepository UsuarioRepository { get; private set; }

        public async Task<int> CompletarAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


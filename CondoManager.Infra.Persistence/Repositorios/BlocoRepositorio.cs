using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using CondoManager.Domain.Interfaces.Repositorios;
using CondoManager.Infra.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CondoManager.Infra.Persistence.Repositorios
{
    public class BlocoRepositorio : IBlocoRepositorio
    {
        private readonly Context _context;

        public BlocoRepositorio(Context context)
        {
            _context = context;
        }

        public void Add(Bloco data)
        {
            _context.Blocos.Add(data);
        }

        public void Delete(Bloco data)
        {
            _context.Blocos.Remove(data);
        }


        public Bloco Find(Guid guid)
        {
            return _context.Blocos.Find(guid);
        }

        public void Update(Bloco data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Bloco> BuscarPorFiltro(IBlocoFiltro filtro)
        {
            IQueryable<Bloco> query = _context.Blocos.Include(d => d.Condominio);
            if (!string.IsNullOrWhiteSpace(filtro.Nome)) query = query.Where(d => d.Nome.Contains(filtro.Nome, StringComparison.InvariantCultureIgnoreCase));
            if (filtro.IdCondominio.HasValue) query = query.Where(d => d.Condominio.Id == filtro.IdCondominio);

            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

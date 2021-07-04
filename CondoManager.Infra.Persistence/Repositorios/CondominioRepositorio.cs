using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using CondoManager.Domain.Interfaces.Repositorios;
using CondoManager.Infra.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CondoManager.Infra.Persistence.Repositorios
{
    public class CondominioRepositorio : ICondominioRepositorio
    {
        private readonly Context _context;

        public CondominioRepositorio(Context context)
        {
            _context = context;
        }

        public void Add(Condominio data)
        {
            _context.Condominios.Add(data);
        }

        public void Delete(Condominio data)
        {
            _context.Condominios.Remove(data);
        }


        public Condominio Find(Guid guid)
        {
            return _context.Condominios.Find(guid);
        }

        public void Update(Condominio data)
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

        public IQueryable<Condominio> BuscarPorFiltro(ICondominioFiltro filtro)
        {
            IQueryable<Condominio> query = _context.Condominios;

            if (!string.IsNullOrWhiteSpace(filtro.Nome)) query = query.Where(d => d.Nome.Contains(filtro.Nome, StringComparison.InvariantCultureIgnoreCase));

            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

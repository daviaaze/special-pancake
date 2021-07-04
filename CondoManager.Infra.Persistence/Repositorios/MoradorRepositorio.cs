using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using CondoManager.Domain.Interfaces.Repositorios;
using CondoManager.Infra.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CondoManager.Infra.Persistence.Repositorios
{
    public class MoradorRepositorio : IMoradorRepositorio
    {
        private readonly Context _context;

        public MoradorRepositorio(Context context)
        {
            _context = context;
        }

        public void Add(Morador data)
        {
            _context.Moradores.Add(data);
        }

        public void Delete(Morador data)
        {
            _context.Moradores.Remove(data);
        }


        public Morador Find(Guid guid)
        {
           return _context.Moradores.Find(guid);
        }

        public void Update(Morador data)
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

        public IQueryable<Morador> BuscarPorFiltro(IMoradorFiltro filtro)
        {
            IQueryable<Morador> query = _context.Moradores.Include(d => d.Apartamento).ThenInclude(d => d.Bloco).ThenInclude(d => d.Condominio);
            if (filtro.Andar.HasValue) query = query.Where(d => d.Apartamento.Andar == filtro.Andar);
            if (filtro.IdApartamento.HasValue) query = query.Where(d => d.Apartamento.Id == filtro.IdApartamento);
            if (filtro.IdCondominio.HasValue) query = query.Where(d => d.Apartamento.Bloco.Condominio.Id == filtro.IdCondominio);
            if (filtro.IdBloco.HasValue) query = query.Where(d => d.Apartamento.Bloco.Id == filtro.IdBloco);
            if (!string.IsNullOrWhiteSpace(filtro.Nome)) query = query.Where(d => d.Nome.Contains(filtro.Nome, StringComparison.InvariantCultureIgnoreCase));

            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using CondoManager.Domain.Entidades;
using CondoManager.Domain.Interfaces.Filtros;
using CondoManager.Domain.Interfaces.Repositorios;
using CondoManager.Infra.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Linq;

namespace CondoManager.Infra.Persistence.Repositorios
{
    public class ApartamentoRepositorio : IApartamentoRepositorio
    {
        private readonly Context _context;

        public ApartamentoRepositorio(Context context)
        {
            _context = context;
        }

        public void Add(Apartamento data)
        {
            _context.Apartamentos.Add(data);
        }

        public void Delete(Apartamento data)
        {
            _context.Apartamentos.Remove(data);
        }


        public Apartamento Find(Guid guid)
        {
            return _context.Apartamentos.Find(guid);
        }

        public void Update(Apartamento data)
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

        public IQueryable<Apartamento> BuscarPorFiltro(IApartamentoFiltro filtro)
        {
            IQueryable<Apartamento> query = _context.Apartamentos.Include(d => d.Bloco).ThenInclude(d => d.Condominio);
            if (filtro.Andar.HasValue) query = query.Where(d => d.Andar == filtro.Andar);
            if (filtro.IdBloco.HasValue) query = query.Where(d => d.Bloco.Id == filtro.IdBloco);
            if (filtro.IdCondominio.HasValue) query = query.Where(d => d.Bloco.Condominio.Id == filtro.IdCondominio);

            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

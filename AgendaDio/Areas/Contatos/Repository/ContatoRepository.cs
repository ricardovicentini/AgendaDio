using AgendaDio.Areas.Contatos.Models;
using AgendaDio.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Repository
{
    public class ContatoRepository : GenericRepository<Contato>, IContatoRepository
    {
        private readonly DbContext _dbContext;

        public ContatoRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarContatoSemFoto(Contato contato)
        {
            Update(contato);
            _dbContext.Entry(contato).Property(x => x.FotoUrl).IsModified = false;
        }
    }
}

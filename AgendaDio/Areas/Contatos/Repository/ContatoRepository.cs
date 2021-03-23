using AgendaDio.Areas.Contatos.Models;
using AgendaDio.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Repository
{
    public class ContatoRepository : GenericRepository<Contato>
    {
        public ContatoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

using AgendaDio.Areas.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Services
{
    public interface IContatoService
    {
        Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken);
        Task<IEnumerable<Contato>> ObterTodos(CancellationToken cancellationToken);
        Task<bool> ApagarContato(Guid id, CancellationToken cancellationToken);
    }
}

using AgendaDio.Areas.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Repository
{
    public interface IContatoRepository
    {
        void AtualizarContatoSemFoto(Contato contato);
    }
}

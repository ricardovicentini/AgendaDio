using AgendaDio.Areas.Contatos.Models;
using AgendaDio.Shared.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IGenericRepository<Contato> _contatoRepository;
        private readonly IWebHostEnvironment _env;

        public ContatoService(IGenericRepository<Contato> contatoRepository, IWebHostEnvironment env)
        {
            _contatoRepository = contatoRepository;
            _env = env;
        }
        public async Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken)
        {
            //salvar a image
            contato.Id = Guid.NewGuid();
            contato.FotoUrl = Path.Combine("Images", "Contatos", $"{contato.Id}-{contato.Foto.FileName}");
            var fulPath = Path.Combine(_env.WebRootPath, contato.FotoUrl);
            using (var fileStream = new FileStream(fulPath, FileMode.Create))
            {
                await contato.Foto.CopyToAsync(fileStream, cancellationToken).ConfigureAwait(false);
            }

            await _contatoRepository.AddAsync(contato, cancellationToken).ConfigureAwait(false);
            var result = await _contatoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> ApagarContato(Guid id, CancellationToken cancellationToken)
        {
            var contato = await _contatoRepository.GetByKeysAsync(cancellationToken, id).ConfigureAwait(false);
            _contatoRepository.Delete(contato);
            return await _contatoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Contato>> ObterTodos(CancellationToken cancellationToken)
        {
            return await _contatoRepository.GetAllAsync(cancellationToken: cancellationToken,
                noTracking: true);
        }
    }
}

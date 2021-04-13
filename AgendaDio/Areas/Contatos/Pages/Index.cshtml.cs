using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AgendaDio.Areas.Contatos.Models;
using AgendaDio.Areas.Contatos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaDio.Areas.Contatos.Pages
{
    public class IndexModel : PageModel
    {
        private const int QUANTIDADE_POR_PAGINA = 6;
        private readonly IContatoService _contatoService;

        public IEnumerable<Contato> Contatos { get; set; } = new List<Contato>();
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public IndexModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public async Task OnGetAsync([FromQuery] int paginaAtual = 1,  CancellationToken cancellationToken = default)
        {
            PaginaAtual = paginaAtual;
            var qtdContatos = await _contatoService.ContarCotatos(cancellationToken).ConfigureAwait(false);
            TotalPaginas = qtdContatos / QUANTIDADE_POR_PAGINA;
            Contatos =  await _contatoService.ObterTodos(paginaAtual,QUANTIDADE_POR_PAGINA,cancellationToken).ConfigureAwait(false);
            
        }

        public async Task<IActionResult> OnPostFavoriteAsync([FromQuery] Guid id, CancellationToken cancellationToken)
        {
            var result = await _contatoService.AlternarFavorito(id, cancellationToken).ConfigureAwait(false);
            if (!result)
            {
                return RedirectToPage("/Erro");
            }
            return RedirectToPage("Index");
        }
    }
}

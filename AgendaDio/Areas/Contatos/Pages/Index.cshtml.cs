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
        private readonly IContatoService _contatoService;

        public IEnumerable<Contato> Contatos { get; set; } = new List<Contato>();
        public IndexModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Contatos =  await _contatoService.ObterTodos(cancellationToken);
            
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

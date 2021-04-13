using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AgendaDio.Areas.Contatos.Models;
using AgendaDio.Areas.Contatos.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaDio.Areas.Contatos.Pages
{
    public class Index1Model : PageModel
    {
        private readonly IContatoService _contatoService;

        [BindProperty]
        public Contato Contato { get; set; } = new Contato();

        public Index1Model(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public async Task OnGetAsync([FromRoute] Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
            {
                Contato = await _contatoService.ObterPorId(id.Value, cancellationToken).ConfigureAwait(false);
            }
            
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //todo: persistir os dados
            var result = await _contatoService.Adicionar(Contato, cancellationToken).ConfigureAwait(false);
            if (!result)
            { 
                return RedirectToPage("/Error");
            }

            return RedirectToPage("Index"); 
        }

        public async Task<IActionResult> OnPostUpdateAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _contatoService.Alterar(Contato, cancellationToken).ConfigureAwait(false);
            if (!result)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("Index");
        }
    }
}

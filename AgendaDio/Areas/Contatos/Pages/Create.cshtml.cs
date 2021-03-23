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
        public Contato Contato { get; set; }

        public Index1Model(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public void OnGet()
        {
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
    }
}

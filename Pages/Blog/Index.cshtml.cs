using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EF.RazorPage.Models;

namespace EF.RazorPage.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly EF.RazorPage.Models.MyBlogContext _context;

        public IndexModel(EF.RazorPage.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name ="p")]
        public int currentPage { get; set; }

        public int countPages { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            //Article = await _context.articles.ToListAsync();
            int totalArticle = await _context.articles.CountAsync();
            countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);

            if(currentPage < 1)
                currentPage = 1;
            if(currentPage > countPages)
                currentPage = countPages;

            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a).Skip((currentPage - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
            if(!string.IsNullOrEmpty(searchString))
            {
                Article = await qr.Where(x=>x.Title.Contains(searchString) || x.Content.Contains(searchString)).ToListAsync();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
        }
    }
}

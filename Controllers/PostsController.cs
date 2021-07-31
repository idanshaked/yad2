using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using yad2.Data;
using yad2.Models;
using System.Security.Claims;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace yad2.Controllers
{
    public class PostsController : Controller
    {
        private readonly yad2Context _context;

        public PostsController(yad2Context context)
        {
            _context = context;
        }

        // GET: Posts
        [Authorize]
        public async Task<IActionResult> Index()
        {

            string username = ((ClaimsIdentity)User.Identity).Name;
            if (!String.IsNullOrEmpty(username))
            {
                var users = from u in _context.User
                            where u.Username == username && u.isAdmin
                            select u;
                if (users.Count() == 0)
                {
                    return RedirectToAction(nameof(UsersController.AccessDenied), "Users");
                }
                else
                {
                    var posts = await _context.Posts.ToListAsync();

                    foreach (Post post in posts)
                    {
                        var product = _context.Products.Where(x => x.PostID.Equals(post.PostID)).FirstOrDefault();
                        post.Product = product;

                    }

                    return View(posts);
                }
            }
            else
            {
                return RedirectToAction(nameof(UsersController.AccessDenied), "Users");
            }
           
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
               .Include(a => a.Tags).Include(a => a.Product).ThenInclude(p => p.store).Include(a => a.Publisher).Select( p=> new Post
               {
                   PostID = p.PostID,
                   PublishDate = p.PublishDate,
                   PicUrls = p.PicUrls,
                   Tags = p.Tags,
                   Publisher = new User
                   {
                       Username = p.Publisher.Username,
                       Phone = p.Publisher.Phone,
                       Email = p.Publisher.Email
                   },
                   Product = p.Product
               })
               .FirstOrDefaultAsync(m => m.PostID == id);
            ViewBag.Tags = post.Tags;
            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public async Task<ViewResult> Create()
        {

            var tags = _context.Tags.Select(tag => new {
                tageName = tag.tageName,
                tagId = tag.tagId
            }).ToList();
            var stores = _context.Store.Select(store => new {
                storeName = store.storeName,
                storeId = store.storeId.ToString()
            }).ToList();

            ViewBag.tags = new MultiSelectList(tags, "tagId", "tageName");
            ViewBag.stores = new MultiSelectList(stores, "storeId", "storeName");
            return View();

        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,PicUrls,PublishDate")] Post post, Product product, int[] tagsIds)
        {
            if (ModelState.IsValid)
            {
                string username = ((ClaimsIdentity)User.Identity).Name;
                post.Publisher = _context.User.Where(x => x.Username.Equals(username)).FirstOrDefault();
                post.Product = product;
                post.PublishDate = DateTime.Now;
                post.PicUrls = post.PicUrls;
                post.Tags = new List<Tags>();
                foreach (var id in tagsIds)
                {
                    post.Tags.Add(_context.Tags.FirstOrDefault(p => p.tagId == id));
                }

                _context.Posts.Add(new Post { 
                    PublishDate = post.PublishDate,
                    Product = product,
                    Publisher = _context.User.Where(x => x.Username.Equals(username)).FirstOrDefault(),
                    PicUrls = post.PicUrls,
                    Tags = post.Tags
                }); 
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostID,PicUrls,PublishDate")] Post post)
        {
            if (id != post.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostID == id);
        }
    }
}

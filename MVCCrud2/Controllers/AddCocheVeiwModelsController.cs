using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCrud2;
using MVCCrud2.Models;
using MVCCrud2.VeiwModels;

namespace MVCCrud2.Controllers
{
    public class AddCocheVeiwModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Marca _marca;

        public AddCocheVeiwModelsController(ApplicationDbContext context, Marca marca)
        {
            _context = context;
            _marca = marca;
        }

        //
        private void SetList(ref AddCocheVeiwModel model)
        {
            List<int> authorizedFranchisesIds = _franchiseService.GetAuthorizedFranchiseIds(_userId).Result;

            model.Franchises = _franchiseService.List(authorizedFranchisesIds);
            model.ClientCategories = _clientCategoryService.List();
            model.ClientStatuses = _clientStatusService.List();

            model.Marca = _marca.List();
        }
        //




        // GET: AddCocheVeiwModels
        public async Task<IActionResult> Index()
        {
              return _context.AddCocheVeiwModel != null ? 
                          View(await _context.AddCocheVeiwModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AddCocheVeiwModel'  is null.");
        }

        // GET: AddCocheVeiwModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddCocheVeiwModel == null)
            {
                return NotFound();
            }

            var addCocheVeiwModel = await _context.AddCocheVeiwModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addCocheVeiwModel == null)
            {
                return NotFound();
            }

            return View(addCocheVeiwModel);
        }

        // GET: AddCocheVeiwModels/Create
        public IActionResult Create()
        {
            AddCocheVeiwModel model = new AddCocheVeiwModel();
            SetList
            return View(model);


            AddViewModel model = new AddViewModel();
            SetList(ref model);

            if (originPointId > 0)
            {
                SetDataFromOriginPoint(ref model, originPointId);
            }

            return View(model);
        }

        // POST: AddCocheVeiwModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,Modelo,Color,MarcaId")] AddCocheVeiwModel addCocheVeiwModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addCocheVeiwModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addCocheVeiwModel);
        }

        // GET: AddCocheVeiwModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddCocheVeiwModel == null)
            {
                return NotFound();
            }

            var addCocheVeiwModel = await _context.AddCocheVeiwModel.FindAsync(id);
            if (addCocheVeiwModel == null)
            {
                return NotFound();
            }
            return View(addCocheVeiwModel);
        }

        // POST: AddCocheVeiwModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Modelo,Color,MarcaId")] AddCocheVeiwModel addCocheVeiwModel)
        {
            if (id != addCocheVeiwModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addCocheVeiwModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddCocheVeiwModelExists(addCocheVeiwModel.Id))
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
            return View(addCocheVeiwModel);
        }

        // GET: AddCocheVeiwModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddCocheVeiwModel == null)
            {
                return NotFound();
            }

            var addCocheVeiwModel = await _context.AddCocheVeiwModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addCocheVeiwModel == null)
            {
                return NotFound();
            }

            return View(addCocheVeiwModel);
        }

        // POST: AddCocheVeiwModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddCocheVeiwModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AddCocheVeiwModel'  is null.");
            }
            var addCocheVeiwModel = await _context.AddCocheVeiwModel.FindAsync(id);
            if (addCocheVeiwModel != null)
            {
                _context.AddCocheVeiwModel.Remove(addCocheVeiwModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddCocheVeiwModelExists(int id)
        {
          return (_context.AddCocheVeiwModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

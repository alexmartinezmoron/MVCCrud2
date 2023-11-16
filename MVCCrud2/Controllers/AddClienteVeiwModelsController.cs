using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCrud2;
using MVCCrud2.Models;
using MVCCrud2.VeiwModels;

namespace MVCCrud2.Controllers
{
    public class AddClienteVeiwModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddClienteVeiwModelsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: AddClienteVeiwModels
        public async Task<IActionResult> Index()
        {
            if (_context.Clientes != null)
            {
                var clientes = await _context.Clientes.ToListAsync();
                var model = _mapper.Map<List<AddClienteVeiwModel>>(clientes);

                return View(model);
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes' is null.");
            }
        }


        // GET: AddClienteVeiwModels/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);

           
            if (cliente == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<AddClienteVeiwModel>(cliente);
            



            return View(model);
        }




        // GET: AddClienteVeiwModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddClienteVeiwModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,pass")] AddClienteVeiwModel addClienteVeiwModel)
        {
            var cliente = _mapper.Map<Cliente>(addClienteVeiwModel);

                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

 

        // GET: AddClienteVeiwModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddClienteVeiwModel == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            // Mapemos de Cliente a ClienteDTO con automapper
            var addClienteVeiwModel = _mapper.Map<AddClienteVeiwModel>(cliente);
            return View(addClienteVeiwModel);
        }


    

        // POST: AddClienteVeiwModels/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,pass")] AddClienteVeiwModel addClienteVeiwModel)
        {
            if (id != addClienteVeiwModel.Id)
            {
                return NotFound();
            }

            // tengo problemas  con el if por lo que igualo un absurdo para descartar
           // if (ModelState.IsValid)
                
            if (id == addClienteVeiwModel.Id)
            {
                var cliente = await _context.Clientes.FindAsync(id);

               //Actualizar propiedades del cliente con los valores del modelo editado
                   //cliente.Nombre = addClienteVeiwModel.Nombre;
                   //cliente.Apellido = addClienteVeiwModel.Apellido;
                   //cliente.Email = addClienteVeiwModel.Email;
                   //cliente.pass = addClienteVeiwModel.pass;

                // Mapeo desde el modelo al cliente existente
                _mapper.Map(addClienteVeiwModel, cliente);


                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddClienteVeiwModelExists(addClienteVeiwModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(addClienteVeiwModel);

        }





        // GET: AddClienteVeiwModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            // Mapemos de Cliente a ClienteDTO con automapper
            var addClienteVeiwModel = _mapper.Map<AddClienteVeiwModel>(cliente);
            return View(addClienteVeiwModel);

            ///
           
            //
        }


        //              EN PROCESO ------------------------------------------------------------------------

        // POST: AddClienteVeiwModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddClienteVeiwModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AddClienteVeiwModel'  is null.");
            }
            var addClienteVeiwModel = await _context.AddClienteVeiwModel.FindAsync(id);
            if (addClienteVeiwModel != null)
            {
                _context.AddClienteVeiwModel.Remove(addClienteVeiwModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddClienteVeiwModelExists(int id)
        {
          return (_context.AddClienteVeiwModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

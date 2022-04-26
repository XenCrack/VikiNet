using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using VikiNet.Data.Abstract;
using VikiNet.Data.ViewModels;
using VikiNet.Models;

namespace VikiNet.Controllers
{

    
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var subject = await _subjectService.GetAllAsync();
            return View(subject);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description")]Subject model)
        {
            if (!ModelState.IsValid) return View(model);
            
            await _subjectService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);

            if (subject == null) return NotFound();

            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subject model)
        {
            model.ModifyDate = DateTime.Now;
            await _subjectService.UpdateAsync(model.Id, model);

            return RedirectToAction("Index");

        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);

            if (subject == null) return NotFound();

            return View(subject);
        }
    }
}

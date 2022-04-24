using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using VikiNet.Data.Abstract;
using VikiNet.Data.ViewModels;

namespace VikiNet.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var subject = await _service.GetAllAsync(n => n.SubjectType);
        
            return View(subject);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var dropdown = await _service.GetSubjectDropdownValues();

            ViewBag.Subjects = new SelectList(dropdown.Subjects, "Id", "Name");

            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var dropdown = await _service.GetSubjectDropdownValues();

                ViewBag.Subjects = new SelectList(dropdown.Subjects, "Id", "Name");
                
                return View(model);
            }

            await _service.AddAsync(model);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var subjectDetail = await _service.GetSubjectByIdAsync(id);

            return View(subjectDetail);
        }

    }
}

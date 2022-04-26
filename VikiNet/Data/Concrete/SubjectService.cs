using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VikiNet.Data.Base;
using VikiNet.Data.ViewModels;
using VikiNet.Entity;
using VikiNet.Models;
using VikiNet.Data.Abstract;

namespace VikiNet.Data.Concrete
{
    public class SubjectService : EntityBaseRepository<Subject>, ISubjectService
    {
        private readonly VikiNetDbContext _context;

        public SubjectService(VikiNetDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(SubjectViewModel model)
        {
            var subject = new Subject()
            {
                Name = model.Name,
                Description = model.Description,
                CreateDate = model.CreatedDate,
                SubjectTypeId = model.TypeId,
                ModifiedDate = model.ModifiedDate,
                ImageUrl = model.ImageUrl
            
            };
            await _context.Subject.AddAsync(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            var result = await
                _context
                .Subject
                .Include(s=> s.SubjectType)
                .FirstOrDefaultAsync( x => x.Id == id);

            return result;
        }

        public async Task<SubjectDropdownViewModel> GetSubjectDropdownValues()
        {
            var response = new SubjectDropdownViewModel()
            {
                SubjectTypes = await _context.SubjectType.OrderBy(x => x.SubjectName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateAsync(SubjectViewModel model)
        {
            var subject = await (from s in _context.Subject where s.Id == model.Id select s).FirstOrDefaultAsync();

            if(subject == null)
            {
                subject.Name = model.Name;
                subject.Description = model.Description;
                subject.CreateDate = model.CreatedDate;
                subject.SubjectTypeId = model.TypeId;
                subject.ModifiedDate = model.ModifiedDate;
                subject.ImageUrl = model.ImageUrl;

                await _context.SaveChangesAsync();
            }

        }

       


    }
}

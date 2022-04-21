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
                SubjectName = model.SubjectName,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate
            };
            await _context.Subject.AddAsync(subject);
            await _context.SaveChangesAsync();

        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            var result = await
                _context
                .Subject
                .Include(st => st.SubjectName)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<SubjectDropdownViewModel> GetSubjectDropdownValues()
        {
            var response = new SubjectDropdownViewModel()
            {
                Subjects = await _context.Subject.OrderBy(x => x.SubjectType).ToListAsync()
            };
            return response;
        }

        public async Task UpdateAsync(SubjectViewModel model)
        {
            var subject = await _context.Subject.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (subject != null)
            {
                subject.Name = model.Name;
                subject.SubjectName = model.SubjectName;
                subject.CreatedDate = model.CreatedDate;
                subject.ModifiedDate = model.ModifiedDate;

                await _context.SaveChangesAsync();
            }
        }


    }
}

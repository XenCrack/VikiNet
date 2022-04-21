using System.Threading.Tasks;
using VikiNet.Data.Base;
using VikiNet.Data.ViewModels;
using VikiNet.Models;

namespace VikiNet.Data.Abstract
{
    public interface ISubjectService : IEntityBaseRepository<Subject>
    {
        Task AddAsync(SubjectViewModel model);
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<SubjectDropdownViewModel> GetSubjectDropdownValues();
        Task UpdateAsync(SubjectViewModel model);
    }
}
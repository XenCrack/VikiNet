using System.Collections.Generic;
using VikiNet.Models;

namespace VikiNet.Data.ViewModels
{
    public class SubjectDropdownViewModel
    {
        public SubjectDropdownViewModel()
        {
            Subjects = new List<Subject>();
        }

        public List<Subject> Subjects { get; set; }
    }
}

using System.Collections.Generic;
using VikiNet.Models;

namespace VikiNet.Data.ViewModels
{
    public class SubjectDropdownViewModel
    {
        public SubjectDropdownViewModel()
        {
            SubjectTypes = new List<SubjectType>();
        }

        public List<SubjectType> SubjectTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VikiNet.Data.Abstract;
using VikiNet.Data.Base;
using VikiNet.Data.ViewModels;
using VikiNet.Entity;
using VikiNet.Models;

namespace VikiNet.Data.Concrete
{
    public class SubjectTypeService :  EntityBaseRepository<SubjectType> , ISubjectTypeService
    {
        private readonly SubjectTypeService _vikiNetDbContext;
        public SubjectTypeService(VikiNetDbContext options): base(options)
        {
            
        }

      
    }
}

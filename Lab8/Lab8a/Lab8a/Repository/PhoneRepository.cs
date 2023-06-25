using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab8a.Model;

namespace Lab8a.Repository
{
    public class PhoneRepository : GenericRepository<Phone>
    {
        public PhoneRepository(ContactContext context) : base(context)
        {
        }
    }
}

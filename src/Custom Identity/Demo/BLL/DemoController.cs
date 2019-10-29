using Demo.DAL;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    [DataObject]
    public class DemoController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Person> ListImportantPeople()
        {
            using(var context = new DemoContext())
            {
                return context.People.ToList();
            }
        }
    }
}

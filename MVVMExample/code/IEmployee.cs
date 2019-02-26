using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExample
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Role { get; set; }
        int Age { get; set; }
        int Fee { get; set; }
    }
}

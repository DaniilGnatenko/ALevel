using HomeworkModule2Lesson6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson6.Services.Abstractions
{
    internal interface IUserService
    {
        void PlugIn(int id);
        void PlugOut(int id);
        void FindAppliance(string name);

    }
}

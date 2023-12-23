using HomeworkModule2Lesson4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson4.Repositories.Abstractions
{
    internal interface ISalad
    {
        string AddNewIngridient(Ingridient ingridient);
        decimal CalculateCaloriesInSalad();
        List<Ingridient> FindIngridientbyType(string type);
        List<Ingridient> SortSalad();
    }
}

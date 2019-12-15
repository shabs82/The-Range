using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity.Mens;

namespace Final_exam_project.core.DomainService.MensIRepository
{
   public  interface ITopsRepository
    {
        Tops NewTops(string Category, int Size, string Colour, string Brand, string Sleeve, string Fit, Decimal Price);
        Tops CreateTops(Tops tops);
        IEnumerable<Tops> ReadByID(Tops tops);
        IEnumerable<Tops> ReadAll();
        void UpdateTops(int Id, Tops tops);
        void DeleteTops(int Id);
        IEnumerable<Tops> SortTopsByColour();
    }
}

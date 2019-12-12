using System;
using System.Collections.Generic;
using TheRange.Core.Entity.Mens;

namespace Final_exam_project.core.ApplicationService.MensIService
{
    public interface ITopsService
    {
        Tops NewTops(string Category ,int Size, string Colour, string Brand, string Sleeve, string Fit ,Decimal Price);
        Tops CreateTops(Tops tops);
        List<Tops> ReadByID(Tops tops);
        List<Tops> ReadAll();
        void UpdateTops(int Id, Tops tops);
        void DeleteTops(int Id);
        Tops SearchTops(Tops tops);
        List<Tops> SortTopsByPrice();
    }
}

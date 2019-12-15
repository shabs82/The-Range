using System;
using System.Collections.Generic;
using TheRange.Core.Entity.Mens;

namespace Final_exam_project.core.ApplicationService.MensIService
{
    public interface ISweatshirtsService
    {
        Sweatshirts NewSweatshirts(int Size , string Colour , string Brand , string Pattern , Decimal Price);
        Sweatshirts CreateSweatshirts(Sweatshirts sweatshirts);
        List<Sweatshirts> ReadByID(Sweatshirts sweatshirts);
        List<Sweatshirts> ReadAll();
        void UpdateSweatshirts(int Id, Sweatshirts sweatshirts);
        void DeleteSweatshirts(int Id);
        Sweatshirts SearchSweatshirts(Sweatshirts sweatshirts);
        List<Sweatshirts> SortSweatshirtsByColour();

    }
}

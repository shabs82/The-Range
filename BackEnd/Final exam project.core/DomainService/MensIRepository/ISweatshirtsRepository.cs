using System;
using System.Collections.Generic;
using System.Text;
using TheRange.Core.Entity.Mens;

namespace Final_exam_project.core.DomainService.MensIRepository
{
    public interface ISweatshirtsRepository
    {
        Sweatshirts NewSweatshirts(int Size, string Colour, string Brand, string Pattern, Decimal Price);
        Sweatshirts CreateSweatshirts(Sweatshirts sweatshirts);
        List<Sweatshirts> ReadByID(Sweatshirts sweatshirts);
        List<Sweatshirts> ReadAll();
        void UpdateSweatshirts(int Id, Sweatshirts sweatshirts);
        void DeleteSweatshirts(int Id);
        List<Sweatshirts> SortSweatshirtsByPrice();

    }
}

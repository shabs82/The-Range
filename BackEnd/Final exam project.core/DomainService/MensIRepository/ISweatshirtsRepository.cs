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
        IEnumerable<Sweatshirts> ReadByID(Sweatshirts sweatshirts);
        IEnumerable<Sweatshirts> ReadAll();
        void UpdateSweatshirts(int Id, Sweatshirts sweatshirts);
        void DeleteSweatshirts(int Id);
        IEnumerable<Sweatshirts> SortSweatshirtsByColour();

    }
}

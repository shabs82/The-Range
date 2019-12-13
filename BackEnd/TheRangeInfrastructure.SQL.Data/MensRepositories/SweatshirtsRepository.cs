using System;
using System.Collections.Generic;
using System.Text;
using Final_exam_project.core.DomainService.MensIRepository;
using TheRange.Core.Entity.Mens;

namespace TheRange.Infrastructure.SQL.Data.MensRepositories
{
    public class SweatshirtsRepository : ISweatshirtsRepository
    {
        public Sweatshirts CreateSweatshirts(Sweatshirts sweatshirts)
        {
            throw new NotImplementedException();
        }

        public void DeleteSweatshirts(int Id)
        {
            throw new NotImplementedException();
        }

        public Sweatshirts NewSweatshirts(int Size, string Colour, string Brand, string Pattern, decimal Price)
        {
            throw new NotImplementedException();
        }

        public List<Sweatshirts> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Sweatshirts> ReadByID(Sweatshirts sweatshirts)
        {
            throw new NotImplementedException();
        }

        public List<Sweatshirts> SortSweatshirtsByPrice()
        {
            throw new NotImplementedException();
        }

        public void UpdateSweatshirts(int Id, Sweatshirts sweatshirts)
        {
            throw new NotImplementedException();
        }
    }
}

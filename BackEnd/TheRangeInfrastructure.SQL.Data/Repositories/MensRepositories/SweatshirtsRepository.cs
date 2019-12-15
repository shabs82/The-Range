using System;
using System.Collections.Generic;
using System.Text;
using Final_exam_project.core.DomainService.MensIRepository;
using TheRange.Core.Entity.Mens;

namespace TheRange.Infrastructure.SQL.Data.MensRepositories
{
    public class SweatshirtsRepository : ISweatshirtsRepository
    {
        readonly TheRangeContext _ctx;

        public SweatshirtsRepository(TheRangeContext ctx)
        {
            _ctx = ctx;
        }
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

        public IEnumerable<Sweatshirts> SortSweatshirtsByColour()
        {
            throw new NotImplementedException();
        }

        
        public void UpdateSweatshirts(int Id, Sweatshirts sweatshirts)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Sweatshirts> ISweatshirtsRepository.ReadAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Sweatshirts> ISweatshirtsRepository.ReadByID(Sweatshirts sweatshirts)
        {
            throw new NotImplementedException();
        }
    }
}

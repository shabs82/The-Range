using System;
using System.Collections.Generic;
using System.Text;
using Final_exam_project.core.DomainService.MensIRepository;
using TheRange.Core.Entity.Mens;

namespace TheRange.Infrastructure.SQL.Data.MensRepositories
{
    public class TopsRepository : ITopsRepository
    {
        public Tops CreateTops(Tops tops)
        {
            throw new NotImplementedException();
        }

        public void DeleteTops(int Id)
        {
            throw new NotImplementedException();
        }

        public Tops NewTops(string Category, int Size, string Colour, string Brand, string Sleeve, string Fit, decimal Price)
        {
            throw new NotImplementedException();
        }

        public List<Tops> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Tops> ReadByID(Tops tops)
        {
            throw new NotImplementedException();
        }

        public List<Tops> SortTopsByColour()
        {
            throw new NotImplementedException();
        }

        public void UpdateTops(int Id, Tops tops)
        {
            throw new NotImplementedException();
        }
    }
}

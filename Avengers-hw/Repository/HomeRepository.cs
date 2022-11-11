using Avengers_hw.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Avengers_hw.Repository
{
    public interface IHomeRepository
    {
        void SeacrhAvenger();
        void SeacrhItem();
        IEnumerable<Avengers> Results(string fName);
        string LinkResults();
        IEnumerable<Avengers> SendAsJson(string name);
        IEnumerable<Avengers> GetTable();
    }

    public class HomeRepository : IHomeRepository
    {

        private AvengersEntities db;
        public AvengersEntities dbEntities
        {
            get { return db; }
            set { db = value; }
        }
        public HomeRepository(AvengersEntities dbcontext)
        {
            db = dbcontext;
        }
        public void SeacrhAvenger()
        {
            db.Avengers.Select(x => x.hero).Distinct();
        }

        public void SeacrhItem()
        {
            db.Avengers.Select(x => x.hero).Distinct();
        }

        public IEnumerable<Avengers> Results(string fName)
        {
            return db.Avengers.Where(x => x.name.Contains(fName)).ToList();
        }

        public string LinkResults()
        {
            return db.Avengers.Select(x => x.hero).Distinct().ToString();
        }

        public IEnumerable<Avengers> SendAsJson(string name)
        {
            return db.Avengers.Where(x => x.name.Contains(name)).ToList();
        }


        public IEnumerable<Avengers> GetTable()
        {
            return db.Avengers.ToList();
        }

    }
}
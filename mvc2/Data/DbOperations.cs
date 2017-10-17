using mvc2.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc2.Data
{
    public class DbOperations : IDbOperations
    {
        private SkiersEntities db = new SkiersEntities();

        public List<Skier> GetSkiers()
        {
            var skiers = db.Skier.Include(s => s.Country);
            return skiers.ToList();
        }

        public Skier GetSkierById(int id)
        {
            return null;
        }
    }
}
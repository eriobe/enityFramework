using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc2.Models.db;

namespace mvc2.Data
{
    public class TestData : IDbOperations
    {
        
        public Skier GetSkierById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skier> GetSkiers()
        {
            throw new NotImplementedException();
        }
    }
}
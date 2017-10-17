using mvc2.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc2.Data
{
    interface IDbOperations
    {
        List<Skier> GetSkiers();
        Skier GetSkierById(int id);
    }
}

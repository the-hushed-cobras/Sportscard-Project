using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportscardDbCodeFirst.Data;

namespace SportscardDbCodeFirst.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SportscardDbContext())
            {
                ctx.SaveChanges();
            }
        }
    }
}

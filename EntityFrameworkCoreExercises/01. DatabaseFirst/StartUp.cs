using P02_DatabaseFirst.Data;
using System.Linq;

namespace P02_DatabaseFirst
{
    class StartUp
    {
        static void Main()
        {
            var db = new SoftUniDbContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoq.DAL
{
    public interface IAnswers
    {
        string HelloWorld();
        string EmptyString();
        bool True();
        bool False();
        List<int> ListOfInts();
        int Zero();
        int One();
        int Two();
        int Three();
        int Four();
    }
}

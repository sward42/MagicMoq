using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicMoq.DAL
{
    public interface IQuestions
    {
        int OnePlusOne();
        int OnePlusTwo();
        int OneMinusOne();
        string SayNothing();
        bool ReturnFalse();
        bool ReturnTrue();
        string SayHelloWorld();
        List<int> ReturnListOfInts();
    }
}

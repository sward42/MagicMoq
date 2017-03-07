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
        int ZeroPlusZero();
        int FourPlusZero();
        int TwoMinusZero();
        int OnePlusTwo();
        int TwoPlusTwo();
        int OneMinusOne();
        int FourMinusTwo();
        int FourMinusTwoPlusOne();
        string SayNothing();
        bool ReturnFalse();
        bool ReturnTrue();
        string SayHelloWorld();
        List<int> CountToFive();
        List<int> FirstThreeEvenInts();
        List<int> FirstThreeOddInts();
    }
}

using Hello;
using Sec2;
using sec3;
using sec4;
using sec5;
using sec6;
using sec7;
using sec8;
using sec9;
using sec10;
using sec12;
using stopwatch;

class Program{
    static void Main(string[] args)
    {
        sec1.Hello1();
        Args.Arg(args);
        Variables.Show();
        StringsExample.Show();
        VarTypes.Show();
        NullExamples.Show();
        SwitchExamples.Show(-5);
        PatternMatching.Show();
        LogicExamples.Show();
        ArithmeticExamples.Show();
        LoopExamples.Show();
        PerformanceTest.Compare();
    }
}
using GrainInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class TestGrain : Orleans.Grain, ITestGrain
    {
        Task<string> ITestGrain.TestGrain(string testArg)
        {
            return Task.FromResult(testArg + " Hello from Test");
        }
    }
}

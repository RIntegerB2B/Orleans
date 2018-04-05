using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterface
{
    public interface ITestGrain : Orleans.IGrainWithStringKey
    {
        Task<string> TestGrain(string testArg);
    }
}

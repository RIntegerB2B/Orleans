using Dell.Solution.ItemApi.Model;
using System;

namespace GrainInterface
{
    public class SolutionItm
    {
        public string Id { get; set; }

        public string ProductKey { get; set; }

        public SolutionConfigItemLite SolutionConfigItemLite { get; set; }

        public SolutionConfigItem SolutionConfigItem { get; set; }

    }
}
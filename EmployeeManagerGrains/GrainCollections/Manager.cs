using GrainInterfaces;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainCollections
{
    [StorageProvider(ProviderName = "FileStore")]
    public class Manager : Orleans.Grain<ManagerState>, IManager
    {
        private IEmployee _me;
        private List<IEmployee> _reports = new List<IEmployee>();

        public override Task OnActivateAsync()
        {
            _me = this.GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }

        public Task<List<IEmployee>> GetDirectReports()
        {
            return Task.FromResult(_reports);
        }

        public async Task AddDirectReport(IEmployee employee)
        {
            if (State.Reports == null)
            {
                State.Reports = new List<IEmployee>();
            }
            State.Reports.Add(employee);
            await employee.SetManager(this);
            var data = new GreetingData { From = this.GetPrimaryKey(), Message = "Welcome to my team!" };
            await employee.Greeting(data);
            Console.WriteLine("{0} said: {1}",
                                data.From.ToString(),
                                data.Message);

            await base.WriteStateAsync();
        }

        public Task<IEmployee> AsEmployee()
        {
            return Task.FromResult(_me);
        }

        
    }
}

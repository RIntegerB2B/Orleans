using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Solution.ItemApi.Model
{
    [Serializable]
    [ProtoContract]
    public class VariableAspect
    {
        [ProtoMember(1)]
        public double? Duration { get; set; }

        [ProtoMember(2)]
        public double? Minimum { get; set; }

        [ProtoMember(3)]
        public double? Maximum { get; set; }

        [ProtoMember(4)]
        public string UnitOfMeasure { get; set; }

        public int DurationMonths => Duration.HasValue ? Convert.ToInt32(Math.Floor(Duration.Value)) : 0;

        public int GetYears()
        {
            var months = Duration;
            var years = 0.0;

            if (months != null && months.Value >= 12)
            {
                years = Math.Floor(months.Value / 12);
            }

            return Convert.ToInt32(years);
        }

        public int GetMonths()
        {
            var months = 0.0;
            var totalDays = (Duration * 30);

            if (totalDays >= 360)
            {
                var years = Math.Floor(totalDays.Value / 360);
                totalDays = totalDays - (years * 360);
            }

            months = (totalDays / 30 >= 1) ? Math.Floor(totalDays.Value / 30) : 0.0;

            return Convert.ToInt32(months);
        }

        public int GetDays()
        {
            var days = 0.0;
            var totalDays = (Duration * 30);

            if (totalDays >= 360)
            {
                var years = Math.Floor(totalDays.Value / 360);
                totalDays = totalDays - (years * 360);
            }

            if (totalDays / 30 >= 1)
            {
                var months = Math.Floor(totalDays.Value / 30);
                totalDays = totalDays - (months * 30);
            }

            if (totalDays > 0)
                days = (int)totalDays;

            return Convert.ToInt32(days);
        }
    }
}

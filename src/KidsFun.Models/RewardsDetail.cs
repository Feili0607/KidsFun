using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFun.Models
{
    public class RewardsDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public RewardsType Type { get; set; }

        public KidDetail Kid { get; set; }

        public int ActualPointsRedeemed { get; set; }
    }
}

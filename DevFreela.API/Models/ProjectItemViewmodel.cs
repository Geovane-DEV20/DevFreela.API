using DevFreela.API.Entities;
using System.Xml.Linq;

namespace DevFreela.API.Models
{
    public class ProjectItemViewmodel
    {
        public ProjectItemViewmodel(int id, string clientName, string freelancerName, decimal totalCost)
        {
            Id = id;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }

    }
}

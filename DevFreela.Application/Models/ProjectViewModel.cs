﻿
using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, List<ProjectComment> comments, int idClient, int idFreelancer, string clientName, string freelancerName, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Error { get; private set; }

        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<string> Comments { get; private set; }


        public static ProjectViewModel FromEntity(Project entity) => new ProjectViewModel(
    entity.Id,
    entity.Title,
    entity.Description,
    entity.Comments, 
    entity.IdClient,
    entity.IdFreelancer, 
    entity.Client.FullName,
    entity.Freelancer.FullName, 
    entity.TotalCost
);


    }
}

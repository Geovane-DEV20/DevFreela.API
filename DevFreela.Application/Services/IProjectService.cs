using Azure;
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public interface IProjectService
    {
        ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "");
        ResultViewModel<ProjectViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateProjectInputModel model);
        ResultViewModel Update(UpdateProjectInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel Start(int id);
        ResultViewModel Complete(int id);
        ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model);


        public class ProjectService : IProjectService
        {

            private readonly DevFreelaDbContext _context;
            public ProjectService(DevFreelaDbContext context)
            {
                _context = context;
            }
            public ResultViewModel Complete(int id)
            {
                throw new NotImplementedException();
            }

            public ResultViewModel Delete(int id)
            {
                throw new NotImplementedException();
            }

            public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "")
            {

                var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => p.IsDeleted).ToList();
            
                var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            
                
                return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
            }

            public ResultViewModel<ProjectViewModel> GetById(int id)
            {

                var project = _context.Projects.Include(p => p.Client)
                    .Include(p => p.Freelancer)
                    .Include(p => p.Comments)
                    .SingleOrDefault(p => p.Id == id);

                if(project is null)
                {
                    return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
                }

                var model = ProjectViewModel.FromEntity(project);
                return ResultViewModel<ProjectViewModel>.Success(model);
            }

            public ResultViewModel<int> Insert(CreateProjectInputModel model)
            {
                var project = model.ToEntity();

                _context.Projects.Add(project);

                _context.SaveChanges();

                return ResultViewModel<int>.Success(project.Id);
            }

            public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
            {
                throw new NotImplementedException();
            }

            public ResultViewModel Start(int id)
            {
                throw new NotImplementedException();
            }

            public ResultViewModel Update(UpdateProjectInputModel model)
            {

                var project = _context.Projects.AsNoTracking().SingleOrDefault(p => p.Id == model.IdProject);

                if (project is null)
                {
                    return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");

                }

                project.Update(model.Title, model.Description, model.TotalCost);

                _context.Projects.Update(project);

                _context.SaveChanges();
                throw new NotImplementedException();
            }

        }
    }
}

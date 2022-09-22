using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.VievModels
{
    public class ProjectModel
    {
        private List<Project> projects;

        public ProjectModel(Project project)
        {
            Id = project.ProjectId;
            UserId = project.UserId;
            Name = project.Name;
            Description = project.Description;
            BeginDate = project.BeginDate.ToString("dd.MM.yy");
            EndDate = project.EndDate.ToString("dd.MM.yy");
            Deleted = project.Deleted;
        }

        public ProjectModel() { }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public bool Deleted { get; set; }
    }
}

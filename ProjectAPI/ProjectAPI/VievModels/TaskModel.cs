using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.VievModels
{
    public class TaskModel
    {
        public TaskModel(Tasks tasks)
        {
            id = tasks.TasksId.ToString();
            ProjectId = tasks.ProjectId;
            name = tasks.Name;
            start = tasks.Start.ToString("dd.MM.yy");
            end = tasks.End.ToString("dd.MM.yy");
            progress = tasks.Progress;
            dependencies = tasks.Dependecies;
            Deleted = tasks.Deleted;
        }
        public TaskModel() { }

        public string id { get; set; }
        public int ProjectId { get; set; }
        public string name { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int progress { get; set; }
        public string dependencies { get; set; }
        public bool Deleted { get; set; }
    }
}

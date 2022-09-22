using ProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.VievModels
{
    public class ChartModel
    {
        public ChartModel(Tasks tasks)
        {
            id = tasks.TasksId.ToString();
            name = tasks.Name;
            start = tasks.Start.ToString("yyyy-MM-dd");
            end = tasks.End.ToString("yyyy-MM-dd");
            progress = tasks.Progress;
            dependencies = tasks.Dependecies;
        }

        public string id { get; set; }
        public string name { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int progress { get; set; }
        public string dependencies { get; set; }
    }
}

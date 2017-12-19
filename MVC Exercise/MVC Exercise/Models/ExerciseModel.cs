using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Exercise.Models
{
    public class ExerciseModelContext
    {
        public IList<ProjectModel> ProjectList { get; set; }
    }

    public class ProjectModel
    {
        public int ProjectID { get; set; }
        public string ProjectNumber { get; set; }
        public IList<SubmissionModel> AllSubmissions { get; set; }

    }
    public class SubmissionModel
    {
        public string SubmissionType { get; set; }
        public int SubmissionID { get; set; }
        public string SubmissionNumber { get; set; }
        public int ProjectID { get; set; }
    }
}

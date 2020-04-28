using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.FYP
{
    public class StudentProposal
    {

        //public StudentProposal(string ProjectTitle, string ProjectType, string Abstract, int SupervisorID, int CoSupervisorID, int Student0ID)
        //{
        //    this.ProjectTitle = ProjectTitle;
        //    this.ProjectType = ProjectType;
        //    this.Abstract = Abstract;
        //    this.SupervisorID = SupervisorID;
        //    this.CoSupervisorID = CoSupervisorID;
        //    this.Student0ID = Student0ID;
        //}

        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }
        public string Abstract { get; set; }
        public int SupervisorID { get; set; }
        public int CoSupervisorID { get; set; }
        public int Student0ID { get; set; }

       
    }
}
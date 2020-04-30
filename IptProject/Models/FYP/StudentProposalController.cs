using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.FYP
{
    public class StudentProposal
    {
        
        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }
        public string Abstract { get; set; }
        public int SupervisorID { get; set; }
        public int CoSupervisorID { get; set; }
        public int LeaderID { get; set; }
        public int Member1ID { get; set; }
        public int Member2ID { get; set; }

        
    }

    public class ProposalID
    {
        public int ProposalID1 { get; set; }
    }

    public class MainPageModel
    {
        public StudentProposal StudentProposal { get; set; }
        public ProposalID ProposalID { get; set; }
    }
}
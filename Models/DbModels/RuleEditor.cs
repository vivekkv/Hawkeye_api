using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Admin_Backend.Models.DbModels
{
    public class RuleEditor
    {

        public RuleEditor()
        {
            Summary = string.Empty;
            FalsePos = string.Empty;
            FalseNeg = string.Empty;
            Tags = string.Empty;
            Impact = string.Empty;
            Information = string.Empty;
            AffectedSystems = string.Empty;
            AttackScenarios = string.Empty;
            CorrectiveAction = string.Empty;
            ;
        }
        public Guid Id { get; set; }
        public int Sid { get; set; }
        public string Message { get; set; }
        public int Revision { get; set; }
        public string FileName { get; set; }
        public string ClassType { get; set; }

        public string Summary { get; set; }
        public string FalsePos { get; set; }
        public string FalseNeg { get; set; }
        public string Tags { get; set; }
        public int Weight { get; set; }
        public string Impact { get; set; }
        public string Information { get; set; }
        public string AffectedSystems { get; set; }
        public string AttackScenarios { get; set; }
        public string CorrectiveAction { get; set; }

        public long AddedDate { get; set; }


        public bool Documented { get; set; }
        public string DocumentedBy { get; set; }
        public long DocumentedDate { get; set; }
        public int ModuleId { get; set; }
        public int Severity { get; set; }
        public string RawRule { get; set; }

        public bool IsEnabled { get; set; }

        public override string ToString()
        {
            return $"{Sid}:{Message}:{ClassType}:{IsEnabled}";
        }

    }
}
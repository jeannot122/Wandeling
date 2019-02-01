
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WandelApp.Models
{
    public class Evaluation
    {
        //Evaluation Id is de primairy key
        [PrimaryKey]
        public int EvaluationId { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public string Score { get; set; }

        public override string ToString()
        {
            return this.Name + "-" + this.Review + "-" + this.Score;
        }
    }
}

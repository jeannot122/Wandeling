using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WandelApp.Models
{
    public class Evaluation
    {
        //Evaluation Id is de primairy key
        [PrimaryKey, AutoIncrement]
        public int EvaluationId { get; set; }
        public int Score { get; set; }
        [MaxLength(250)]
        public string Review { get; set; }
    }
}

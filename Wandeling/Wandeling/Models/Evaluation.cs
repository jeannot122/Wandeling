
using System;
using System.Collections.Generic;
using System.Text;

namespace WandelApp.Models
{
    public class Evaluation
    {
        //Evaluation Id is de primairy key
        
        public int EvaluationId { get; set; }
        public int Score { get; set; }
       
        public string Review { get; set; }
    }
}

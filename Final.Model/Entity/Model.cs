using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Model.Entity
{
    public class Model
    {
        public int Batch_id { get; set; }
        public string Batch_Name { get; set; } = "";
        public string Batch_Start_Date { get; set; } = "";
        public int Batch_strength { get; set; }

        public int Technology_id { get; set; }
        public string Teeechnology_Name { get; set; } = "";

        public int Employee_id { get; set; }
        public string Employee_Name { get; set; } = "";
        public string Employee_Phone { get; set; } = "";
        public string Employee_Email { get; set; } = "";

        public int Batch_Allocate_id { get; set; }
        

        public int slno { get; set; }
        public int empid { get; set; }
        public int mark { get; set; }

        public string Grade { get; set; }
        public string Status { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace bakalarska_prace
{
    [Serializable]    
    public class EmployeeRecord 
    {
        public Int32 ID { get; set; }
        public Int32 Money { get; set; }
        public Int32 Age { get; set; }
        public Int32 Children { get; set; }

        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string PIN { get; set; }
        public string Residence { get; set; }

        public bool Ready { get; set; }
        public bool License { get; set; }
        public bool Indisposed { get; set; }
                

        //XMLSerializer
        public EmployeeRecord()
        {
            ;
        }

        public EmployeeRecord(bool FullObject)
        {
            if (FullObject == false)
                new EmployeeRecord();
            else
            {
                this.ID = Int32.MaxValue;
                this.Money = Int32.MaxValue;
                this.Age = Int32.MaxValue;
                this.Children = Int32.MaxValue;


                this.FirstName = new string('A', 12);
                this.FamilyName = new string('B', 12);
                this.PIN = "0123456789";
                this.Residence = new string('D', 10);

                this.Ready = true;
                this.License = false;
                this.Indisposed = false;
            }
        }



    }
}

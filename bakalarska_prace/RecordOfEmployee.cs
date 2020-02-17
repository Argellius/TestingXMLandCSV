using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace
{
    [Serializable]
    public class RecordOfEmployee //Object for serialization to CSV and XML
    {
        public Int64 ID { get; set; }
        public Int64 Money { get; set; }
        public Int64 Age { get; set; }
        public Int64 Children { get; set; }

        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string PIN { get; set; }
        public string Residence { get; set; }

        public bool Ready { get; set; }
        public bool License { get; set; }
        public bool Indisposed { get; set; }
                

        //XMLSerializer
        public RecordOfEmployee()
        {
            ;
        }

        public RecordOfEmployee(bool boo)
        {
            if (boo == false)
                new RecordOfEmployee();
            else
            {
                this.ID = Int64.MaxValue;
                this.Money = Int64.MaxValue;
                this.Age = Int64.MaxValue;
                this.Children = Int64.MaxValue;


                this.FirstName = new string('A', 10);
                this.FamilyName = new string('B', 10);
                this.PIN = "123456789/1234";
                this.Residence = new string('D', 10);

                this.Ready = true;
                this.License = false;
                this.Indisposed = false;
            }
        }



    }
}

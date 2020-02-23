using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    public partial class UserControl_Result : UserControl
    {
        public UserControl_Result()
        {
            InitializeComponent();
        }

        private void UserControl_Result_Load(object sender, EventArgs e)
        {

        }

        public void SetNumberOfTests(int value)
        {
            for (int i =0; i < value; i++)
            {
                metroGrid1.Columns.Add(String.Format("Collumn_{0}", i+1), String.Format("{0}.",i+1));
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

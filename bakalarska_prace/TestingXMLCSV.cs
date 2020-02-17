using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    public partial class TestingXMLCSV : Form
    {
        public TestingXMLCSV()
        {
            InitializeComponent();


        }

        private void listView1_AddItems(ListView list, ListViewGroup nameGroup, List<ITester> tests)
        {
            if (!list.Groups.Contains(nameGroup))
            {
                list.Groups.Add(nameGroup);
            }

            foreach (var test in tests)
                list.Items.Add(new ListViewItem(test.GetType().Name, nameGroup) { Tag = test });


        }

        private void listView1_AddItems(ListView list, ListViewGroup nameGroup, ITester test)
        {
            nameGroup = new ListViewGroup(nameGroup.Header.ToString());
            list.Groups.Add(nameGroup);

            list.Items.Add(new ListViewItem(test.GetType().Name, nameGroup) { Tag = test });


        }

        private void TestingXMLCSV_Load(object sender, EventArgs e)
        {
            int pocet_prvku = 500;
            listView1_AddItems(listView_selected, new ListViewGroup("Array Integer"), new List<ITester> {
                    new ArrayInteger.XML_ArrayIntegerFile(pocet_prvku),
                    new ArrayInteger.XML_ArrayIntegerString(pocet_prvku),
                    new ArrayInteger.XML_ArrayIntegerNuget(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerFile(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerNuget(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerString(pocet_prvku),
            });


        }

        private void checkedListBox_collections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox_testovani_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_selected.Items.Count; i++)
                if (listView_selected.Items[i].Selected)
                {
                    listView1_AddItems(listView_unselected, listView_selected.Items[i].Group, listView_selected.Items[i].Tag as ITester);
                    listView_selected.Items[i].Remove();

                }
        }
    }
}

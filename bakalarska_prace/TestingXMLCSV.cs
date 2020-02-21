using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    public partial class TestingXMLCSV : Form
    {
        private Tools_Vysledky tools_Vysledky;
        public TestingXMLCSV()
        {
            InitializeComponent();
            tools_Vysledky = new Tools_Vysledky();

        }

        private void TreeView_AddItems(TreeView tree, string name_first_node, string name_second_node, List<ITester> tests)
        {
            TreeNode node2 = new TreeNode(name_second_node);
            tests.ForEach(item =>
            {
                node2.Nodes.Add(new TreeNode() { Text = item.GetType().Name, Name = item.GetType().Name, Tag = item, });
            });

            foreach (TreeNode node in tree.Nodes)
                if (node.Text == name_first_node)
                {
                    node.Nodes.Add(node2);
                    return;
                }
            TreeNode node1 = new TreeNode(name_first_node);
            node1.Nodes.Add(node2);
            tree.Nodes.Add(node1);

        }




        private void TestingXMLCSV_Load(object sender, EventArgs e)
        {

            int pocet_prvku = 500;
            TreeView_AddItems(treeView_Tests, "Array", "Integer", new List<ITester> {
                    new ArrayInteger.XML_ArrayIntegerFile(pocet_prvku),
                    new ArrayInteger.XML_ArrayIntegerString(pocet_prvku),
                    new ArrayInteger.XML_ArrayIntegerNuget(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerFile(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerNuget(pocet_prvku),
                    new ArrayInteger.CSV_ArrayIntegerString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "List", "Integer", new List<ITester> {
                    new ListInteger.CSV_ListIntegerFile(pocet_prvku),
                    new ListInteger.CSV_ListIntegerNuget(pocet_prvku),
                    new ListInteger.CSV_ListIntegerString(pocet_prvku),
                    new ListInteger.XML_ListIntegerFile(pocet_prvku),
                    new ListInteger.XML_ListIntegerNuget(pocet_prvku),
                    new ListInteger.XML_ListIntegerString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ArrayList", "Integer", new List<ITester> {
                    new ArrayListInteger.CSV_ArrayListIntegerFile(pocet_prvku),
                    new ArrayListInteger.CSV_ArrayListIntegerNuget(pocet_prvku),
                    new ArrayListInteger.CSV_ArrayListIntegerString(pocet_prvku),
                    new ArrayListInteger.XML_ArrayListIntegerFile(pocet_prvku),
                    new ArrayListInteger.XML_ArrayListIntegerNuget(pocet_prvku),
                    new ArrayListInteger.XML_ArrayListIntegerString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ArrayArray", "Integer", new List<ITester> {
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerFile(pocet_prvku),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerString(pocet_prvku),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerNuget(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerFile(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerString(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerNuget(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ListList", "Integer", new List<ITester> {
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerFile(pocet_prvku),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerString(pocet_prvku),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerNuget(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerFile(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerString(pocet_prvku),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerNuget(pocet_prvku),
            });

            //---

            TreeView_AddItems(treeView_Tests, "Array", "Object", new List<ITester> {
                    new ArrayObject.XML_ArrayObjectFile(pocet_prvku),
                    new ArrayObject.XML_ArrayObjectString(pocet_prvku),
                    new ArrayObject.XML_ArrayObjectNuget(pocet_prvku),
                    new ArrayObject.CSV_ArrayObjectFile(pocet_prvku),
                    new ArrayObject.CSV_ArrayObjectNuget(pocet_prvku),
                    new ArrayObject.CSV_ArrayObjectString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "List", "Object", new List<ITester> {
                    new ListObject.CSV_ListObjectFile(pocet_prvku),
                    new ListObject.CSV_ListObjectNuget(pocet_prvku),
                    new ListObject.CSV_ListObjectString(pocet_prvku),
                    new ListObject.XML_ListObjectFile(pocet_prvku),
                    new ListObject.XML_ListObjectNuget(pocet_prvku),
                    new ListObject.XML_ListObjectString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ArrayList", "Object", new List<ITester> {
                    new ArrayListObject.CSV_ArrayListObjectFile(pocet_prvku),
                    new ArrayListObject.CSV_ArrayListObjectNuget(pocet_prvku),
                    new ArrayListObject.CSV_ArrayListObjectString(pocet_prvku),
                    new ArrayListObject.XML_ArrayListObjectFile(pocet_prvku),
                    new ArrayListObject.XML_ArrayListObjectNuget(pocet_prvku),
                    new ArrayListObject.XML_ArrayListObjectString(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ArrayArray", "Object", new List<ITester> {
                    new ArrayArrayObject.CSV_ArrayArrayObjectFile(pocet_prvku),
                    new ArrayArrayObject.CSV_ArrayArrayObjectString(pocet_prvku),
                    new ArrayArrayObject.CSV_ArrayArrayObjectNuget(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectFile(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectString(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectNuget(pocet_prvku),
            });

            TreeView_AddItems(treeView_Tests, "ListList", "Object", new List<ITester> {
                    new ArrayArrayObject.CSV_ArrayArrayObjectFile(pocet_prvku),
                    new ArrayArrayObject.CSV_ArrayArrayObjectString(pocet_prvku),
                    new ArrayArrayObject.CSV_ArrayArrayObjectNuget(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectFile(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectString(pocet_prvku),
                    new ArrayArrayObject.XML_ArrayArrayObjectNuget(pocet_prvku),
            });

            treeView_Tests.SelectedNode = null;
            treeView_Tests.Nodes[0].Checked = false;
        }

        private async void treeView_Tests_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            e.Node.TreeView.Enabled = false;
            await Task.Delay(200);
            e.Node.TreeView.Enabled = true;


            if (e.Node.Nodes.Count > 0)
                CheckAllChildNodes(e.Node, e.Node.Checked);

            if (e.Node.Parent != null && e.Node.Parent.Checked == false)
            {
                if (AllChildChecked(e.Node.Parent))
                    e.Node.Parent.Checked = true;
            }

            if (e.Node.Level == 2 && e.Node.Checked)
                listBox_selected.Items.Add(new TreeViewItem(e.Node));
            else if (e.Node.Level == 2 && e.Node.Checked == false)
            {
                foreach (TreeViewItem item in listBox_selected.Items)
                {
                    if (item.Text == e.Node.Text)
                    {
                        listBox_selected.Items.Remove(item);
                        break;
                    }
                }
            }

        }

        private bool AllChildChecked(TreeNode currentNode)
        {
            bool res = true;

            foreach (TreeNode node in currentNode.Nodes)
            {
                res = node.Checked;
                if (!res) break;

                res = this.AllChildChecked(node);
                if (!res) break;
            }

            return res;
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {

            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked != nodeChecked)
                    tn.Checked = nodeChecked;
            }

        }


        private void treeView_Tests_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.TreeView.SelectedNode = null;
        }

        private void treeView_Tests_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
                e.Node.Checked = false;
            else
                e.Node.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tools_Vysledky.pocetPrvku = 0;
            tools_Vysledky.pocetTestu = 0;

            foreach (TreeViewItem node in listBox_selected.Items)
            {
                (node.Tag as ITester).SetupWriteStart();
                TimeSpan test = OtestujZmer((node.Tag as ITester).TestWrite);
                (node.Tag as ITester).SetupWriteEnd();
                tools_Vysledky.Add((node.Tag as ITester).GetType().Name + " WRITE TEST", test, (node.Tag as ITester).GetSize());
                test = new TimeSpan(0);


                (node.Tag as ITester).SetupReadStart();
                test = OtestujZmer((node.Tag as ITester).TestRead);
                (node.Tag as ITester).SetupReadEnd();
                tools_Vysledky.Add((node.Tag as ITester).GetType().Name + " READ TEST", test, (node.Tag as ITester).GetSize());
                test = new TimeSpan(0);
            }
            ;
        }

        private static TimeSpan OtestujZmer(Action method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            method();
            sw.Stop();
            return sw.Elapsed;

        }

    }
}

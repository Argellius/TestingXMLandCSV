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
    public partial class TestingXMLCSV : MetroFramework.Forms.MetroForm
    {
        private Tools_Vysledky tools_Vysledky;
        public TestingXMLCSV()
        {
            InitializeComponent();
            tools_Vysledky = new Tools_Vysledky();

        }

        /*private void TreeView_AddItems(TreeView tree, string name_first_node, string name_second_node, List<ITester> tests)
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

        }*/
        private void TreeView_AddItems(TreeView tree, string name_first_node, List<ITester> tests)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            tests.ForEach(item =>
            {
                nodes.Add(new TreeNode() { Text = item.GetType().Name, Name = item.GetType().Name, Tag = item, });
            });

            foreach (TreeNode node in tree.Nodes)
            {
                if (node.Name == name_first_node)
                {
                    node.Nodes.AddRange(nodes.ToArray());
                    return;
                }
            }

            TreeNode node2 = new TreeNode() { Name = name_first_node, Text = name_first_node };
            node2.Nodes.AddRange(nodes.ToArray());
            tree.Nodes.Add(node2);


        }



        private void TestingXMLCSV_Load(object sender, EventArgs e)
        {
            TreeView_AddItems(treeView_Tests, "Array", new List<ITester> {
                    new ArrayInteger.XML_ArrayIntegerString(),
                    new ArrayInteger.XML_ArrayIntegerFile(),
                    new ArrayInteger.XML_ArrayIntegerNuget(),
                    new ArrayInteger.CSV_ArrayIntegerString(),
                    new ArrayInteger.CSV_ArrayIntegerFile(),
                    new ArrayInteger.CSV_ArrayIntegerNuget(),

            });

            TreeView_AddItems(treeView_Tests, "List", new List<ITester> {
                    new ListInteger.CSV_ListIntegerString(),
                    new ListInteger.CSV_ListIntegerFile(),
                    new ListInteger.CSV_ListIntegerNuget(),
                    new ListInteger.XML_ListIntegerString(),
                    new ListInteger.XML_ListIntegerFile(),
                    new ListInteger.XML_ListIntegerNuget(),

            });

            TreeView_AddItems(treeView_Tests, "ArrayList", new List<ITester> {
                new ArrayListInteger.CSV_ArrayListIntegerString(),
                    new ArrayListInteger.CSV_ArrayListIntegerFile(),
                    new ArrayListInteger.CSV_ArrayListIntegerNuget(),
                    new ArrayListInteger.XML_ArrayListIntegerString(),
                    new ArrayListInteger.XML_ArrayListIntegerFile(),
                    new ArrayListInteger.XML_ArrayListIntegerNuget(),
            });

            TreeView_AddItems(treeView_Tests, "ArrayArray", new List<ITester> {
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerString(),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerFile(),
                    new ArrayArrayInteger.CSV_ArrayArrayIntegerNuget(),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerString(),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerFile(),
                    new ArrayArrayInteger.XML_ArrayArrayIntegerNuget(),
            });

            TreeView_AddItems(treeView_Tests, "ListList", new List<ITester> {
                    new ListListInteger.CSV_ListListIntegerString(),
                    new ListListInteger.CSV_ListListIntegerFile(),
                    new ListListInteger.CSV_ListListIntegerNuget(),
                    new ListListInteger.XML_ListListIntegerString(),
                    new ListListInteger.XML_ListListIntegerFile(),
                    new ListListInteger.XML_ListListIntegerNuget(),
            });

            //---

            TreeView_AddItems(treeView_Tests, "Array", new List<ITester> {
                    new ArrayObject.XML_ArrayObjectString(),
                    new ArrayObject.XML_ArrayObjectFile(),
                    new ArrayObject.XML_ArrayObjectNuget(),
                    new ArrayObject.CSV_ArrayObjectString(),
                    new ArrayObject.CSV_ArrayObjectFile(),
                    new ArrayObject.CSV_ArrayObjectNuget(),

            });

            TreeView_AddItems(treeView_Tests, "List", new List<ITester> {
                    new ListObject.CSV_ListObjectString(),
                    new ListObject.CSV_ListObjectFile(),
                    new ListObject.CSV_ListObjectNuget(),
                    new ListObject.XML_ListObjectString(),
                    new ListObject.XML_ListObjectFile(),
                    new ListObject.XML_ListObjectNuget(),

            });

            TreeView_AddItems(treeView_Tests, "ArrayList", new List<ITester> {
                    new ArrayListObject.CSV_ArrayListObjectString(),
                    new ArrayListObject.CSV_ArrayListObjectFile(),
                    new ArrayListObject.CSV_ArrayListObjectNuget(),
                    new ArrayListObject.XML_ArrayListObjectString(),
                    new ArrayListObject.XML_ArrayListObjectFile(),
                    new ArrayListObject.XML_ArrayListObjectNuget(),

            });

            TreeView_AddItems(treeView_Tests, "ArrayArray", new List<ITester> {
                    new ArrayArrayObject.CSV_ArrayArrayObjectString(),
                    new ArrayArrayObject.CSV_ArrayArrayObjectFile(),
                    new ArrayArrayObject.CSV_ArrayArrayObjectNuget(),
                    new ArrayArrayObject.XML_ArrayArrayObjectString(),
                    new ArrayArrayObject.XML_ArrayArrayObjectFile(),
                    new ArrayArrayObject.XML_ArrayArrayObjectNuget(),
            });

            TreeView_AddItems(treeView_Tests, "ListList", new List<ITester> {
                    new ArrayArrayObject.CSV_ArrayArrayObjectString(),
                    new ArrayArrayObject.CSV_ArrayArrayObjectFile(),
                    new ArrayArrayObject.CSV_ArrayArrayObjectNuget(),
                    new ArrayArrayObject.XML_ArrayArrayObjectString(),
                    new ArrayArrayObject.XML_ArrayArrayObjectFile(),
                    new ArrayArrayObject.XML_ArrayArrayObjectNuget(),
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

            if (e.Node.Parent != null && e.Node.Parent.Nodes.Count > 0 && e.Node.Parent.Checked == false)
            {
                foreach (TreeNode node in e.Node.Parent.Nodes)
                    if (node.Checked == false)
                        return;
                e.Node.Parent.Checked = true;
            }

            e.Node.TreeView.SelectedNode = null;



        }


        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {

            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked != nodeChecked)
                    tn.Checked = nodeChecked;
            }

        }


        private void button_Start_Click(object sender, EventArgs e)
        {

            foreach (TreeViewItem node in listBox_selected.Items)
            {
                (node.Tag as ITester).SetNumberOfElements(Convert.ToInt32(metroLabel_numberElements.Text));
            }

            tools_Vysledky.pocetPrvku = Convert.ToInt32(metroLabel_repeat.Text);
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

            MessageBox.Show("Done");
        }

        private static TimeSpan OtestujZmer(Action method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            method();
            sw.Stop();
            return sw.Elapsed;

        }

        private void treeView_Tests_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Checked = false;
            e.Cancel = true;
        }

        private void treeView_Tests_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = null;
        }
    }
}

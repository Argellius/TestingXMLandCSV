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

        private void TreeView_AddItems(TreeView tree, string name_first_node, string name_second_node, List<ITester> tests)
        {
            TreeNode node2 = new TreeNode(name_second_node);
            tests.ForEach(item =>
            {
                node2.Nodes.Add(item.GetType().Name);
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


        }

        private async void treeView_Tests_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            e.Node.TreeView.Enabled = false;
            await Task.Delay(300);
            e.Node.TreeView.Enabled = true;

            if (e.Node.Level == 0)
            {
                if (e.Node.Checked)
                    foreach (TreeNode node in e.Node.Nodes)
                    {
                        if (node.Checked == false)
                            CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                else
                    CheckAllChildNodes(e.Node, e.Node.Checked);

            }
            else if (e.Node.Level == 1)
                if (e.Node.Checked)
                {
                    e.Node.Parent.Checked = true;
                    foreach (TreeNode node in e.Node.Nodes)
                        if (node.Checked)
                            return;
                    CheckAllChildNodes(e.Node, e.Node.Checked);

                }
                else
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                    e.Node.Parent.Checked = false;
                }

            else if (e.Node.Level == 2)
            {


                if (e.Node.Checked)
                {
                    e.Node.Parent.Checked = true;
                    listBox_selected.Items.Add(e.Node.Text);

                }
                else
                {
                    bool min_one_Checked = false;
                    listBox_selected.Items.Remove(e.Node.Text);
                    foreach (TreeNode node in e.Node.Parent.Nodes)
                        if (node.Checked)
                            min_one_Checked = true;
                    if (min_one_Checked == false)
                        e.Node.Parent.Checked = false;


                }
            }
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            if (treeNode.Checked == true)
            {
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    tn.Checked = true;
                }
            }
        }
    }
}

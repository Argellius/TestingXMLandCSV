using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    class TreeViewItem : TreeNode
    {

        public TreeViewItem(TreeNode node) : base()
        {
            base.Tag = node.Tag;
            base.Text = node.Text;
            base.Name = node.Name;
        }


        public override string ToString()
        {
            return base.Name;
        }
    }
}

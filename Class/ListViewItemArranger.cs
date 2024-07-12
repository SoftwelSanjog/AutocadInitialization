using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocadInitialization.Class
{
    public class ListViewItemArranger
    {
        ListView ListView;
        public ListViewItemArranger(ListView listView)
        {
            ListView = listView;
        }
        public void MoveDown()
        {
            if (ListView.SelectedItems.Count == 0) return;

            int currIndex = ListView.SelectedIndices[0];
            if (currIndex == ListView.Items.Count-1)
            {
                return;
            }
            ListViewItem selectedItem = ListView.SelectedItems[0];
            ListView.Items.Remove(selectedItem);
            ListView.Items.Insert(currIndex + 1, selectedItem);
            selectedItem.Selected = true;
        }
        public void MoveUp() 
        {
            if (ListView.SelectedItems.Count == 0) return;
            int currIndex = ListView.SelectedIndices[0];
            if (currIndex == 0) 
            {
                return;
            }
            ListViewItem selectedItem = ListView.SelectedItems[0];
            ListView.Items.Remove(selectedItem);
            ListView.Items.Insert(currIndex-1, selectedItem);
            selectedItem.Selected = true;
           
        }
    }
    
}

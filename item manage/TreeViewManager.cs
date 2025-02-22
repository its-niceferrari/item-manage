using System.Collections.Generic;
using Avalonia.Controls;

namespace item_manage
{
    public class TreeViewManager
    {
        private readonly TreeView treeView;
        private readonly List<TreeViewItem> categories = new();

        public TreeViewManager(TreeView treeView)
        {
            this.treeView = treeView;
        }

        // Add a new category (header)
        public void AddCategory(string categoryName)
        {
            var category = new TreeViewItem { Header = categoryName };
            categories.Add(category);
            treeView.Items.Add(category);
        }

        // Add an item under the selected category
        public void AddItemToSelectedCategory(string itemName)
        {
            if (treeView.SelectedItem is TreeViewItem selectedCategory)
            {
                var newItem = new TreeViewItem { Header = itemName };
                selectedCategory.Items.Add(newItem);
            }
        }
    }
}
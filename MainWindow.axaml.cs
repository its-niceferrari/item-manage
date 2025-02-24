using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace item_manage {
    public partial class MainWindow : Window {
        private FileLauncher? fileLauncher;
        public TreeViewManager? treeViewManager;
        private TreeView? fileTreeView;

        public MainWindow() {
            InitializeComponent();

            fileTreeView = this.FindControl<TreeView>("FileTreeView");

            if (fileTreeView == null)
                throw new NullReferenceException("TreeView not found.");
        
            treeViewManager = new TreeViewManager(fileTreeView);
            treeViewManager.AddCategory("Unclassified");

            fileLauncher = new FileLauncher();
        }

        private List<string> GetAllCategories() {
            var categoryList = new List<string>();
            foreach (var item in fileTreeView.Items) {
                if (item is TreeViewItem category) {
                    categoryList.Add(category.Header.ToString());
                }
            }
            return categoryList;
        }

        private void OnClickNewItem(object? sender, RoutedEventArgs e) {
            var categories = GetAllCategories();
            var addItemWindow = new NewItem(fileTreeView, categories);
            addItemWindow.ShowDialog(this);
        }

        private void OnClickNewCategory(object? sender, RoutedEventArgs e) {
            var addCategoryWindow = new NewCategory(fileTreeView);
            addCategoryWindow.ShowDialog(this);
        }

        private void OnClickOpenSelected(object? sender, RoutedEventArgs e) {
            if (fileTreeView.SelectedItem is TreeViewItem selectedItem) {
                if (selectedItem.Tag is string content && !string.IsNullOrEmpty(content)) {
                    fileLauncher.OpenFileOrApp(selectedItem.Tag.ToString());
                } else {
                    Console.WriteLine("No file could be opened.");
                }
            }
        }

        private void OnClickRemoveSelected(object? sender, RoutedEventArgs e) {
            if (fileTreeView.SelectedItem is TreeViewItem selectedItem) {
                if (selectedItem.Header.ToString() == "Unclassified") {
                    Console.WriteLine("The Unclassified category cannot be deleted.");
                    return;
                }

                var parent = GetParentItem(selectedItem);
                if (parent != null) {
                    parent.Items.Remove(selectedItem);
                } else {
                    fileTreeView.Items.Remove(selectedItem);
                }
            }
        }

        private TreeViewItem? GetParentItem(TreeViewItem item) {
            foreach (var treeItem in fileTreeView.Items) {
                if (treeItem is TreeViewItem parent) {
                    if (parent.Items.Contains(item)) { return parent; }
                }
            }
            return null;
        }
    }
}
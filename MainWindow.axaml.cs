using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    Console.WriteLine("No file opened.");
                }
            }
        }
    }
}
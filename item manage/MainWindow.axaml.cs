using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace item_manage
{
    public partial class MainWindow : Window
    {
        private TreeViewManager? treeViewManager;
        private TextBox? newItemTextBox;
        private TreeView? fileTreeView;

        public MainWindow()
        {
            InitializeComponent();

            // Get UI elements
            fileTreeView = this.FindControl<TreeView>("FileTreeView");
            newItemTextBox = this.FindControl<TextBox>("NewItemTextBox");

            if (fileTreeView == null || newItemTextBox == null) {
                throw new NullReferenceException("Elements were not found in XAML.");
            }

            // Initialize TreeView manager
            treeViewManager = new TreeViewManager(fileTreeView);

            // Attach event handlers
            fileTreeView.DoubleTapped += OnItemDoubleClicked;
        }

        // Handle adding a new category
        private void OnAddCategory(object? sender, RoutedEventArgs e)
        {
            if (treeViewManager != null && !string.IsNullOrWhiteSpace(newItemTextBox?.Text)) {
                treeViewManager.AddCategory(newItemTextBox.Text);
                newItemTextBox.Text = "";
            }
        }

        // Handle adding an item under the selected category
        private void OnAddItem(object? sender, RoutedEventArgs e)
        {
            if (treeViewManager != null && !string.IsNullOrWhiteSpace(newItemTextBox?.Text))
            {
                treeViewManager.AddItemToSelectedCategory(newItemTextBox.Text);
                newItemTextBox.Text = "";
            }
        }

        // Handle opening an item when double-clicked
        private void OnItemDoubleClicked(object? sender, RoutedEventArgs e)
        {
            if (e.Source is TreeViewItem item) {
                FileLauncher.OpenFileOrApp(item.Header.ToString());
            }
        }
    } 
}
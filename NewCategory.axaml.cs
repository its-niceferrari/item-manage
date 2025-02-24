using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace item_manage {
    public partial class NewCategory : Window {
        public string? CategoryName { get; private set; }

        private TextBox? categoryNameTextBox;
        private TreeViewManager? treeViewManager;

        public NewCategory() {
            InitializeComponent();
        }

        public NewCategory(TreeView treeView)
        {
            InitializeComponent();
            treeViewManager = new TreeViewManager(treeView);
            categoryNameTextBox = this.FindControl<TextBox>("CategoryNameTextBox") ?? new TextBox();
        }

        private void OnAdd(object? sender, RoutedEventArgs e) {
            CategoryName = categoryNameTextBox?.Text;
            if (string.IsNullOrWhiteSpace(CategoryName)) {
                Console.WriteLine("No category name entered.");
                return;
            } else if (CategoryName == "Unclassified") {
                Console.WriteLine("The Unclassified category is already defined.");
                return;
            }

            treeViewManager?.AddCategory(CategoryName);
            this.Close();
        }

        private void OnCancel(object? sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
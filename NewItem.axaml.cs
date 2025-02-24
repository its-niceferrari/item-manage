using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace item_manage {
    public partial class NewItem : Window {
        public string? SelectedCategory { get; private set; }
        public string? ItemName { get; private set; }
        public string? FilePath { get; private set; }

        private ComboBox? categoryComboBox;
        private TextBox? itemNameTextBox;
        private TextBox? filePathTextBox;
        private TreeViewManager? treeViewManager;

        public NewItem() {
            InitializeComponent();
        }

        public NewItem(TreeView treeView, List<string> categories)
        {
            InitializeComponent();
            treeViewManager = new TreeViewManager(treeView);

            categoryComboBox = this.FindControl<ComboBox>("CategoryComboBox") ?? new ComboBox();
            itemNameTextBox = this.FindControl<TextBox>("ItemNameTextBox") ?? new TextBox();
            filePathTextBox = this.FindControl<TextBox>("FilePathNameTextBox") ?? new TextBox();

            foreach (var category in categories) { categoryComboBox.Items.Add(category); }
        }

        private void OnAdd(object? sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(itemNameTextBox?.Text))
                return;

            SelectedCategory = categoryComboBox?.SelectedItem?.ToString();
            ItemName = itemNameTextBox?.Text;
            FilePath = filePathTextBox?.Text;

            treeViewManager?.AddItemToCategory(SelectedCategory, ItemName, FilePath);
            this.Close();
        }

        private void OnCancel(object? sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
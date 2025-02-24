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
            filePathTextBox = this.FindControl<TextBox>("FilePathTextBox") ?? new TextBox();

            foreach (var category in categories) { categoryComboBox.Items.Add(category); }
            categoryComboBox.SelectedIndex = 0;
        }

        private async void OnBrowseFile(object? sender, RoutedEventArgs e) {
            if (this.StorageProvider == null) {
                Console.WriteLine("StorageProvider is not available.");
                return;
            }
            
            var files = await this.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions {
                Title = "Browse File",
                AllowMultiple = false,
                FileTypeFilter = new[] { new Avalonia.Platform.Storage.FilePickerFileType("All Files") { Patterns = new[] { "*" } } }
            });

            Console.WriteLine($"File picker returned {files.Count} files.");

            if (files.Count > 0) {
                filePathTextBox.Text = files[0].Path.LocalPath;
            } else {
                Console.WriteLine("No file selected.");
            }
        }

        private void OnAdd(object? sender, RoutedEventArgs e) {
            SelectedCategory = categoryComboBox?.SelectedItem?.ToString();
            ItemName = itemNameTextBox?.Text;
            FilePath = filePathTextBox.Text;

            if (string.IsNullOrWhiteSpace(ItemName)){
                Console.WriteLine("No item name entered.");
                return;
            } else if (string.IsNullOrWhiteSpace(SelectedCategory)) {
                Console.WriteLine("No category entered.");
                return;
            }

            treeViewManager?.AddItemToCategory(SelectedCategory, ItemName, FilePath);
            this.Close();
        }

        private void OnCancel(object? sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
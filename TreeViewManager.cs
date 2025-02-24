using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;


namespace item_manage {
    public class TreeViewManager {
        private readonly TreeView treeView;
        private readonly List<TreeViewItem> categories = new();

        public TreeViewManager(TreeView treeView) {
            this.treeView = treeView;
        }

        public void AddCategory(string categoryName) {
            var category = new TreeViewItem {
                Header = categoryName,
                FontWeight = FontWeight.Bold
            };
            categories.Add(category);
            treeView.Items.Add(category);
        }
        public void AddItemToCategory(string categoryName, string itemName, string? filePath = null) {
            if (string.IsNullOrWhiteSpace(categoryName) || string.IsNullOrWhiteSpace(itemName))
                return;
            
            TreeViewItem? selectedCategory = null;

            foreach (var countableItem in treeView.Items) {
                if (countableItem is TreeViewItem treeViewItem) {
                    if (treeViewItem.Header is string categoryHeader && categoryHeader.Trim().Equals(categoryName.Trim(), StringComparison.OrdinalIgnoreCase)) {
                        selectedCategory = treeViewItem;
                        break;
                    }

                    if (treeViewItem.Header is TextBlock textBlock && textBlock.Text.Trim().Equals(categoryName.Trim(), StringComparison.OrdinalIgnoreCase)) {
                        selectedCategory = treeViewItem;
                        break;
                    }
                }
            }

            if (selectedCategory == null) {
                Trace.WriteLine($"Error: Category '{categoryName}' not found.");
                return;
            }

            var headerPanel = new StackPanel { Orientation = Orientation.Horizontal };
            var nameTextBlock = new TextBlock {
                Text = itemName,
                FontWeight = FontWeight.Normal
            };
            
            headerPanel.Children.Add(nameTextBlock);

            if (!string.IsNullOrEmpty(filePath)) {
                var pathTextBlock = new TextBlock {
                    Text = $"({filePath})",
                    FontSize = 12,
                    Foreground = Brushes.Gray,
                };
                headerPanel.Children.Add(pathTextBlock);
            }

            var newItem = new TreeViewItem {
                Header = headerPanel,
                Tag = filePath,
                Focusable = true
            };

            selectedCategory.Items.Add(newItem);
        }
    }
}
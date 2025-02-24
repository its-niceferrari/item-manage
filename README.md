# Item Manage
A lightweight desktop application built with C# that allows users to organize programs, files, and notes within custom categories.

## Installation
1. Clone this repository to your local machine: ```git clone https://github.com/its-niceferrari/item-manage.git```
2. Open the project in Visual Studio Code (or your preferred .NET development environment).
3. Ensure the project is using a compatible .NET version, such as SDK 9.0 or higher.
4. Download Avalonia UI (installed via `dotnet new install Avalonia.Templates`) 
5. Build and run the project.

## Usage
1. Create Categories – Click "New Category" to create a collapsible section.
2. Add Items – Click "New Item" to add a note, document, or application shortcut.
3. Open Files/Programs – Right click an item and click "Open".
4. Expand/Collapse Categories – Keep your workspace organized.

## Known Issues
- When adding an item in macOS, system applications cannot be selected using the file picker. To add them, manually enter the file path into the text box. 
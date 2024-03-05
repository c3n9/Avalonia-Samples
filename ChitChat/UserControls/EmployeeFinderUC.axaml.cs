using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using ChitChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChitChat;

public partial class EmployeeFinderUC : UserControl
{
    public List<Employee> Employees { get; set; }
    List<CheckBox> CheckBoxes = new List<CheckBox>();
    public EmployeeFinderUC()
    {
        InitializeComponent();
        InitDepartmentsList();
        Refresh();
    }

    private void Refresh()
    {
        using (DBConnection db = new DBConnection())
        {
            var filtred = db.Employee.ToList();
            var surchText = TBSurch.Text;
            if (!string.IsNullOrWhiteSpace(surchText))
            {
                filtred = filtred.Where(x => x.Name.ToLower().Contains(surchText.ToLower())).ToList();
            }
            if (CheckBoxes != null && CheckBoxes.Count != 0)
            {
                foreach (var checkBox in CheckBoxes)
                {
                    if (checkBox.Tag is int tagId)
                    {
                        filtred = filtred.Where(x => x.Id == tagId).ToList();
                    }
                }
            }
            LBEmployee.ItemsSource = null;
            Employees = filtred.ToList();
            LBEmployee.ItemsSource = Employees;
        }
    }

    private void InitDepartmentsList()
    {
        var stackPanel = new StackPanel() { Margin = new Thickness(10) };
        using (DBConnection db = new DBConnection())
        {
            var departments = db.Department.ToList();
            foreach (var department in departments)
            {
                var stackPanelDepartment = new StackPanel() { Margin = new Thickness(10), Orientation = Orientation.Horizontal };
                var checkBox = new CheckBox() { Tag = department.Id };
                checkBox.IsCheckedChanged += CheckBox_IsCheckedChanged;
                var textBlock = new TextBlock() { Text = $"{department.Name}", FontSize = 20 };
                stackPanelDepartment.Children.Add(checkBox);
                stackPanelDepartment.Children.Add(textBlock);
                stackPanel.Children.Add(stackPanelDepartment);
            }
        }
        SPDepartments.Children.Add(stackPanel);
    }

    private void CheckBox_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        if (checkBox.IsChecked.Value)
            CheckBoxes.Add(checkBox);
        else
            CheckBoxes.Remove(checkBox);
        Refresh();
    }

    private void TBSurch_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        Refresh();
    }

    private void ListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (LBEmployee.SelectedItem is Employee employee)
            App.MainWindow.MainContentPresenter.Content = new ChangeTopicUC(employee, new Chatroom());
    }

    private void BBack_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MainContentPresenter.Content = new MainUC();
    }
}
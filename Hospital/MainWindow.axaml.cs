using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public partial class MainWindow : Window
    {
        List<User> users;
        private bool isDragging = false;
        private Point startPoint;
        private Ellipse draggedEllipse;
        List<StackPanelInfo> stackPanelInfos;
        Dictionary<int, StackPanel> dictionary;
        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>
            {
                new User(1,"Jhon",101),
                new User(2,"Mike",111),
                new User(3,"Kim",115),
                new User(4,"Jelly",110),
                new User(5,"Timon",104),
            };
            dictionary = new Dictionary<int, StackPanel>();
            dictionary.Add(101, SP101);
            dictionary.Add(102, SP102);
            dictionary.Add(103, SP103);
            dictionary.Add(104, SP104);
            dictionary.Add(105, SP105);
            dictionary.Add(106, SP106);
            dictionary.Add(107, SP107);
            dictionary.Add(108, SP108);
            dictionary.Add(109, SP109);
            dictionary.Add(110, SP110);
            dictionary.Add(111, SP111);
            dictionary.Add(112, SP112);
            dictionary.Add(113, SP113);
            dictionary.Add(114, SP114);
            dictionary.Add(115, SP115);
            dictionary.Add(116, SP116);
            dictionary.Add(117, SP117);
            dictionary.Add(118, SP118);
            RefreshPanelInfo();
            Refresh();
        }

        private void RefreshPanelInfo()
        {
            stackPanelInfos = new List<StackPanelInfo>();
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[101], MaxCountItems = 5, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[102], MaxCountItems = 5, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[103], MaxCountItems = 6, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[104], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[105], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[106], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[107], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[108], MaxCountItems = 3, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[109], MaxCountItems = 3, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[110], MaxCountItems = 3, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[111], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[112], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[113], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[114], MaxCountItems = 4, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[115], MaxCountItems = 6, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[116], MaxCountItems = 2, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[117], MaxCountItems = 2, CurrentCountItems = 0 });
            stackPanelInfos.Add(new StackPanelInfo() { Panel = dictionary[118], MaxCountItems = 2, CurrentCountItems = 0 });
        }

        private void Window_Loaded(object? sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            for (int i = 101; i <= 118; i++)
            {
                dictionary[i].Children.Clear();
            }
            foreach (var panelInfo in stackPanelInfos)
            {
                panelInfo.CurrentCountItems = 0;
            }
            var patients = users.Where(x => x.Palata != null).ToList();
            foreach (var patient in patients)
            {
                var stackPanel = dictionary[patient.Palata.Value];
                var el = new Ellipse { Fill = Brushes.Green, Width = 12, Height = 12, Tag = patient.Id };
                el.PointerPressed += El_MouseDown;
                el.PointerReleased += El_MouseUp;
                el.PointerMoved += El_MouseMove;
                ContextMenu contextMenu = new ContextMenu();
                MenuItem menuItem = new MenuItem() { Header = "Выписать" };
                menuItem.Click += (sender, e) =>
                {
                    var selectedEllipse = el as Ellipse;
                    if (selectedEllipse != null && selectedEllipse.Tag is int patientId)
                    {
                        var patientInElipse = users.FirstOrDefault(x => x.Id == patientId);
                        patientInElipse.Palata = null;
                        Refresh();
                    }
                };
                contextMenu.Items.Add(menuItem);
                el.ContextMenu = contextMenu;
                var stackPanelInfo = stackPanelInfos.FirstOrDefault(x => x.Panel == stackPanel);
                if (stackPanelInfo != null && stackPanelInfo.CurrentCountItems <= stackPanelInfo.MaxCountItems)
                {
                    stackPanel.Children.Add(el);
                    stackPanelInfo.CurrentCountItems++;
                }
            }
        }
        private void El_MouseMove(object sender, PointerEventArgs e)
        {
            if (isDragging && draggedEllipse != null)
            {
                Point mousePos = e.GetPosition(null);
                var transform = draggedEllipse.RenderTransform as TranslateTransform;
                if (transform == null)
                {
                    transform = new TranslateTransform();
                    draggedEllipse.RenderTransform = transform;
                }
                transform.X = mousePos.X - startPoint.X;
                transform.Y = mousePos.Y - startPoint.Y;
            }
        }

        private void El_MouseUp(object sender, PointerReleasedEventArgs e)
        {
            if (isDragging && draggedEllipse != null)
            {
                isDragging = false;
                //draggedEllipse.ReleasePointerCapture(e.Pointer); // Не нашел аналогию для Avalonia
                Point dropPoint = e.GetPosition(this);
                var dropPanel = FindDropPanel(dropPoint);
                if (dropPanel != null)
                {
                    if (dictionary.FirstOrDefault(x => x.Value == dropPanel).Key is int palata)
                    {
                        if (draggedEllipse.Tag is int patientId)
                        {
                            var patient = users.FirstOrDefault(x => x.Id == patientId);
                            if (patient != null)
                            {
                                foreach (var panel in stackPanelInfos)
                                {
                                    if (panel.Panel == dropPanel)
                                    {
                                        if (panel.CurrentCountItems >= panel.MaxCountItems)
                                        {
                                            Refresh();
                                            return;
                                        }
                                    }
                                }
                                patient.Palata = palata;
                                Refresh();
                            }
                        }
                    }
                }
            }
        }

        private StackPanel FindDropPanel(Point dropPoint)
        {
            foreach (var panel in dictionary.Values)
            {
                var bounds = new Rect(panel.Bounds.X, panel.Bounds.Y, panel.Bounds.Width, panel.Bounds.Height);
                if (bounds.Contains(dropPoint))
                {
                    return panel;
                }
            }
            return null;
        }

        private void El_MouseDown(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(null).Properties.IsLeftButtonPressed)
            {
                isDragging = true;
                startPoint = e.GetPosition(null);
                draggedEllipse = sender as Ellipse;
                //draggedEllipse.Capture(e.Pointer); // Не нашел аналогию для Avalonia
            }
        }

    }
    public class StackPanelInfo
    {
        public StackPanel Panel { get; set; }
        public int MaxCountItems { get; set; }
        public int CurrentCountItems { get; set; }
    }
}

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace UsbDeviceDriver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateDeviceList();
        }

        private void PopulateDeviceList()
        {
            var devices = GetUSBDevices();
            foreach(var device in devices)
            {
                deviceListBox.Items.Add(device);
            }
        }

        private List<string> GetUSBDevices()
        {
            var devices = new List<string>();
            var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%)'");
            foreach(ManagementObject queryObj in searcher.Get())
            {
                string deviceName = queryObj["Name"].ToString();
                devices.Add($"{deviceName}");
            }
            return devices;
        }

        private List<string> GetSerialPorts()
        {
            var devices = new List<string>();
            string[] portNames = SerialPort.GetPortNames();
            foreach (string portName in portNames)
            {
                devices.Add(portName);
            }
            return devices;
        }
    }
}
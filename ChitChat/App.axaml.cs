using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ChitChat.Models;
using ChitChat.Models.Metadata;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChitChat
{
    public partial class App : Application
    {
        public static MainWindow MainWindow;
        public static Employee loginEmploee;
        public App()
        {
            RegistrateDescriptors();
        }

        private void RegistrateDescriptors()
        {
            AddDescriptor<Employee, EmployeeMetadata>();
        }

        private void AddDescriptor<T1, T2>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T1), typeof(T2));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T1));
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
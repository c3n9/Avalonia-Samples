using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaCRUD.Models;
using AvaloniaCRUD.Models.Metadata;

namespace AvaloniaCRUD;

public partial class App : Application
{
    public static MainWindow MainWindow;

    public App()
    {
        RegistrateDescriptors();
    }

    private void RegistrateDescriptors()
    {
        AddDescriptor<User, UserMetadata>();
    }

    private void AddDescriptor<T, T1>()
    {
        var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T), typeof(T1));
        TypeDescriptor.AddProviderTransparent(provider, typeof(T));
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
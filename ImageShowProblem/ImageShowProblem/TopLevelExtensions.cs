using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;

namespace ImageShowProblem;

public static class TopLevelExtensions
{
    public static IStorageProvider GetStorageProvider()
    {
        IStorageProvider? storageProvider = null;
        if (Avalonia.Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            storageProvider = TopLevel.GetTopLevel(desktop.MainWindow)!.StorageProvider;
        }
        else if (Avalonia.Application.Current.ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            storageProvider = TopLevel.GetTopLevel(singleViewPlatform.MainView)!.StorageProvider;
        }
        if (storageProvider == null)
        {
            throw new ArgumentNullException();
        }
        return storageProvider;
    }
}
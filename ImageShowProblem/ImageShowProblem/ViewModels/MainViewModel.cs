using System.Collections.Generic;
using System.Linq;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;

namespace ImageShowProblem.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        UploadAvatarCommand = new RelayCommand(OnUploadAvatarEvent);
    }

    private async void OnUploadAvatarEvent()
    {
        var storageProvider = TopLevelExtensions.GetStorageProvider();
        var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Photo",
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("Photo") { Patterns = new List<string> { "*.jpeg", "*.jpg", "*.png" } }
            },
            AllowMultiple = false
        });

        var storageFile = result.FirstOrDefault();
        if (storageFile != null)
        {
            await using var stream = await storageFile.OpenReadAsync();
            Avatar = new Bitmap(stream);
        }
    }

    public RelayCommand UploadAvatarCommand { get; private init; }

    private Bitmap _avatar = ImageHelper.DefaultAvatar;
    public Bitmap Avatar
    {
        set => SetProperty(ref _avatar, value);
        get => _avatar;
    }
}

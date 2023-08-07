using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace ImageShowProblem;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(Uri resourceUri)
    {
        return new Bitmap(AssetLoader.Open(resourceUri));
    }

    public static Bitmap DefaultAvatar { get; } = LoadFromResource(new Uri("avares://ImageShowProblem/Assets/DefaultAvatar.jpg"));
}
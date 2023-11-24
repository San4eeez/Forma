using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Forma;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(Uri resource) => new Bitmap(AssetLoader.Open(resource));

    public static async Task<Bitmap?> LoadFromWeb(Uri url)
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsByteArrayAsync();
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"Error while downloading image '{url}' : {ex.Message}");
            return null;
        }
    }

}
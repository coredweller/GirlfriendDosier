
namespace Core.Infrastructure
{
    public interface IImageFormatSpec
    {
        string Extension { get; }
        string ContentType { get; }
        System.Drawing.Imaging.ImageFormat Format { get; }
    }
}

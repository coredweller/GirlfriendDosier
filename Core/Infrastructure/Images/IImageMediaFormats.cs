using System.Collections.Generic;

namespace Core.Infrastructure
{
    public interface IImageMediaFormats
    {
        bool HasExtension(string extension);
        bool HasContentType(string contentType);
        bool HasImageFormat(System.Drawing.Imaging.ImageFormat format);
        IImageFormatSpec GetSpecByExtension(string extension);
        IImageFormatSpec GetSpecByContentType(string contentType);
        IImageFormatSpec GetSpecByFormat(System.Drawing.Imaging.ImageFormat format);
        IList<IImageFormatSpec> ImageFormatSpecs { get; }
    }
}

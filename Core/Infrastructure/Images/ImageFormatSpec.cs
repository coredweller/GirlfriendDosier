using Core.Helpers;

namespace Core.Infrastructure
{
    public abstract class ImageFormatSpec : IImageFormatSpec
    {
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public System.Drawing.Imaging.ImageFormat Format { get; set; }

        protected ImageFormatSpec()
        {

        }

        protected ImageFormatSpec(string extension, string contentType, System.Drawing.Imaging.ImageFormat format)
        {
            Checks.Argument.IsNotEmpty(extension, "extension");
            Checks.Argument.IsNotEmpty(contentType, "contentType");
            Checks.Argument.IsNotNull(format, "format");
            Extension = extension;
            ContentType = contentType;
            Format = format;
        }

        public override string ToString()
        {
            return this.Extension;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + Extension.NullSafe().GetHashCode();
            hash = hash * 23 + ContentType.NullSafe().GetHashCode();
            hash = hash * 23 + Format.Guid.GetHashCode();
            return hash;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Helpers;

namespace Core.Infrastructure.Images
{
    public class ImageMediaFormats : IImageMediaFormats
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(ImageMediaFormats));
        private readonly IDictionary<Guid, IImageFormatSpec> _specs;

        public ImageMediaFormats(IImageFormatSpec[] specs)
        {
            Checks.Argument.IsNotNull(specs, "specs");
            Checks.Argument.IsNotEmpty(specs, "specs");
            try
            {

                var duplicationMsgFormat = "ImageMediaFormats can only accept a mutually exclusive array of IImageFormatSpec.  The array provided has a duplicate property value.";
                var specCount = specs.Length;

                //make sure all IImageFormatSpec objects are unqiue - this could be done with a single comparison against all properties but the error message wouldn't be as specific
                if (specs.DistinctBy(s => s.GetHashCode()).Count() != specCount)
                {
                    //log.Fatal("An exception was thrown while trying to instantiate a ImageMediaFormats object.");
                    throw new ArgumentException(duplicationMsgFormat);
                }

                _specs = specs.ToDictionary<IImageFormatSpec, Guid>(x => x.Format.Guid);
            }
            catch (ArgumentNullException ex)
            {
                //log.Error("An exception was thrown while trying to instantiate a ImageMediaFormats object.", ex);
                throw;
            }
            catch (ArgumentException ex)
            {
                //log.Error("An exception was thrown while trying to instantiate a ImageMediaFormats object.  Make sure you are not specifying IImageFormatSpec object with the same Format as this is not permitted.", ex);
                throw;
            }
        }


        public bool HasExtension(string extension)
        {
            return _specs.Values.Any(x => x.Extension.ToLower() == extension.ToLower());
        }


        public bool HasContentType(string contentType)
        {
            return _specs.Values.Any(x => x.ContentType.ToLower() == contentType.ToLower());
        }


        public bool HasImageFormat(System.Drawing.Imaging.ImageFormat format)
        {
            return _specs.Values.Any(x => x.Format.Equals(format));
        }

        public IImageFormatSpec GetSpecByExtension(string extension)
        {
            return _specs.Values.SingleOrDefault(x => x.Extension.ToLower() == extension.ToLower());
        }


        public IImageFormatSpec GetSpecByContentType(string contentType)
        {
            return _specs.Values.SingleOrDefault(x => x.ContentType.ToLower() == contentType.ToLower());
        }

        public IImageFormatSpec GetSpecByFormat(System.Drawing.Imaging.ImageFormat format)
        {
            return _specs.Values.SingleOrDefault(x => x.Format.Equals(format));
        }

        public IList<IImageFormatSpec> ImageFormatSpecs
        {
            get { return _specs.Values.ToList().AsReadOnly(); }
        }

    }
}

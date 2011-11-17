using Core.Helpers;

namespace Core.Infrastructure.Images
{
    public abstract class ImageSize : IImageSizes
    {

        private readonly int _width;
        private readonly int _maxHeight;
        private readonly bool _onlyResizeIfWider;

        public ImageSize(int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            Checks.Argument.IsNotNegativeOrZero(newWidth, "newWidth");
            Checks.Argument.IsNotNegativeOrZero(maxHeight, "maxHeight");
            _width = newWidth;
            _maxHeight = maxHeight;
            _onlyResizeIfWider = onlyResizeIfWider;
        }
        #region IImageSizes Members

        public virtual int Width
        {
            get { return this._width; }
        }

        public virtual int MaxHeight
        {
            get { return this._maxHeight; }
        }

        public bool OnlyResizeIfWider
        {
            get { return _onlyResizeIfWider; }
        }

        #endregion
    }
}

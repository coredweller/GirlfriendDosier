using System.Globalization;
using System.Diagnostics;

namespace Core.Helpers
{

    public static class Constants
    {
        public static CultureInfo CurrentCulture
        {
            [DebuggerStepThrough]
            get
            {
                return CultureInfo.CurrentCulture;
            }
        }
    }
}

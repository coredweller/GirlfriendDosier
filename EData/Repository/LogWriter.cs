using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using log4net;

namespace EData.Repository
{
    /// <summary>
    /// Implements a <see cref="TextWriter"/> for writing information to the log4net.
    /// </summary>
    /// <seealso cref="log4net.ILog"/>
    [DebuggerStepThrough]
    public class LogWriter : TextWriter, ILogWriter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogWriter));
        private static UnicodeEncoding encoding;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogWriter"/> class.
        /// </summary>
        public LogWriter()
            : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogWriter"/> class with the format provider.
        /// </summary>
        /// <param name="formatProvider">An <see cref="IFormatProvider"/> object that controls formatting.</param>
        public LogWriter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override void Write(char value)
        {
            log.Debug(value.ToString());
        }

        public override void Write(string value)
        {
            if (value != null)
            {
                log.Debug(value);
            }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            if (buffer == null || index < 0 || count < 0 || buffer.Length - index < count)
            {
                base.Write(buffer, index, count);
            }
            log.Debug(new string(buffer, index, count));
        }

        public override Encoding Encoding
        {
            get
            {
                if (encoding == null)
                {
                    encoding = new UnicodeEncoding(false, false);
                }
                return encoding;
            }
        }

        #region ILogWriter Members

        public TextWriter Get()
        {
            return this;
        }

        #endregion
    }
}

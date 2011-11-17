namespace Core
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// abstract implementation if IDisposable interface to be used with object instance garbage collection
    /// </summary>
    public abstract class DisposableResource : IDisposable
    {
        ~DisposableResource()
        {
            Dispose(false);
        }

        [DebuggerStepThrough]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }
}

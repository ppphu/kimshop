using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimShop.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                // Free any other managed objects here.
                DisposeCore();
            }
            // Free any unmanaged objects here.
            disposed = true;
        }

        // Overide this to dispose custom objects
        protected virtual void DisposeCore()
        {

        }
        // Distroy method
        ~Disposable()
        {
            Dispose(false);
        }
    }
}

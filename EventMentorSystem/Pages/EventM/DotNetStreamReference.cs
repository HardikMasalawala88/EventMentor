using System;
using System.IO;

namespace EventMentorSystem.Pages.EventM
{
    internal class DotNetStreamReference : IDisposable
    {
        private MemoryStream stream;

        public DotNetStreamReference(MemoryStream stream)
        {
            this.stream = stream;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
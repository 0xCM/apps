//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;
    using System.IO;

    public readonly struct PeStream : IDisposable
    {
        readonly PEReader PEReader;

        readonly FileStream Stream;

        public readonly MetadataReader Reader;

        internal PeStream(FileStream stream, PEReader peReader)
        {
            Stream = stream;
            PEReader = peReader;
            Reader = peReader.GetMetadataReader();
        }

        public void Dispose()
        {
            PEReader?.Dispose();
            Stream?.Dispose();
        }
    }
}
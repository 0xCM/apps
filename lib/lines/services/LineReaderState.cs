//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    public struct LineReaderState
    {
        public readonly StreamReader Source;

        public uint LineCount;

        public uint Offset;

        [MethodImpl(Inline)]
        public LineReaderState(StreamReader src)
        {
            Source = src;
            LineCount = 0;
            Offset = 0;
        }
    }
}
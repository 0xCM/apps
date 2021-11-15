//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ReflectedByteSpan
    {
        public ClrMethodArtifact Source;

        public BinaryCode Content;

        [MethodImpl(Inline)]
        public ReflectedByteSpan(ClrMethodArtifact source, BinaryCode content)
        {
            Source = source;
            Content = content;
        }
    }
}
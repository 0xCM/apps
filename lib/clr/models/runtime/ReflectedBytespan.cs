//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
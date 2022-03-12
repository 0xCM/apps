//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct InstPatternBody : IIndex<InstDefSeg>
        {
            readonly Index<InstDefSeg> Data;

            [MethodImpl(Inline)]
            public InstPatternBody(InstDefSeg[] src)
            {
                Data = src;
            }

            public InstDefSeg[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint PartCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref InstDefSeg this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstDefSeg this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(InstDefSeg[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefSeg[](InstPatternBody src)
                => src.Data;
        }
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        public readonly struct InstPatternBody : IIndex<InstDefField>
        {
            readonly Index<InstDefField> Data;

            [MethodImpl(Inline)]
            public InstPatternBody(InstDefField[] src)
            {
                Data = src;
            }

            public InstDefField[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint FieldCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public ref InstDefField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstDefField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public InstPatternBody Replicate()
                => new InstPatternBody(Data.Replicate());

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(InstDefField[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefField[](InstPatternBody src)
                => src.Data;
        }
    }
}
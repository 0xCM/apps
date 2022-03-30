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
        public readonly struct InstPatternBody : IIndex<InstDefPart>
        {
            public static string normalize(string rawbody)
            {
                var buffer = text.buffer();
                var parts = text.split(text.despace(rawbody), Chars.Space);
                for(var i=0; i<parts.Length; i++)
                {
                    if(i != 0)
                        buffer.Append(Chars.Space);
                    buffer.Append(core.skip(parts,i));
                }
                return buffer.Emit();
            }

            public readonly Index<InstDefPart> Data;

            [MethodImpl(Inline)]
            public InstPatternBody(InstDefPart[] src)
            {
                Data = src;
            }

            public InstDefPart[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint FieldCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public ref InstDefPart this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstDefPart this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(InstDefPart[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(Index<InstDefPart> src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefPart[](InstPatternBody src)
                => src.Data;
        }
    }
}
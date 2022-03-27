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

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(InstDefField[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstDefField[](InstPatternBody src)
                => src.Data;
        }
    }
}
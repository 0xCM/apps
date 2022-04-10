//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedFields;

    partial class XedPatterns
    {
        public readonly struct InstPatternBody : IIndex<InstField>
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

            public readonly InstFields Data;

            [MethodImpl(Inline)]
            public InstPatternBody(InstField[] src)
            {
                //Data = new InstFields(src,0);
                Data = new InstFields(src,0);
            }

            [MethodImpl(Inline)]
            public InstPatternBody(InstFields fields)
            {
                Data = fields;
            }

            public InstField[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public uint FieldCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public byte ExprCount
            {
                [MethodImpl(Inline)]
                get => Data.ExprCount;
            }

            public byte LayoutCount
            {
                [MethodImpl(Inline)]
                get => Data.LayoutCount;
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

            public ref InstField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref InstField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(InstField[] src)
                => new InstPatternBody(src);

            [MethodImpl(Inline)]
            public static implicit operator InstPatternBody(Index<InstField> src)
                => new InstPatternBody(src);
        }
    }
}
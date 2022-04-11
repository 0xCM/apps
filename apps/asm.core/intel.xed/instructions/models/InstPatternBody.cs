//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedFields;

    partial class XedRules
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

            public readonly InstFields Fields;

            [MethodImpl(Inline)]
            public InstPatternBody(InstField[] src)
            {
                Fields = new InstFields(src,0);
            }

            [MethodImpl(Inline)]
            public InstPatternBody(InstFields fields)
            {
                Fields = fields;
            }

            public InstField[] Storage
            {
                [MethodImpl(Inline)]
                get => Fields.Storage;
            }

            public uint FieldCount
            {
                [MethodImpl(Inline)]
                get => Fields.Count;
            }

            public byte ExprCount
            {
                [MethodImpl(Inline)]
                get => Fields.ExprCount;
            }

            public byte LayoutCount
            {
                [MethodImpl(Inline)]
                get => Fields.LayoutCount;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsNonEmpty;
            }

            public ref InstField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Fields[i];
            }

            public ref InstField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Fields[i];
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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    partial class Assets
    {
        public static Index<BitMaskInfo> masks(Type src)
        {
            var fields = span(src.LiteralFields());
            var dst = list<BitMaskInfo>();
            for(var i=0u; i<fields.Length; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tc = Type.GetTypeCode(field.FieldType);
                var vRaw = field.GetRawConstantValue();
                if(IsMultiLiteral(field))
                    dst.AddRange(masks(polymorphic(field), vRaw));
                else if(IsBinaryLiteral(field))
                    dst.Add(BitMaskData.describe(binaryliteral(field,vRaw)));
                else
                    dst.Add(BitMaskData.describe(ClrLiterals.numeric(base2, field.Name, vRaw, BitRender.format(vRaw, tc))));
            }
            return dst.ToArray();
        }

        public static Index<BitMaskInfo> masks(LiteralInfo src, object value)
        {
            var input = src.Text;
            var fence = RenderFence.define(Chars.LBracket, Chars.RBracket);
            var content = input;
            var fenced = text.fenced(input, fence);
            if(fenced)
            {
                if(!text.unfence(input, fence, out content))
                    return sys.empty<BitMaskInfo>();
            }

            var components = @readonly(content.SplitClean(FieldDelimiter));
            var count = components.Length;
            var dst = alloc<BitMaskInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(components,i);
                var length = component.Length;
                if(length > 0)
                {
                    var nbi = NumericBases.indicator(first(component));
                    var nbk = NumericBases.kind(nbi);

                    if(nbi != 0)
                        seek(dst, i) = BitMaskData.describe(ClrLiterals.numeric(nbk, src.Name, value, component.Substring(1)));
                    else
                    {
                        nbi = NumericBases.indicator(component[length - 1]);
                        nbi = nbi != 0 ? nbi : NumericBaseIndicator.Base2;
                        seek(dst, i) = BitMaskData.describe(ClrLiterals.numeric(nbk, src.Name, value, component.Substring(0, length - 1)));
                    }
                }
                else
                    seek(dst, i) = BitMaskData.describe(NumericLiteral.Empty);
            }

            return dst;
        }

    }
}
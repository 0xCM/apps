//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static TaggedLiterals;

    using NBI = NumericBaseIndicator;

    public sealed class BitMaskServices : AppService<BitMaskServices>
    {
        public static Index<BitMaskInfo> descriptions(Type src)
        {
            var fields = span(src.LiteralFields());
            var dst = list<BitMaskInfo>();
            for(var i=0u; i<fields.Length; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tc = Type.GetTypeCode(field.FieldType);
                var vRaw = field.GetRawConstantValue();
                if(IsMultiLiteral(field))
                    dst.AddRange(descriptions(polymorphic(field), vRaw));
                else if(IsBinaryLiteral(field))
                    dst.Add(BitMasks.describe(binaryliteral(field,vRaw)));
                else
                    dst.Add(BitMasks.describe(Numeric.literal(base2, field.Name, vRaw, BitRender.format(vRaw, tc))));
            }
            return dst.ToArray();
        }

        public static Index<BitMaskInfo> descriptions(LiteralInfo src, object value)
        {
            if(src.Polymorphic)
            {
                var input = src.Text;
                var fence = RuleModels.fence(Chars.LBracket, Chars.RBracket);
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

                        if(nbi != 0)
                            seek(dst, i) = BitMasks.describe(Numeric.literal(src.Name, value, component.Substring(1), NumericBases.kind(nbi)));
                        else
                        {
                            nbi = NumericBases.indicator(component[length - 1]);
                            nbi = nbi != 0 ? nbi : NBI.Base2;
                            seek(dst, i) = BitMasks.describe(Numeric.literal(src.Name, value, component.Substring(0, length - 1), NumericBases.kind(nbi)));
                        }
                    }
                    else
                        seek(dst, i) = BitMasks.describe(NumericLiteral.Empty);
                }
            }

            return sys.empty<BitMaskInfo>();
        }

        readonly BitMaskFormatter Formatter;

        public BitMaskServices()
        {
            Formatter = BitMaskFormatter.create();
        }

        public Index<BitMaskInfo> Load()
            => Load(DefaultProvider);

        public Index<BitMaskInfo> Load(Type src)
            => descriptions(src);

        public Index<BitMaskInfo> Emit()
            => Emit(Db.IndexTable<BitMaskInfo>());

        public Index<BitMaskInfo> Emit(FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<BitMaskInfo>(dst);
            var masks = Load();
            Emit(masks.View, dst);
            return masks;
        }

        public ExecToken Emit(ReadOnlySpan<BitMaskInfo> src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<BitMaskInfo>(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            writer.WriteLine(Formatter.HeaderText);
            for(var i=0u; i<count; i++)
                writer.WriteLine(Formatter.Format(skip(src, i)));
            return Wf.EmittedTable<BitMaskInfo>(flow, count, dst);
        }

        static Type DefaultProvider => typeof(BitMaskLiterals);
    }
}
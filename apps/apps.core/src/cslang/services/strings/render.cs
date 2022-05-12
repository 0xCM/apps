//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;
    using static CsLang;

    partial class StringTables
    {
        public static void render(uint margin, StringTable src, ITextBuffer dst)
        {
            var syntax = src.Syntax;
            if(src.EmitIdentifiers)
            {
                EmitIndex(margin, src, dst);
                dst.AppendLine();
            }

            dst.IndentLine(margin, PublicReadonlyStruct(syntax.TableName));
            dst.IndentLine(margin, Open());
            margin+=4;

            var OffsetsProp = nameof(MemoryStrings.Offsets);
            var DataProp = nameof(MemoryStrings.Data);
            var EntryCountProp = nameof(MemoryStrings.EntryCount);
            var CharCountProp = nameof(MemoryStrings.CharCount);
            var CharBaseProp = nameof(MemoryStrings.CharBase);
            var OffsetBaseProp = nameof(MemoryStrings.OffsetBase);
            var StringsProp = "Strings";

            dst.IndentLine(margin, Constant(EntryCountProp, src.EntryCount));
            dst.AppendLine();

            dst.IndentLine(margin, Constant(CharCountProp, (uint)src.Content.Length));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), CharBaseProp, Call("address", DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), OffsetBaseProp, Call("address", OffsetsProp)));
            dst.AppendLine();


            if(src.Syntax.Parametric)
                dst.IndentLine(margin, StaticLambdaProp(string.Format("{0}<{1}>", nameof(MemoryStrings), syntax.EnumName), StringsProp, Call("strings.memory", OffsetsProp, DataProp)));
            else
                dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryStrings), StringsProp, Call("strings.memory", OffsetsProp, DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, SpanResGen.format(SpanRes.bytespan(OffsetsProp, src.OffsetStorage)));
            dst.AppendLine();
            dst.IndentLine(margin, SpanResGen.format(SpanRes.charspan(DataProp, src.Content)));
            margin-=4;
            dst.IndentLine(margin, Close());
        }

        static void EmitIndex(uint margin, in StringTable src, ITextBuffer dst)
        {
            var count = src.EntryCount;
            var syntax = src.Syntax;
            dst.IndentLine(margin, string.Format("public enum {0} : {1}", syntax.EnumName, syntax.EnumKind.CsKeyword()));
            dst.IndentLine(margin, Chars.LBrace);
            margin+=4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var id = ref src.Identifier(i);
                if(id.IsEmpty)
                    break;
                dst.IndentLineFormat(margin, "{0} = {1},", id, i);
            }
            margin-=4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}
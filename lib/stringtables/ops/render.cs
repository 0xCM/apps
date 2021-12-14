//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;

    partial class StringTables
    {
        public static void render(uint margin, StringTable src, ITextBuffer dst)
        {
            var syntax = src.Syntax;
            GenIndex(margin, src, dst);
            dst.AppendLine();

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

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryStrings), StringsProp, Call("strings.memory", OffsetsProp, DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, SpanRes.bytespan(OffsetsProp, src.OffsetStorage).Format());
            dst.AppendLine();
            dst.IndentLine(margin, SpanRes.charspan(DataProp, src.Content).Format());
            margin-=4;
            dst.IndentLine(margin, Close());
        }

        static void GenIndex(uint margin, in StringTable src, ITextBuffer dst)
        {
            var count = src.EntryCount;
            var syntax = src.Syntax;
            dst.IndentLine(margin, string.Format("public enum {0} : {1}", syntax.IndexName, syntax.IndexKind.CsKeyword()));
            dst.IndentLine(margin, Chars.LBrace);
            margin+=4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var id = ref src.Identifier(i);
                if(id.IsEmpty)
                    break;
                dst.IndentLineFormat(margin, "{0}={1},", id, i);
            }
            margin-=4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}
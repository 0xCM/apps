//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsPatterns;

    partial class CsLang
    {
        static uint render(in StringTableSpec syntax, ItemList<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            var def = StringTables.define(syntax, src);
            render(4, def, dst);
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        static uint render(in StringTableSpec syntax, ReadOnlySpan<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            var def = StringTables.define(syntax, src);
            render(4, def, dst);
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        static void render(uint margin, StringTable src, ITextEmitter dst)
        {
            var syntax = src.Spec;
            if(src.Spec.EmitIndex)
            {
                RenderIndex(margin, src, dst);
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

            dst.IndentLine(margin, Constant(CharCountProp, src.Content.Count));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), CharBaseProp, Call("address", DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), OffsetBaseProp, Call("address", OffsetsProp)));
            dst.AppendLine();

            var FactoryName = string.Format("{0}.{1}", nameof(memory), nameof(memory.strings));
            var FactoryCreate = Call(FactoryName, OffsetsProp, DataProp);

            if(src.Spec.Parametric)
                dst.IndentLine(margin, StaticLambdaProp(string.Format("{0}<{1}>", nameof(MemoryStrings), syntax.IndexName), StringsProp, FactoryCreate));
            else
                dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryStrings), StringsProp, FactoryCreate));
            dst.AppendLine();

            dst.IndentLine(margin, GSpanRes.format(Z0.SpanRes.bytespan(OffsetsProp, src.Offsets.Storage)));
            dst.AppendLine();
            dst.IndentLine(margin, GSpanRes.format(Z0.SpanRes.charspan(DataProp,  new string(src.Content.Storage))));
            margin-=4;
            dst.IndentLine(margin, Close());
        }

        static void RenderIndex(uint margin, StringTable src, ITextEmitter dst)
        {
            var count = src.EntryCount;
            var syntax = src.Spec;
            dst.IndentLine(margin, string.Format("public enum {0} : {1}", syntax.IndexName, syntax.BaseType.CsKeyword()));
            dst.IndentLine(margin, Chars.LBrace);
            margin+=4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref src.Names[i];
                if(text.empty(name))
                    break;
                dst.IndentLineFormat(margin, "{0} = {1},", name, i);
            }
            margin-=4;
            dst.IndentLine(margin, Chars.RBrace);
        }
    }
}
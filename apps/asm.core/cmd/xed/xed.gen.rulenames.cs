//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/gen/rulenames")]
        Outcome ChecSeq(CmdArgs args)
        {
            var assets = AsmCaseAssets.create();
            var header = assets.XedFileHeader().Utf8();
            var path = FS.path(@"J:\z0\apps\asm.core\intel.xed\rules\models\RuleName.cs");
            var rules = Xed.Views.RuleTables;
            ref readonly var specs = ref rules.Specs();
            var rulenames = specs.Keys.Select(x => x.TableName.ToString()).ToHashSet();
            var names = rulenames.Index().Sort();

            var dst = text.emitter();
            dst.WriteLine(header);
            dst.WriteLine("namespace Z0");
            dst.WriteLine("{");
            var indent = 4u;

            dst.IndentLine(indent,"partial class XedRules");
            dst.IndentLine(indent,"{");
            indent+=4;
            dst.IndentLine(indent,"public enum RuleName : ushort");
            dst.IndentLine(indent,"{");
            var k=0u;
            indent += 4;
            dst.IndentLineFormat(indent, "{0} = {1},", "None", k++);
            dst.WriteLine();
            for(var i=0; i<names.Count; i++, k++)
            {
                ref readonly var name = ref names[i];
                dst.IndentLineFormat(indent, "{0} = {1},", name, k);
                if(i != names.Count-1)
                    dst.WriteLine();
            }
            indent -= 4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.Indent(indent,"}");
            using var writer = path.Utf8Emitter();
            writer.Write(dst.Emit());

            return true;
        }

        static byte _format(InstPattern pattern, Span<string> dst)
        {
            ref readonly var ops = ref pattern.Ops;

            var j=z8;
            seek(dst,j++) = string.Format("{0,-20} | {1,-4} | {2}", pattern.InstClass.Name, pattern.Mode, pattern.BodyExpr);
            seek(dst,j++) = string.Format("{0,-20} | {1}", pattern.OpCode, pattern.InstForm);

            for(var i=0; i<ops.Count; i++)
            {
                ref readonly var op = ref ops[i];
                seek(dst,j++) = string.Format("{0,20} | {1}", string.Format("{0} {1}", op.Index, op.Name), XedRender.format(op.Attribs));
            }
            return j;
        }

        void CheckPatterns(N0 n)
        {
            var forms = Symbols.index<IFormType>().Kinds.Map(x => (x,x)).ToConcurrentDictionary();
            var blocks = cdict<uint,string[]>();
            var patterns = cdict<uint,InstPattern>();
            var traversals = XedPatterns.traversals()
                                        .WithPreHandler(PatternTraversal);

            XedPatterns.traverser(traversals).TraversePatterns(Xed.Views.Patterns);

            void PatternTraversal(InstPattern pattern)
            {
                Require.invariant(patterns.TryAdd(pattern.PatternId,pattern));
                ref readonly var ops = ref pattern.Ops;
                var dst = alloc<string>(2 + ops.Count);
                _format(pattern, dst);
                blocks.TryAdd(pattern.PatternId, dst);
                if(pattern.InstForm.IsNonEmpty)
                    forms.TryRemove(pattern.InstForm);
            }

            var path = AppDb.Api().Path("xed.inst.patterns.opinfo", FileKind.Csv);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            var counter = 0u;

            var sorted = patterns.Values.Array().Sort();
            var opcode = XedOpCode.Empty;
            for(var i=0; i<sorted.Length; i++)
            {
                ref readonly var pattern = ref skip(sorted,i);
                if(pattern.OpCode != opcode)
                {
                    writer.WriteLine(RP.PageBreak120);
                    opcode = pattern.OpCode;
                }

                var lines = blocks[pattern.PatternId];
                for(var j=0; j<lines.Length; j++, counter++)
                    writer.WriteLine(skip(lines,j));
            }
            EmittedFile(emitting,counter);
            iter(forms.Values, f => Write(f.ToString()));

        }
    }
}
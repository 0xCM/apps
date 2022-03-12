//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var parsers = XedParsers.Service;
            var dst = AppDb.Log("xed.inst.body", FileKind.Txt);
            using var writer = dst.AsciWriter();
            var emitting = EmittingFile(dst);
            var result = Outcome.Success;
            var patterns = Xed.Rules.LoadPatternInfo();
            var count = patterns.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var source = ref pattern.Expression;
                writer.AppendLineFormat("Source -> {0}", source);
                result = parsers.Parse(source, out Index<InstDefSeg> segs);
                if(result.Fail)
                    break;

                render(segs,buffer);
                var target = buffer.Emit();
                writer.AppendLineFormat("Target <- {0}", target);
                writer.AppendLine();

                if(source != target)
                    Warn("'{0}' != '{1}'", source, target);
            }

            EmittedFile(emitting, count);

            return result;
        }

        static void render(ReadOnlySpan<InstDefSeg> src, ITextBuffer dst)
        {
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var seg = ref skip(src,i);
                if(i!=0)
                    dst.Append(Chars.Space);
                dst.Append(seg.Format());
            }
        }

        void CheckInstDefs1()
        {
            var dst = AppDb.Log("xed.patterns", FileKind.Txt);
            var emitting = EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.AsciWriter();
            void Print(string src)
            {
                writer.WriteLine(src);
                counter++;
            }
            var traverser = new InstTraverser(Xed, Print);
            traverser.Traverse();
            var patterns = traverser.Patterns();
            EmittedFile(emitting,counter);
        }
    }
}
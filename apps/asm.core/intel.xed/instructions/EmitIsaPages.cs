//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial class XedPatterns
    {
        static uint IsaOutCount;

        public void EmitIsaPages(Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            iter(src.GroupBy(x => x.Isa.Kind), g => EmitIsaGroup(g.Array()), PllExec);
        }

        void EmitIsaGroup(Index<InstPattern> src)
        {
            var outpath = FS.FilePath.Empty;
            var classifier = EmptyString;
            var buffer = text.buffer();
            var opsLU = XedRules.CalcOpRecords(src).GroupBy(x => x.PatternId).Map(x => (x.Key,x.ToArray())).ToConcurrentDictionary();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref src[i];
                if(pattern.Classifier != classifier)
                {
                    if(i!=0)
                    {
                        buffer.Emit(outpath);
                        inc(ref IsaOutCount);
                        if(IsaOutCount % 100 == 0)
                            Status(string.Format("Emitted {0} instructions", IsaOutCount));
                    }

                    classifier = pattern.Classifier;
                    outpath =  XedPaths.InstIsaPath(pattern);

                    buffer.AppendLineFormat("{0,-18} {1,-12} {2,-12}", pattern.Classifier, pattern.Isa.Name, pattern.Category);
                    buffer.AppendLine(RP.PageBreak80);
                }
                else
                    buffer.AppendLine(RP.PageBreak80);

                buffer.AppendLineFormat("{0} {1}", XedRender.semantic(pattern.OpCode), pattern.InstForm);
                var ops = sys.empty<PatternOpInfo>();
                if(opsLU.TryGetValue(pattern.PatternId, out ops))
                {
                    for(var j=0; j<ops.Length; j++)
                        buffer.AppendLine(XedRender.semantic(skip(ops,j)));
                }

                if(i==count - 1)
                    buffer.Emit(outpath);
            }
        }
    }
}
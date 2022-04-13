//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public readonly struct SeqDef
        {
            public readonly SeqType Type;

            public readonly Index<SeqStep> Steps;

            [MethodImpl(Inline)]
            public SeqDef(SeqType type, SeqStep[] steps)
            {
                Type = type;
                Steps = steps;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLineFormat("{0}(){{", Type);
                for(var i=0; i<Steps.Count; i++)
                {
                    ref readonly var step = ref Steps[i];
                    dst.IndentLineFormat(4,"{0}_{1}()", step.Kind, step.Effect);
                }
                dst.AppendLine("}");

                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}

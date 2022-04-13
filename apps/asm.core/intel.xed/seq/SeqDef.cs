//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct SeqDef
        {
            public readonly Index<SeqStep> Steps;

            public readonly SeqType Type;

            [MethodImpl(Inline)]
            public SeqDef(SeqType type, SeqStep[] steps)
            {
                Type = type;
                Steps = steps;
            }

            [MethodImpl(Inline)]
            public SeqDef(SeqKind kind, SeqStep[] steps)
            {
                Type = new (kind,0);
                Steps = steps;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLineFormat("{0}(){{", Type);
                for(var i=0; i<Steps.Count; i++)
                {
                    ref readonly var step = ref Steps[i];
                    dst.IndentLine(4,step.Format());
                }
                dst.AppendLine("}");

                return dst.Emit();
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SeqDef(SeqStep[] src)
                => new SeqDef(0,src);

            [MethodImpl(Inline)]
            public static implicit operator SeqDef(Index<SeqStep> src)
                => new SeqDef(0,src);

        }
    }
}

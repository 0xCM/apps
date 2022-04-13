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
            public readonly SeqType Type;

            public readonly Index<SeqStep> Steps;

            [MethodImpl(Inline)]
            public SeqDef(SeqStep[] steps)
            {
                Steps = steps;
                Type = SeqType.Empty;
            }

            [MethodImpl(Inline)]
            public SeqDef(Nonterminal name, SeqStep[] steps)
            {
                Steps = steps;
                Type = new(name);
            }

            [MethodImpl(Inline)]
            public SeqDef(SeqType type, SeqStep[] steps)
            {
                Steps = steps;
                Type = type;
            }

            [MethodImpl(Inline)]
            public SeqDef WithType(SeqType type)
                => new SeqDef(type, Steps);

            [MethodImpl(Inline)]
            public SeqDef WithType(Nonterminal name)
                => new SeqDef(name, Steps);

            [MethodImpl(Inline)]
            public SeqDef WithType(Nonterminal name, SeqEffect effect)
                => new SeqDef(new SeqType(name,effect), Steps);

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
                => new SeqDef(src);

            [MethodImpl(Inline)]
            public static implicit operator SeqDef(Index<SeqStep> src)
                => new SeqDef(src);
        }
    }
}

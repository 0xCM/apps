//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SeqDef
        {
            public readonly asci32 SeqName;

            public readonly SeqEffect Effect;

            public readonly Index<RuleName> Rules;

            [MethodImpl(Inline)]
            public SeqDef(asci32 name, SeqEffect effect, RuleName[] rules)
            {
                SeqName = name;
                Effect = effect;
                Rules = rules;
            }

            public string Format()
            {
                var dst = text.buffer();
                dst.AppendLineFormat("{0}(){{", SeqName);
                for(var i=0; i<Rules.Count; i++)
                    dst.IndentLineFormat(4, "{0}_{1}", Rules[i], Effect);
                dst.AppendLine("}");

                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}

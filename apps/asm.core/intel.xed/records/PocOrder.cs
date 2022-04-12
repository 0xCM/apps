//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct PocOrder : IComparer<PatternOpCode>
        {
            public readonly bit OpCodeFirst;

            public PocOrder(bit ocfirst)
            {
                OpCodeFirst = ocfirst;
            }

            public int Compare(PatternOpCode x, PatternOpCode src)
            {
                var result = 0;

                if(OpCodeFirst)
                {
                    result = x.OpCode.CompareTo(src.OpCode);
                    if(result == 0)
                        result = x.InstClass.CompareTo(src.InstClass);
                }
                else
                {
                    result = x.InstClass.CompareTo(src.InstClass);
                    if(result == 0)
                        result = x.OpCode.CompareTo(src.OpCode);
                }

                if(result == 0)
                    result = x.Mode.CompareTo(src.Mode);

                if(result == 0)
                    result = x.Lock.CompareTo(src.Lock);

                if(result == 0 && x.Mod.IsNonEmpty && src.Mod.IsNonEmpty)
                    result = x.Mod.CompareTo(src.Mod);

                if(result == 0 && x.RexW.IsNonEmpty && src.RexW.IsNonEmpty)
                    result = x.RexW.CompareTo(src.RexW);

                return result;
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct PatternOrder : IComparer<PatternOpCode>, IComparer<PatternOpDetail>
        {
            public readonly bit OpCodeFirst;

            public PatternOrder(bit ocfirst = default)
            {
                OpCodeFirst = ocfirst;
            }

            public int Compare(PatternOpDetail x, PatternOpDetail y)
            {
                var result = 0;

                result = x.InstClass.CompareTo(y.InstClass);
                if(result == 0)
                    result = x.OpCode.CompareTo(y.OpCode);

                if(result == 0)
                    result = x.Mode.CompareTo(y.Mode);

                if(result == 0)
                    result = x.Lock.CompareTo(y.Lock);

                if(result == 0 && x.Mod.IsNonEmpty && y.Mod.IsNonEmpty)
                    result = x.Mod.CompareTo(y.Mod);

                if(result == 0 && x.RexW.IsNonEmpty && y.RexW.IsNonEmpty)
                    result = x.RexW.CompareTo(y.RexW);

                if(result == 0)
                    result = x.PatternId.CompareTo(y.PatternId);

                if(result == 0)
                    result = x.Index.CompareTo(y.Index);

                return result;
            }

            public int Compare(PatternOpCode x, PatternOpCode y)
            {
                var result = 0;

                if(OpCodeFirst)
                {
                    result = x.OpCode.CompareTo(y.OpCode);
                    if(result == 0)
                        result = x.InstClass.CompareTo(y.InstClass);
                }
                else
                {
                    result = x.InstClass.CompareTo(y.InstClass);
                    if(result == 0)
                        result = x.OpCode.CompareTo(y.OpCode);
                }

                if(result == 0)
                    result = x.Mode.CompareTo(y.Mode);

                if(result == 0)
                    result = x.Lock.CompareTo(y.Lock);

                if(result == 0 && x.Mod.IsNonEmpty && y.Mod.IsNonEmpty)
                    result = x.Mod.CompareTo(y.Mod);

                if(result == 0 && x.RexW.IsNonEmpty && y.RexW.IsNonEmpty)
                    result = x.RexW.CompareTo(y.RexW);

                return result;
            }
        }
    }
}
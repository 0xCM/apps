//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct PatternOrder : IComparer<PatternOpCode>, IComparer<InstOpDetail>
        {
            public readonly bit OpCodeFirst;

            public PatternOrder(bit ocfirst = default)
            {
                OpCodeFirst = ocfirst;
            }

            public int Compare(InstOpDetail x, InstOpDetail y)
            {
                var a = new PatternSort(x);
                var b = new PatternSort(y);
                var result = a.CompareTo(b);
                if(result == 0)
                {
                    result = x.PatternId.CompareTo(y.PatternId);
                    if(result == 0)
                        result = x.Index.CompareTo(y.Index);
                }

                return result;
            }

            public int Compare(PatternOpCode x, PatternOpCode y)
                => new PatternSort(x).CompareTo(new PatternSort(y));
        }
    }
}
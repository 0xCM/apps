//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleTableBlock : IComparable<RuleTableBlock>
        {
            public readonly RuleTableKind TableKind;

            public readonly string TableName;

            public readonly uint Offset;

            public readonly Index<string> Data;

            [MethodImpl(Inline)]
            public RuleTableBlock(RuleTableKind kind, string name, uint offset, string[] src)
            {
                TableKind = kind;
                TableName = name;
                Offset = offset;
                Data = src;
            }

            public int CompareTo(RuleTableBlock src)
            {
                var result = TableName.CompareTo(src.TableName);
                if(result == 0)
                {
                    result = cmp(TableKind,src.TableKind);
                    if(result == 0)
                        result = Offset.CompareTo(src.Offset);
                }
                return result;
            }
        }
    }
}
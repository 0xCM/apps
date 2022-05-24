//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class XedOperands
    {
        static Index<XedRegId> Regs;

        static XedOperands()
        {
            Regs = Symbols.index<XedRegId>().Kinds.ToArray();
        }
    }
}
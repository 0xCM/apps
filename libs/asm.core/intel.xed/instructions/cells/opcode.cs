//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        partial struct InstCells
        {
            [MethodImpl(Inline), Op]
            public static XedOpCode opcode(in InstCells src)
                => XedOpCodes.opcode(src);

        }
    }
}
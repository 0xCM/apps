//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.OpCodeKind;

    using S = XedPatterns.OpCodeSymbols;

    partial class XedOpCodes
    {
        public static char indicator(OpCodeClass src)
            => src switch {
                OpCodeClass.Base => 'B',
                OpCodeClass.Xop => 'X',
                OpCodeClass.Vex => 'V',
                OpCodeClass.Evex => 'E',
                OpCodeClass.Amd3D => 'A',
                _ => (char)0
            };
    }
}
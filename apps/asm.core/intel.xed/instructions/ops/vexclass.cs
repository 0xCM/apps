//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
    {
        [Op]
        public static VexClass vexclass(OpCodeIndex src)
            => vexclass(XedPatterns.occlass(src));

        [Op]
        public static VexClass vexclass(OpCodeClass src)
        {
            var vc = VexClass.None;
            switch(src)
            {
                case OpCodeClass.Vex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Evex:
                    vc = VexClass.VV1;
                break;
                case OpCodeClass.Xop:
                    vc = VexClass.XOPV;
                break;
            }
            return vc;
        }
    }
}
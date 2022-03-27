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
        public static bool locked(IClass src)
            => text.ends(XedRender.format(src), "_LOCK");

        public static string classifier(InstClass src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = XedRender.format(src.Kind);
            if(text.ends(dst,"_LOCK"))
                dst = text.remove(dst,"_LOCK");

            return dst;
        }

        public static string name(OpCodeClass src)
            => src switch {
                OpCodeClass.Amd3D => "Amd3D",
                OpCodeClass.Evex => "Evex",
                OpCodeClass.Vex => "Vex",
                OpCodeClass.Xop => "Xop",
                OpCodeClass.Base => "Base",

                _ => EmptyString,
            };
    }
}
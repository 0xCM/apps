//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct expr
    {
        [Op]
        public static string resolve(VarContextKind vck, CmdScriptVar var)
            => string.Format(VarContextKinds.FormatPattern(vck), var.Value);

        [Op]
        public static string resolve<T>(VarContextKind vck, CmdScriptVar<T> var)
            => string.Format(VarContextKinds.FormatPattern(vck), var.Value);
    }
}
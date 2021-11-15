//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RuleModels
    {
        [Op]
        public static string resolve(VarContextKind vck, ScriptVar var)
            => string.Format(VarContextKinds.FormatPattern(vck), var.Value);

        [Op]
        public static string resolve<T>(VarContextKind vck, ScriptVar<T> var)
            => string.Format(VarContextKinds.FormatPattern(vck), var.Value);
    }
}
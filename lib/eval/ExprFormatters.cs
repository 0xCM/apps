//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using XF = ExprPatterns;

    using Expr;

    readonly struct ExprFormatters
    {
        [Op]
        public static string format(IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(var.Name), assign, var.Value);

        [Formatter]
        public static string format(IVarValue var)
            => format(var, Chars.Eq);

        [Op]
        public static string format(VarContextKind vck, IVarValue var, char assign)
            => string.Format("{0}{1}{2}", format(vck, var.Name), assign, var.Value);

        [Op]
        public static string format(VarContextKind vck, IVarValue var)
            => format(vck,var, Chars.Eq);


        [Formatter]
        internal static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        internal static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Value.Format() : string.Format(XF.TypedVar, src);

        [Formatter]
        internal static string format(in BoundVar src)
            => string.Format(XF.Binding, src.Var.Name, src.Value);
    }
}
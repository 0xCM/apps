//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;


    [ApiHost]
    public class Vars
    {
        const NumericKind Closure = UnsignedInts;

        public static string format(Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        public static string format<T>(Var<T> src, bool bind = true)
            => bind ? src.Value.ToString() : string.Format(XF.TypedVar, src);

        [MethodImpl(Inline), Op]
        public static ExprVar var(NameOld name)
            => new ExprVar(name);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(IVar var, T value)
            => value;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(Name var, T value)
            => value;

        public static ExprContext context()
            => new ExprContext();
    }
}

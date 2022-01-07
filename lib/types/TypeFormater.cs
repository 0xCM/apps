//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using K = TypeRefKind;


    public readonly struct TypeFormatter
    {
        public static string format(TypeSpec src, params object[] args)
            => absorb(src, args);

        public static string format(TypeRef src, params object[] args)
            => string.Format(pattern(src.Kind), absorb(src.Type));

        public static string absorb(TypeSpec src, params object[] args)
            => args.Length != 0 ? string.Format(src.Text, args) : src.Text;

        public static string pattern(TypeRefKind kind)
            => kind switch{
                K.In => "in {0}",
                K.Out => "out {0}",
                K.Ptr => "{0}*",
                _ => "{0}",
            };
    }
}

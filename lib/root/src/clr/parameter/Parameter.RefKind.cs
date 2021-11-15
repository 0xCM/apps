//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines the variance of a parameter
        /// </summary>
        /// <param name="src">The source parameter</param>
        [MethodImpl(Inline), Op]
        public static ClrArgRefKind RefKind(this ParameterInfo src)
            => src.IsIn
            ? ClrArgRefKind.In  : src.IsOut
            ? ClrArgRefKind.Out : src.ParameterType.IsByRef
            ? ClrArgRefKind.Ref : ClrArgRefKind.None;

        [MethodImpl(Inline), Op]
        public static string Keyword(this ClrArgRefKind src)
            => src switch{
                ClrArgRefKind.In => "in",
                ClrArgRefKind.Out => "out",
                ClrArgRefKind.Ref => "ref",
                _ => ""
            };

        [MethodImpl(Inline), Op]
        public static string Format(this ClrArgRefKind src)
            => src != 0 ? ('~' + src.Keyword()) : string.Empty;
    }
}
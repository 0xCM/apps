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
        [MethodImpl(Inline), Op]
        public static GenericState GenericState(this MethodInfo src)
            =>  src.IsClosedGeneric() ? GenericStateKind.ClosedGeneric
               : src.IsOpenGeneric() ? GenericStateKind.OpenGeneric
               : GenericStateKind.Nongeneric;
    }
}
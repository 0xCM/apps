//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class NativeTypes
    {
        public static NumericKind numkind(Type t)
            => t.IsSegmented() ?  t.SuppliedTypeArgs().First().NumericKind() : NumericKind.None;
    }
}
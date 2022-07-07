//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct Clr
    {
        [Op]
        public static ReadOnlySpan<ClrAssemblyName> references(Assembly src)
            => recover<AssemblyName, ClrAssemblyName>(src.GetReferencedAssemblies().ToSpan());
    }
}
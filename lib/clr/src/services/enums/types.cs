//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial struct Enums
    {
        /// <summary>
        /// Queries the source assemblies for enum types
        /// </summary>
        /// <param name="src">The assemblies to query</param>
        [Op]
        public static Index<KeyedValues<ClrAssemblyName,Type>> types(params Assembly[] src)
        {
            var x = from part in src
                    let enums = part.Enums()
                    orderby part.FullName
                    select Lookups.keyed(new ClrAssemblyName(part), enums);
            return x;
        }
    }
}
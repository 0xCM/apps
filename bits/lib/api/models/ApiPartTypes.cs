//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Collects the types defined by a part
    /// </summary>
    public readonly struct ApiPartTypes
    {
        [MethodImpl(Inline), Op]
        public static ApiPartTypes from(IPart src)
            => new ApiPartTypes(src.Id, src.Owner.Types());

        public PartId Part {get;}

        public Index<Type> Types {get;}

        [MethodImpl(Inline)]
        public ApiPartTypes(PartId part, Type[] types)
        {
            Part = part;
            Types = types;
        }
    }
}
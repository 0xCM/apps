//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public struct BCastKind<K> : IEnumCover<BCastKind<K>, K>
            where K : unmanaged, Enum
        {
            public K Value {get; set;}

            public BCastClass Class {get;set;}

            [MethodImpl(Inline)]
            public BCastKind(K value, BCastClass @class)
            {
                Value = value;
                Class = @class;
            }
        }
    }
}
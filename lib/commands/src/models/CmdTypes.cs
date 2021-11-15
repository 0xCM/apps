//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdTypes : IIndex<CmdTypeInfo>
    {
        Index<CmdTypeInfo> Data;

        [MethodImpl(Inline)]
        public CmdTypes(CmdTypeInfo[] src)
            => Data = src;

        public CmdTypeInfo[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdTypes(CmdTypeInfo[] src)
            => new CmdTypes(src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdFlagSpecs : IIndex<CmdFlagSpec>
    {
        readonly Index<CmdFlagSpec> Data;

        [MethodImpl(Inline)]
        public CmdFlagSpecs(CmdFlagSpec[] src)
            => Data = src;

        public CmdFlagSpec[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdFlagSpecs(CmdFlagSpec[] src)
            => new CmdFlagSpecs(src);
    }
}
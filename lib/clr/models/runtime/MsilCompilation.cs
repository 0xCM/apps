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
    /// Specifies a <see cref='MsilSourceBlock'/> along with the compiled entry point
    /// </summary>
    public readonly struct MsilCompilation
    {
        public MsilSourceBlock Msil {get;}

        public MemoryAddress EntryPoint {get;}

        [MethodImpl(Inline)]
        public MsilCompilation(MsilSourceBlock msil, MemoryAddress entry)
        {
            Msil = msil;
            EntryPoint = entry;
        }
    }
}
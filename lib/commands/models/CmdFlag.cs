//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdFlag
    {
        public string Name {get;}

        public bit State {get;}

        [MethodImpl(Inline)]
        public CmdFlag(string name, bit state)
        {
            Name = name;
            State = state;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(CmdFlag src)
            => src.State ? new CmdArg(src.Name) : CmdArg.Empty;
    }
}
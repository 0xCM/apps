//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct BitPattern : IDataPattern<bit>
    {
        public MatchKind MatchKind {get;}

        public readonly bit State;

        [MethodImpl(Inline)]
        public BitPattern(MatchKind kind, bit state)
        {
            MatchKind = kind;
            State = state;
        }

        bit IDataPattern<bit>.Content
            => State;

        public static implicit operator BitPattern(bit state)
            => new BitPattern(MatchKind.Enabled, state);
    }
}
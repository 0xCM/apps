//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DataSlot
    {
        public byte Index {get;}

        public short Pad {get;}

        [MethodImpl(Inline)]
        public DataSlot(byte index, short pad)
        {
            Index = index;
            Pad = pad;
        }

        public string Format()
            => string.Format(RP.slot(Index,Pad));

        public override string ToString()
            => Format();
    }
}

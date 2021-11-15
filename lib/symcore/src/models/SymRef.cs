//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SymRef
    {
        public readonly ushort Seg;

        public readonly ushort Key;

        [MethodImpl(Inline)]
        public SymRef(ushort seg, ushort key)
        {
            Seg = seg;
            Key = key;
        }

        public string Format()
            => string.Format("{0:D5}:{1:D5}", Seg, Key);

        public override string ToString()
            => Format();
    }
}
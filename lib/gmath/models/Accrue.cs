//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct Accrue<I>
        where I : unmanaged
    {
        I Total;

        [MethodImpl(Inline)]
        public void Next(I i)
            => Total = gmath.add(Total, i);

        public string Format()
            => Total.ToString();

        public override string ToString()
            => Format();
    }
}
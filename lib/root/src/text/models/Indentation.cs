//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct Indentation
    {
        public byte Scale {get;}

        byte _Current;

        [MethodImpl(Inline)]
        public Indentation(byte current, byte scale)
        {
            _Current = current;
            Scale = scale;
        }

        [MethodImpl(Inline)]
        public Indentation Advance(byte levels)
        {
            _Current = (byte)(_Current + (byte)(levels*Scale));
            return this;
        }
    }
}
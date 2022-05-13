//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct BitPattern
    {
        public readonly asci16 State;

        [MethodImpl(Inline)]
        public BitPattern(asci16 state)
        {
            State = state;
        }

        public static implicit operator BitPattern(asci16 state)
            => new BitPattern(state);
    }
}
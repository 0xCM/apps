//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Asci
    {
        static AsciSymbols AsciStrings => default;
        [MethodImpl(Inline)]
        static int IndexLength(int i, int max)
            => found(i) ? i : max;
    }
}
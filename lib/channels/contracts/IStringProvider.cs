//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IStringProvider : IReadOnlySpanProvider<char>
    {
        new string Data();

        ReadOnlySpan<char> IReadOnlySpanProvider<char>.Data()
            => Data();
    }
}
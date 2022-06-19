//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an object that advertises its memory location
    /// </summary>
    [Free]
    public interface IAddressable : ISized
    {
        MemoryAddress Address {get;}
    }
}
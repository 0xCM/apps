//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A byte, just one
    /// </summary>
    public interface IByte : IHashed, ISized
    {
        byte Value {get;}

        BitWidth ISized.Width
            => 8;

        ByteSize ISized.Size
            => 1;

        uint IHashed.Hash
            => Value;
    }

    public interface IByte<F> : IByte, IHashed
        where F : unmanaged, IByte<F>
    {

    }
}
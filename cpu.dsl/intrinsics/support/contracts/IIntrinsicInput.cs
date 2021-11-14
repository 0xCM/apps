//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    public interface IIntrinsicInput
    {
        IntrinsicKind Kind {get;}
    }

    public interface IIntrinsicInput<T> : IIntrinsicInput
        where T : unmanaged, IIntrinsicInput<T>
    {

    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IUnarySquare<W,T> : IUnaryRefOp<W,T>, IUnaryRefStepOp<W,T>
        where T : unmanaged
        where W : unmanaged, ITypeWidth
    {

    }
}
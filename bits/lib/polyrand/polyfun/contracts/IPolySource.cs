//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IPolySource : IBoundSource,
        IBoundSource<sbyte>,
        IBoundSource<byte>,
        IBoundSource<short>,
        IBoundSource<ushort>,
        IBoundSource<int>,
        IBoundSource<uint>,
        IBoundSource<long>,
        IBoundSource<ulong>,
        IBoundSource<float>,
        IBoundSource<double>
    {

    }
}
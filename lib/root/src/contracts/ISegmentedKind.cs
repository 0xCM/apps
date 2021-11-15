//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISegmentedKind : ILiteralKind<NativeSegKind>
    {
        NativeTypeWidth BlockWidth => default;
    }

    [Free]
    public interface ISegmentedKind<B> : ISegmentedKind, ILiteralKind<B,NativeSegKind>
        where B : struct, ISegmentedKind<B>
    {

    }

    [Free]
    public interface ISegmentedKind<W,T> : ISegmentedKind, ILiteralType<NativeSegKind,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        NativeSegKind ITypedLiteral<NativeSegKind>.Class
            => NativeSegKinds.kind<W,T>();

        NativeTypeWidth ISegmentedKind.BlockWidth
            => default(W).TypeWidth;
    }

    [Free]
    public interface ISegmetedKind<B,W,T> : ISegmentedKind<W,T>, ISegmentedKind<B>
        where B : struct, ISegmetedKind<B,W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {

    }
}
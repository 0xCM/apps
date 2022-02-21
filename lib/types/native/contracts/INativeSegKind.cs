//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface INativeSegKind : ILiteralKind<NativeSegKind>
    {
        NativeTypeWidth BlockWidth => default;
    }

    [Free]
    public interface INativeSegKind<B> : INativeSegKind, ILiteralKind<B,NativeSegKind>
        where B : struct, INativeSegKind<B>
    {

    }

    [Free]
    public interface INativeSegKind<W,T> : INativeSegKind, ILiteralType<NativeSegKind,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        NativeSegKind ITypedLiteral<NativeSegKind>.Class
            => NativeTypes.segkind<W,T>();

        NativeTypeWidth INativeSegKind.BlockWidth
            => default(W).TypeWidth;
    }

    [Free]
    public interface INativeSegKind<B,W,T> : INativeSegKind<W,T>, INativeSegKind<B>
        where B : struct, INativeSegKind<B,W,T>
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {

    }
}
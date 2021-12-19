//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileType : IType
    {
        ulong IType.Kind
            => 0;

        Index<FS.FileExt> DefaultExtensions {get;}

        FS.FileExt PrimaryExtension
            => DefaultExtensions.IsNonEmpty ?  DefaultExtensions.First : FS.FileExt.Empty;
        string ITextual.Format()
            => PrimaryExtension.Format();
    }

    public interface IFileType<K> : IFileType, IType<K>
        where K : unmanaged
    {
        ulong IType.Kind
            => core.bw64(Kind);
    }
}
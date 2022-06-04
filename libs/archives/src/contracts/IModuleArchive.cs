//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IModuleArchive : IFileArchive
    {
        Index<ManagedDllFile> ManagedDll();

        Index<NativeDllFile> NativeDll();

        Index<ManagedExeFile> ManagedExe();

        Index<NativeExeFile> NativeExe();

        Index<NativeLibFile> Lib();

        Index<ObjFile> Obj();

        Index<FileModule> Members();
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ModuleArchive : IModuleArchive
    {
        public readonly FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        internal ModuleArchive(FS.FolderPath root)
            => Root = root;

        public Index<ManagedDllFile> ManagedDll()
            => ManagedDllFiles().Array();

        public Index<NativeDllFile> NativeDll()
            => NativeDllFiles().Array();

        public Index<ManagedExeFile> ManagedExe()
            => ManagedExeFiles().Array();

        public Index<NativeExeFile> NativeExe()
            => NativeExeFiles().Array();

        public Index<NativeLibFile> Lib()
            => NativeLibFiles().Array();

        public Index<FileModule> Members()
            => Modules().Array();

        public Index<ObjFile> Obj()
            => ObjFiles().Array();

        public bool IsManaged(FS.FilePath src, out AssemblyName name)
            => FS.managed(src, out name);

        IEnumerable<ObjFile> ObjFiles()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Obj))
                    yield return new ObjFile(path);
        }

        IEnumerable<ManagedDllFile> ManagedDllFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll)))
                if(IsManaged(path, out var assname))
                    yield return new ManagedDllFile(path, assname);
        }

        IEnumerable<NativeDllFile> NativeDllFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll)))
                if(FS.native(path))
                    yield return new NativeDllFile(path);
        }

        IEnumerable<ManagedExeFile> ManagedExeFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(IsManaged(path, out var assname))
                    yield return new ManagedExeFile(path, assname);
        }

        IEnumerable<NativeExeFile> NativeExeFiles()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(FS.native(path))
                    yield return new NativeExeFile(path);
        }

        IEnumerable<NativeLibFile> NativeLibFiles()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Lib))
                    yield return new NativeLibFile(path);
        }

       IEnumerable<FileModule> Modules()
        {
            foreach(var path in Root.Files(true))
            {
                if(path.Is(FS.Dll))
                {
                    if(IsManaged(path, out var assname))
                        yield return new ManagedDllFile(path, assname);
                    else
                        yield return new NativeDllFile(path);
                }
                else if(path.Is(FS.Exe))
                {
                    if(IsManaged(path, out var assname))
                        yield return new ManagedExeFile(path, assname);
                    else
                        yield return new NativeExeFile(path);
                }
                else if(path.Is(FS.Lib))
                    yield return new NativeLibFile(path);
            }
        }
    }
}
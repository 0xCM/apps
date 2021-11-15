//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static FileModuleKind;
    using static Root;

    [Service]
    public struct ModuleArchive
    {
        /// <summary>
        /// Creates an archive over both managed and unmanaged modules
        /// </summary>
        /// <param name="root">The archive root</param>
        [MethodImpl(Inline), Op]
        public static ModuleArchive create(FS.FolderPath root)
            => new ModuleArchive(root);

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        internal ModuleArchive(FS.FolderPath root)
            => Root = root;
        public Index<FileModule> ManagedDllFiles()
            => dll_managed().Array();

        public Index<FileModule> NativeDllFiles()
            => dll_native().Array();

        public Index<FileModule> ManagedExeFiles()
            => exe_managed().Array();

        public Index<FileModule> NativeExeFiles()
            => exe_native().Array();

        public Index<FileModule> StaticLibs()
            => lib_native().Array();

        public Index<FileModule> ArchiveFiles()
            => modules().Array();

        public Index<FileModule> ObjFiles()
            => obj_files().Array();

        public bool IsManaged(FS.FilePath src, out AssemblyName name)
            => FS.managed(src, out name);

        IEnumerable<FileModule> obj_files()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Obj))
                    yield return new NativeLibFile(path);
        }

        IEnumerable<FileModule> dll_managed()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll)))
                if(IsManaged(path, out var assname))
                    yield return new ManagedDllFile(path, assname);
        }

        IEnumerable<FileModule> dll_native()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Dll)))
                if(FS.native(path))
                    yield return new NativeDllFile(path);
        }

        IEnumerable<FileModule> exe_managed()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(IsManaged(path, out var assname))
                    yield return new ManagedExeFile(path, assname);
        }

        IEnumerable<FileModule> exe_native()
        {
            foreach(var path in Root.Files(true).Where(f => f.Is(FS.Exe)))
                if(FS.native(path))
                    yield return new NativeExeFile(path);
        }

        IEnumerable<FileModule> lib_native()
        {
            foreach(var path in Root.Files(true))
                if(path.Is(FS.Lib))
                    yield return new NativeLibFile(path);
        }

       IEnumerable<FileModule> modules()
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
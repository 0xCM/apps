//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static core;

    public class AppModules : AppService<AppModules>
    {
        public PdbSymbolSource SymbolSource(FileModule src)
        {
            try
            {
                return PdbServices.source(src.Path, src.Path.ChangeExtension(FS.Pdb));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return PdbSymbolSource.Empty;
            }
        }

        public PdbSymbolSource SymbolSource(FS.FilePath module)
            => PdbServices.source(module);

        public ModuleArchive Archive()
            => ModuleArchive.create(FS.path(controller().Location).FolderPath);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ModuleArchives : AppService<ModuleArchives>
    {
        public IModuleArchive PartArchive()
            => new ModuleArchive(FS.path(Assembly.GetEntryAssembly().Location).FolderPath);

        /// <summary>
        /// Creates an archive over both managed and unmanaged modules
        /// </summary>
        /// <param name="root">The archive root</param>
        [MethodImpl(Inline), Op]
        public static ModuleArchive archive(FS.FolderPath root)
            => new ModuleArchive(root);
    }
}
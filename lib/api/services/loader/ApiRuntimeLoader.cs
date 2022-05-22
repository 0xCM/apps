//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct ApiRuntimeLoader
    {
        const PartId FirstShell = PartId.CgShell;

        public static FS.FilePath path(Assembly src)
            => FS.path(src.Location);

        public static FS.FolderPath dir(Assembly src)
            => path(src).FolderPath;

        [Op]
        internal static FolderFiles managed(FS.FolderPath dir, bool libonly)
        {
            var src = dir.Exclude("System.Private.CoreLib");
            if(libonly)
                src = src.Where(x => !x.Format().EndsWith(".exe"));
            return new FolderFiles(dir, src.Where(f => FS.managed(f)));
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConfigPaths
    {
        public static FS.FilePath app()
            => FS.path(ExecutingPart.Component.Location).FolderPath + FS.file("app.settings", FileKind.Csv);

        public static FS.FilePath cmd()
            => Settings.path();
    }
}
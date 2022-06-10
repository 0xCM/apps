//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DbPaths
    {
        public static DbPaths load()
        {
            var dst = new DbPaths();
            var src = AppData.GlobalSettings;
            var setting = Setting.Empty;
            if(src.Lookup(nameof(Sources), out setting))
                dst._Sources = FS.dir(setting.ValueText);
            if(src.Lookup(nameof(Targets), out setting))
                dst._Targets = FS.dir(setting.ValueText);
            if(src.Lookup(nameof(Control), out setting))
                dst._Control = FS.dir(setting.ValueText);
            return dst;
        }

        public ref readonly FS.FolderPath Sources
        {
            [MethodImpl(Inline)]
            get => ref _Sources;
        }

        public ref readonly FS.FolderPath Targets
        {
            [MethodImpl(Inline)]
            get => ref _Targets;
        }

        public ref readonly FS.FolderPath Control
        {
            [MethodImpl(Inline)]
            get => ref _Control;
        }

        DbPaths()
        {


        }

        FS.FolderPath _Sources;

        FS.FolderPath _Targets;

        FS.FolderPath _Control;
    }
}
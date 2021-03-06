//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        public static SettingType type<T>(T src)
            => type(src.GetType());

        public static SettingType type(Type src)
        {
            var dst = SettingType.None;
            if(src == typeof(bool))
                dst = SettingType.Bool;
            else if(src == typeof(string))
                dst = SettingType.String;
            else if(src == typeof(FS.FilePath) || src == typeof(FS.FileUri))
                dst = SettingType.File;
            else if(src == typeof(FS.FolderPath))
                dst = SettingType.Folder;
            return dst;
        }
    }
}
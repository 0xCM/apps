//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public unsafe class QueueCmd : CmdService<QueueCmd>
    {

        FS.FilePath SettingsPath()
            => FS.path(ExecutingPart.Component.Location).FolderPath + FS.file($"{ExecutingPart.Id.Format()}.settings", FileKind.Csv);

        public AppSettings Settings()
            => AppSettings.load(SettingsPath());

        [CmdOp("part/settings")]
        void PartSettings()
            => Settings().Iter(setting => setting.Format(Chars.Colon));
        // {
        //     var part = ExecutingPart.Id.Format();
        //     var dir = FS.path(ExecutingPart.Component.Location).FolderPath;
        //     var file = FS.file($"{part}.settings", FileKind.Csv);
        //     var path = dir + file;
        //     var settings = AppSettings.load(SettingsPath());
        //     settings.Iter(setting => Write(setting.Format(Chars.Colon)));
        // }

    }
}

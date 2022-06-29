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

        public Settings LoadSettings()
            => Settings.table(SettingsPath());

        [CmdOp("part/settings")]
        void PartSettings()
        {
            var path = SettingsPath();
            var table = Settings.table(path);
            table.Iter(setting => Write(setting.Format(Chars.Colon)));
        }

    }
}

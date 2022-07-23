//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Loggers;

    public readonly record struct LogSettings
    {
        public readonly string LogId;

        /// <summary>
        /// The controlling part identifier
        /// </summary>
        public readonly PartId Control;

        /// <summary>
        /// The log file root directory
        /// </summary>
        public readonly FS.FolderPath LogRoot;

        /// <summary>
        /// The status log path
        /// </summary>
        public readonly FS.FilePath StatusPath;

        /// <summary>
        /// The error log path
        /// </summary>
        public readonly FS.FilePath ErrorPath;

        public LogSettings(FS.FolderPath root)
        {
            var ts = core.timestamp();
            var control = ExecutingPart.Component;
            LogId = control.Format();
            LogRoot = root.Create();
            Control = control.Id();
            StatusPath = LogRoot + FS.folder($"{control.Format()}/status") + FS.file($"{LogId}.status.{ts}", FS.Log);
            ErrorPath = LogRoot + FS.folder(control.Format()) + FS.file($"{LogId}.errors.{ts}", FS.Log);
        }

        public LogSettings(PartId control, FS.FolderPath root, string name = EmptyString)
        {
            LogId = text.empty(name) ? control.Format() : $"{control.Format()}.{name}";
            Control = control;
            LogRoot = root;
            var ts = core.timestamp();
            StatusPath = LogRoot + FS.folder($"{control.Format()}/status") + FS.file($"{LogId}.status.{ts}", FS.Log);
            ErrorPath = LogRoot + FS.folder(control.Format()) + FS.file($"{LogId}.errors.{ts}", FS.Log);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
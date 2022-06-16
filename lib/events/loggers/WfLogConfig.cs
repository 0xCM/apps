//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Loggers;

    public readonly struct WfLogConfig : IWfLogConfig
    {
        public string LogId {get;}

        /// <summary>
        /// The controlling part identifier
        /// </summary>
        public PartId Control {get;}

        /// <summary>
        /// The log file root directory
        /// </summary>
        public FS.FolderPath LogRoot  {get;}

        /// <summary>
        /// The status log path
        /// </summary>
        public FS.FilePath StatusPath {get;}

        /// <summary>
        /// The error log path
        /// </summary>
        public FS.FilePath ErrorPath {get;}

        [MethodImpl(Inline)]
        public WfLogConfig(PartId control, FS.FolderPath root, string name = EmptyString)
        {
            LogId = text.empty(name) ? control.Format() : $"{control.Format()}.{name}";
            Control = control;
            LogRoot = root;
            var ts = core.timestamp();
            StatusPath = LogRoot + FS.file($"{LogId}.status.{ts}", FS.Log);
            ErrorPath = LogRoot + FS.file($"{LogId}.errors.{ts}", FS.Log);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}
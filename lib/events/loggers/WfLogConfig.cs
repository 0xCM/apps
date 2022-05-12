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
        public PartId ControlId {get;}

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
            LogId = text.empty(name) ? control.Format() : string.Format("{0}.{1}", control.Format(), name);
            LogRoot = root + FS.folder("logs");
            ControlId = control;
            StatusPath = LogRoot +  FS.file(LogId, FS.StatusLog);
            ErrorPath = LogRoot + FS.file(LogId, FS.ErrorLog);
        }

        public override string ToString()
            => api.format(this);
    }
}
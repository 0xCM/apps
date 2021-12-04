//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Loggers;

    public readonly struct WfLogConfig : IWfLogConfig
    {
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
            LogRoot = root + FS.folder("logs");
            ControlId = control;
            var app = ControlId.Format();
            var logname = text.empty(name) ? app : string.Format("{0}.{1}", app, name);
            StatusPath = LogRoot +  FS.file(logname, FS.StatusLog);
            ErrorPath = LogRoot + FS.file(logname, FS.ErrorLog);
        }

        public override string ToString()
            => api.format(this);
    }
}
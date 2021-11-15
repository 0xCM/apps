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
        public FS.FilePath StatusLog {get;}

        /// <summary>
        /// The error log path
        /// </summary>
        public FS.FilePath ErrorLog {get;}

        [MethodImpl(Inline)]
        public WfLogConfig(PartId control, FS.FolderPath root)
        {
            LogRoot = root + FS.folder("logs");
            ControlId = control;
            var app = ControlId.Format();
            StatusLog = LogRoot + FS.file(app, FS.StatusLog);
            ErrorLog = LogRoot + FS.file(app, FS.ErrorLog);
        }

        public override string ToString()
            => api.format(this);
    }
}
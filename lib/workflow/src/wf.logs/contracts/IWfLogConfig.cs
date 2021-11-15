//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Loggers;

    public interface IWfLogConfig : ITextual
    {
        /// <summary>
        /// The log file root directory
        /// </summary>
        FS.FolderPath LogRoot {get;}

        /// <summary>
        /// The controlling part identifier
        /// </summary>
        PartId ControlId {get;}

        /// <summary>
        /// The controlling part name
        /// </summary>
        string ControlName
            => ControlId.Format();

        /// <summary>
        /// The status log path
        /// </summary>
        FS.FilePath StatusLog
            => LogRoot + FS.file(ControlName, FS.StatusLog);

        /// <summary>
        /// The error log path
        /// </summary>
        FS.FilePath ErrorLog
            => LogRoot + FS.file(ControlName, FS.ErrorLog);
        string ITextual.Format()
            => api.format(this);
    }
}
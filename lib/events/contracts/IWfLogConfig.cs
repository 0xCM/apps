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
        FS.FilePath StatusPath {get;}

        /// <summary>
        /// The error log path
        /// </summary>
        FS.FilePath ErrorPath {get;}
        string ITextual.Format()
            => api.format(this);
    }
}
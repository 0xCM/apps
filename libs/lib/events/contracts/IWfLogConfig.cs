//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfLogConfig
    {
        /// <summary>
        /// The log file root directory
        /// </summary>
        FS.FolderPath LogRoot {get;}

        /// <summary>
        /// The controlling part identifier
        /// </summary>
        PartId Control {get;}

        /// <summary>
        /// The status log path
        /// </summary>
        FS.FilePath StatusPath {get;}

        /// <summary>
        /// The error log path
        /// </summary>
        FS.FilePath ErrorPath {get;}
    }
}
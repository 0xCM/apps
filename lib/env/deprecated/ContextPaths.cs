//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        FS.FilePath ContextTable<T>(Timestamp ts)
            where T : struct, IRecord<T>
                => CaptureContextRoot() + FS.file(string.Format("{0}.{1}", Z0.TableId.identify<T>(), ts.Format()), FS.Csv);
    }
}
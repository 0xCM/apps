//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial interface IEnvPaths
    {
        FS.FileName HostFile(ApiHostUri host, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}", host.Part.Format(), host.HostName), ext);
    }
}
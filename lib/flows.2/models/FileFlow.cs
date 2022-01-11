//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileFlow : Flow<FS.FilePath,FS.FilePath>
    {
        protected FileFlow(IFileFlowType type, FS.FilePath src, FS.FilePath dst)
            : base(type,src,dst)
        {

        }
    }
}
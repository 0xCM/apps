//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static MsDocs;

    public readonly partial struct MsDocs
    {

    }

    public class MsDocPipe : AppService<MsDocPipe>
    {
        public void Process(FS.FolderPath src, FS.FilePath dst)
        {
            Processor.run(src,dst);
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Toolz
{
    using static MsDocs;

    public readonly partial struct MsDocs
    {

    }

    public class MsDocsService : AppService<MsDocsService>
    {
        public void Process(FS.FolderPath src, FS.FilePath dst)
        {
            Processor.run(src,dst);
        }
    }
}
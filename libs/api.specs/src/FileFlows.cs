//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileFlows : AppService<FileFlows>
    {
        [MethodImpl(Inline)]
        public static FileFlowKind kind(FileKind src, FileKind dst)
            =>  new (src,dst);

        //public static FileFlow kind(FileKind src, FileKind dst)

    }
}
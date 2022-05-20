//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmObjects
    {
        public static Outcome parse(WsContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().ParseSource(context, src, out dst);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static MemDb;
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("memdb/check")]
        void CheckMemDb()
        {
            CheckMemDb((32,32));
            CheckMemDb((12,12));
            CheckMemDb((8,8));
            CheckMemDb((256,256));

            var size = 1073741824ul;
            var mb = size/1024;

            var db = XedDb.Store;
            //var db = MemDb.open(AppDb.Targets("memdb").Path("runtime", FileKind.Bin), new Gb(1));
            var path = XedPaths.InstDumpSource();
            var data = path.ReadBytes();
            var token = db.Store(data);
        }
    }
}
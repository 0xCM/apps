//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class DbCmd : AppCmdService<DbCmd>
    {
        [CmdOp("db/purge")]
        void Purge(CmdArgs args)
        {
            var src = AppDb.DbRoot().Scoped(FS.relative(arg(args,0).Value)).Root;
            Write(src);
        }
    }
}
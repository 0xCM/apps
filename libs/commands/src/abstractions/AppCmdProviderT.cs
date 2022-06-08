//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class AppCmdProvider<T> : AppService<T>, ICmdProvider
        where T : AppCmdProvider<T>, new()
    {
        protected AppSvcOps AppSvc => Wf.AppSvc();

        protected AppDb AppDb => Wf.AppDb();

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";

        protected static CmdArg arg(in CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Length;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }
    }
}
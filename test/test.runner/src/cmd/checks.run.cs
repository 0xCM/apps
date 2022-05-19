//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class CheckRunCmd
    {
        [CmdOp("checks/run")]
        Outcome RumCheckers(CmdArgs args)
        {
            if(args.Count == 0)
                iter(CheckServices.Values, svc => svc.Run());
            else
            {
                var count = args.Count;
                for(var i=0; i<count; i++)
                {
                    var name = args[0].Value;
                    if(CheckServices.Find(name, out var checker))
                    {
                        checker.Run();
                    }
                    else
                    {
                        Warn(string.Format("{0} checker not found", name));
                    }
                }
            }
            return true;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class CheckRunCmd
    {
        [CmdOp("checks/list")]
        Outcome ListCheckers(CmdArgs args)
        {
            foreach(var svc in CheckServices.Values)
            {
                foreach(var c in svc.Checks)
                {
                    Write(string.Format("{0}/{1}", svc.Name, c));
                }
            }
            return true;
        }
    }
}
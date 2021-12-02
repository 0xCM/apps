//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".llvm-config")]
        Outcome LlvmConfig(CmdArgs args)
        {
           var config = LlvmEtl.ComputeConfig();
           var items = config.Items;
           foreach(var item in items)
           {
               Write(string.Format("{0}:{1}", item.Key, item.Value));
           }
           return true;
        }
    }
}
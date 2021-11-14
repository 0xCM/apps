//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp(".inst-info")]
        Outcome ShowInstInfo(CmdArgs args)
        {
            var result = Sdm.LoadImportedOpcodes();
            var selected = args.Length > 0 ? arg(args,0).Value : EmptyString;
            result.OnSuccess(records =>{
                var count = records.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var r = ref records[i];
                    if(empty(selected))
                    {
                        Write(string.Format("# ({0}) = {1} - {2}", r.Sig, r.OpCode, r.Description));
                    }
                    else
                    {
                        var sig = r.Sig.Format();
                        if(text.contains(sig,selected,false))
                            Write(string.Format("# ({0}) = {1} - {2}", r.Sig, r.OpCode, r.Description));
                    }
                }
            });

            return result;
        }
    }
}
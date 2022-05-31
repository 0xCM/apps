//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("sdm/inst")]
        Outcome ShowInstInfo(CmdArgs args)
        {
            var details = Sdm.LoadOcDetails();
            var selected = args.Length > 0 ? arg(args,0).Value.Format() : EmptyString;
            var count = details.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];
                if(empty(selected))
                    Write(format(detail));
                else
                {
                    var sig = detail.AsmSig.Format();
                    if(text.contains(sig, selected,false))
                        Write(format(detail));
                }
            }

           return true;
        }

        static string format(in SdmOpCodeDetail src)
            => string.Format("{0,-18} | {1,-32} | {2}\n    {3}",
                    src.Mnemonic,
                    text.trim(src.AsmSig),
                    text.trim(src.OpCodeExpr),
                    text.trim(src.Description)
                    );
    }
}
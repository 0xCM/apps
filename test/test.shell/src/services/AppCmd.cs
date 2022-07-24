//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        [CmdOp("units/run")]
        Outcome RunUnits(CmdArgs args)
        {
            TestRunner.Run(Algs.array(PartId.Lib, PartId.TestUnits));
            return true;
        }


        [CmdOp("ancestors/check")]
        void Ancestors()
        {
            AncestryChecks.create(Wf).Run();
        }

        [CmdOp("bitmasks/check")]
        void Hello()
        {
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = Tables.formatter<BitMaskLiterals>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Write(formatter.Format(mask));
                Write(mask.Text);
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;


    sealed class AppCmd : AppCmdService<AppCmd>
    {
        void CheckHexExec()
        {
            HexCodeRunner.slots(EventLog);
            var runner = new HexCodeRunner(Wf,EventLog);
            runner.RunAlgs();
        }

        void EmitBitMasks()
        {
            var dst = AppDb.App(logs).Path("bitmasks", FileKind.Csv);
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = Tables.formatter<BitMaskInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Row(formatter.Format(mask));
                Write(mask.Text);
            }
            TableEmit(src,dst,TextEncodingKind.Unicode);

        }

        [CmdOp("calcs/check")]
        void Hello()
        {
            CheckHexExec();
        }
    }
}
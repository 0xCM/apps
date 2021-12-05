//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


    using K = GlobalWfCmd;

    public enum GlobalWfCmd : ushort
    {
        None,

        ShowByteConversions,
    }

    public class WfCmdGlobals : AppCmdHost<WfCmdGlobals, GlobalWfCmd>
    {
        [Action(K.ShowByteConversions)]
        void ShowByteConversions()
        {
            const string FormatPattern = "{0,-5} | {1,-5} | {2}";

            var header = string.Format(FormatPattern, "Dec", "Hex", "Bits");
            using var logger = Db.ShowLog(ext:FS.Csv).Writer();
            Wf.Row(header);
            logger.WriteLine(header);
            var options = BitFormatOptions.bitblock(4, Chars.Space);
            for(var i=0; i<= byte.MaxValue; i++)
            {
                byte src = (byte)i;
                var dec = string.Format("{0:D3}", src);
                var bits = src.FormatBits(options);
                var hex = src.FormatHex(specifier:false);
                var row = string.Format(FormatPattern, dec, hex, bits);
                logger.WriteLine(row);
                Wf.Row(row);
            }
        }
    }
}
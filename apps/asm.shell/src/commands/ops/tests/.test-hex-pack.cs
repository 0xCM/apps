//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-hex-pack")]
        unsafe Outcome TestHexPack(CmdArgs args)
        {
            var result = Outcome.Success;
            const string DataSource = "38D10F9FC00FB6C0C338D10F97C00FB6C0C36639D10F9FC00FB6C0C36639D10F97C00FB6C0C339D10F9FC00FB6C0C339D10F97C0C34839D10F9FC00FB6C0C34839D10F97C00FB6C0C3";
            var input = span(DataSource);
            var count = DataSource.Length;
            var dst = alloc<HexDigitValue>(count);
            result = Hex.map(DataSource,dst);
            if(result.Fail)
                return result;

            for(var i=0; i<count; i++)
            {
                if(Hex.upper(skip(dst,i)) != skip(input,i))
                    return (false, "Not Equal");
            }

            var buffer = alloc<byte>(count/2);
            var size = Hex.pack(dst,buffer);
            Write(DataSource);
            Write(buffer.FormatHex(HexFormatSpecs.Compact));

            return result;
        }
    }
}
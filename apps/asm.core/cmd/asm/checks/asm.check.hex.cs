//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/objhex")]
        Outcome CheckObjHex(CmdArgs args)
        {
            var project = Project();
            var context = WsApi.context(project);
            return Coff.CheckObjHex(context);
        }

        [CmdOp("asm/check/hex")]
        unsafe Outcome CheckHexPack(CmdArgs args)
        {
            const string DataSource = "38D10F9FC00FB6C0C338D10F97C00FB6C0C36639D10F9FC00FB6C0C36639D10F97C00FB6C0C339D10F9FC00FB6C0C339D10F97C0C34839D10F9FC00FB6C0C34839D10F97C00FB6C0C3";
            var result = Outcome.Success;
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
            var size = Digital.pack(dst,buffer);
            var output = buffer.FormatHex(HexFormatSpecs.Compact);
            Write(Require.equal(DataSource,output));
            return result;
        }
    }
}
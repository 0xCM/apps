//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using K = BinaryFormatKind;

    public class CodeLoader : AppService<CodeLoader>
    {
        ApiHex ApiHex => Service(Wf.ApiHex);

        ApiHexPacks HexPacks => Service(Wf.ApiHexPacks);

        Outcome FromText(FS.FilePath src, out BinaryCode dst)
            => HexParser.hexbytes(src.ReadAsci(), out dst);

        public BinaryCode Load(FS.FilePath src, BinaryFormatKind format)
        {
            var dst = BinaryCode.Empty;
            var result = Outcome.Success;
            switch(format)
            {
                case K.Raw:
                    dst = src.ReadBytes();
                break;
                case K.Text:
                    result = FromText(src, out dst);
                break;
                case K.Located:
                break;
                case K.Csv:
                break;
            }

            if(result.Fail)
                Write(result.Message);

            return dst;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;
    using F = XedImport.BlockField;

    partial class XedImport
    {
        public static Outcome parse(in InstBlock src, out InstBlockImport dst)
        {
            dst = InstBlockImport.Empty;
            var result = true;
            try
            {
                dst.Seq = src.Seq;
                dst.Form = src.Form;
                result |= InstParser.parse(src[F.pattern], out dst.Pattern);
                result |= XedParsers.parse(src[F.iclass], out dst.Class);
            }
            catch(Exception e)
            {
                return (false, e.Message);
            }
            return result;
        }
    }
}
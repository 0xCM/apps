//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    public partial class XedOpCodes : AppService<XedOpCodes>
    {
        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public static Index<PatternOpCode> poc(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                poc(src[i], out seek(buffer,i));

            buffer.Sort();
            for(var i=0u; i<count; i++)
                seek(buffer,i).Seq = i;

            return buffer;
        }

        public static void poc(InstPattern src, out PatternOpCode dst)
        {
            dst.Seq = 0;
            dst.PatternId = src.PatternId;
            dst.InstId = src.InstId;
            dst.OcKind = src.OpCode.Kind;
            dst.OcValue = src.OpCode.Value;
            dst.InstClass = src.InstClass;
            dst.Mode = XedFields.mode(src.Fields);
            dst.Layout = src.Layout.Delimit(Chars.Space).Format();
            dst.Expr = src.Expr.Delimit(Chars.Space).Format();
        }

        public static Index<XedOpCode> opcodes(Index<InstPattern> src)
            => src.Map(x => x.Spec.OpCode).Sort();
    }
}
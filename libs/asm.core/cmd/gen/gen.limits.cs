//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/limits")]
        Outcome XedCheck(CmdArgs args)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = CsLang.emitter();
            var offset = 0u;
            emitter.OpenNamespace(offset, "Z0");
            offset+=4;
            emitter.LiteralProvider(offset);
            emitter.OpenStruct(offset, "Limit");
            offset+=4;
            for(var i=1; i<=64; i++)
            {
                emitter.SummaryComment(offset, string.Format(CommentPattern, i, max));
                max = Numbers.max((byte)i);
                if(i <= 8)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (byte)max);
                else if(i <= 16)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ushort)max);
                else if(i <= 32)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (uint)max);
                else if(i <= 64)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ulong)max);
                emitter.AppendLine();
            }
            offset-=4;
            emitter.CloseStruct(offset);
            offset-=4;
            emitter.CloseNamespace(offset);

            FileEmit(emitter.Emit(), AppDb.CgStage().Path("limit", FileKind.Cs));

            return true;
        }
    }
}
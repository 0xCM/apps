//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDb
    {
        public void EmitLocatedFields(RuleCells src)
        {
            const string HeaderPattern = "{0,-6} | {1,-18} | {2,-4} | {3,-26}";
            var located = CalcLocatedFields(src);
            var header = string.Format(HeaderPattern, "Seq", "Point",  "Code", "Field");
            var emitter = text.emitter();
            emitter.AppendLine(header);
            for(var i=0;i<located.Length; i++)
                emitter.AppendLineFormat("{0,-6} | {1}", i, located[i].Format());
            FileEmit(emitter.Emit(), located.Length, Paths.DbTarget("rules.fields.points", FileKind.Csv), TextEncodingKind.Asci);
        }
    }
}
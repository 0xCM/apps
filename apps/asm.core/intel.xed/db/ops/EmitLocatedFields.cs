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
            var located = CalcLocatedFields(src);
            var emitter = text.emitter();
            for(var i=0;i<located.Length; i++)
                emitter.AppendLineFormat("{0,-6} | {1}", i, located[i].Format());
            FileEmit(emitter.Emit(), located.Length, Paths.DbTarget("rules.fields.points", FileKind.Csv), TextEncodingKind.Asci);
        }
    }
}
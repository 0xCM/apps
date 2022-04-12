//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules.TableCalcs;

    partial class XedRules
    {
        public RuleTables CalcRules()
        {
            var tables = new RuleTables();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => buffers.Specs.TryAdd(RuleTableKind.Enc, criteria(RuleTableKind.Enc)),
                () => buffers.Specs.TryAdd(RuleTableKind.Dec, criteria(RuleTableKind.Dec))
                );

            return tables.Seal(buffers, PllExec);
        }
   }
}
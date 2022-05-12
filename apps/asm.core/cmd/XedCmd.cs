// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class AsmCoreCmd
    {
        XedRuntime Xed;

        XedDocs XedDocs => Xed.Docs;

        XedPaths XedPaths => Xed.Paths;

        XedRules Rules => Xed.Rules;

        XedDisasmSvc Disasm => Xed.XedDisasm;

        XedDb XedDb => Xed.XedDb;

        [MethodImpl(Inline)]
        StringRef Ref(string src)
            => Xed.Alloc.String(src);

        [MethodImpl(Inline)]
        Label Label(string src)
            => Xed.Alloc.Label(src);

        ref readonly RuleTables RuleTables
            => ref Xed.Views.RuleTables;

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        ref readonly CellTables CellTables
            => ref Xed.Views.CellTables;

        ref readonly Index<RuleExpr> RuleExpr
            => ref Xed.Views.RuleExpr;

        public AsmCoreCmd With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }
    }
}
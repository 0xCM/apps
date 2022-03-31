//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public readonly struct NontermLocator
        {
            public static FS.FileName filename(NontermLocator locator)
                => FS.file(string.Format("{0}.{1}", XedRender.format(locator.Nonterm), XedRender.format(locator.TableKind)), FS.Csv);

            public readonly RuleTableKind TableKind;

            public readonly Nonterminal Nonterm;

            [MethodImpl(Inline)]
            public NontermLocator(RuleTableKind tk, Nonterminal ntk)
            {
                TableKind = tk;
                Nonterm = ntk;
            }

            public FS.FileName FileName
            {
                [MethodImpl(Inline)]
                get => filename(this);
            }
        }
    }
}
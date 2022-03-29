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
                => FS.file(string.Format("{0}.{1}", XedRender.format(locator.NontermKind), XedRender.format(locator.TableKind)), FS.Csv);

            public readonly RuleTableKind TableKind;

            public readonly NontermKind NontermKind;

            [MethodImpl(Inline)]
            public NontermLocator(RuleTableKind tk, NontermKind ntk)
            {
                TableKind = tk;
                NontermKind = ntk;
            }

            public FS.FileName FileName
            {
                [MethodImpl(Inline)]
                get => filename(this);
            }
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public sealed class Grammar : Grammar<Grammar,AsciCharSym,GrammarRule>
    {
        public Grammar(Label name)
            : base(name, lang.alphabet<AsciCharSym>())
        {

        }
    }
}
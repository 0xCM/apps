//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolChecks : Checker<SymbolChecks>
    {
        public Outcome CheckSymNames()
        {
            var result = Outcome.Success;
            var classifier = Classifiers.classifier<AsciLetterLoSym,byte>();
            var symbols = Symbols.index<AsciLetterLoSym>();
            var classes = classifier.Classes;
            var count = classes.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var c = ref skip(classes,i);
                ref readonly var s = ref symbols[i];
                Z0.Require.equal(c.Ordinal, i);
                Z0.Require.equal(s.Key.Value, c.Ordinal);
                Z0.Require.equal(s.Expr.Format(), c.Symbol.Format());
                Z0.Require.equal(s.Name, c.KindName.Format());
            }

            return result;
        }
    }
}
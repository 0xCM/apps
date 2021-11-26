//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class SymbolChecks : Checker<SymbolChecks>
    {
        public Outcome TestSymNames()
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
                Require.equal(c.Ordinal, i);
                Require.equal(s.Key.Value, c.Ordinal);
                Require.equal(s.Expr.Format(), c.Symbol.Format());
                Require.equal(s.Name.Format(), c.KindName.Format());
                Write(string.Format("{0,-8:D3} {1,-24} {2,-8} {3}", c.Ordinal, c.ClassName, c.KindName, c.Value));
            }

            return result;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        public readonly struct Except : IExprDeprecated
        {
            HashSet<IExprDeprecated> _Terms {get;}

            [MethodImpl(Inline)]
            public Except(IExprDeprecated[] choices)
                => _Terms = core.hashset(choices);

            public IReadOnlyCollection<IExprDeprecated> Terms
            {
                [MethodImpl(Inline)]
                get => _Terms;
            }

            public Label Name => "exclude";

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        public readonly struct Sum : ILogicOp
        {
            public Index<IExprDeprecated> Members {get;}

            [MethodImpl(Inline)]
            public Sum(Index<IExprDeprecated> members)
                => Members = members;

            public uint N
            {
                [MethodImpl(Inline)]
                get => Members.Count;
            }

            public NameOld OpName => "sum";

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();
        }
    }
}
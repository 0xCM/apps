//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct CountRule
        {
            public Label Name {get;}

            public Count Value {get;}

            [MethodImpl(Inline)]
            public CountRule(Label name, Count value)
            {
                Name = name;
                Value = value;
            }

            public string Format()
                => string.Format("{0}:{1}", Name,Value);

            public override string ToString()
                => Format();
        }
    }
}
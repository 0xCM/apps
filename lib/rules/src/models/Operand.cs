//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Defines an operand value of dynamic type
        /// </summary>
        public readonly struct Operand
        {
            public Label Name {get;}

            public dynamic Value {get;}

            [MethodImpl(Inline)]
            public Operand(Label name, dynamic value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
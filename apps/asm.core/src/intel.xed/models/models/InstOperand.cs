//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public struct InstOperand
        {
            public byte Index;

            public OperandKind Kind;

            public OperandAction Action;

            public OperandVisibility Visiblity;

            public LookupKind Lookup;

            public string Prop1;

            public string Prop2;
        }
    }
}
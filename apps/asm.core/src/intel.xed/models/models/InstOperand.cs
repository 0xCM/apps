//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct InstOperand
        {
            public byte Index;

            public OperandKind Kind;

            public OperandAction Action;

            public OperandVisibility Visiblity;

            public OperandWidthType WidthType;

            public string Prop2;

            public LookupKind Lookup;
        }
    }
}
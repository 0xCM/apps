//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct FormOperands : IRecord<FormOperands>
        {
            public const string TableId = "xed.form-operands";

            public ushort Index;

            public IForm Form;

            public DelimitedIndex<string> Specifiers;

            public static ReadOnlySpan<byte> RenderWidths => new byte[]{8,64,64};
        }
    }
}
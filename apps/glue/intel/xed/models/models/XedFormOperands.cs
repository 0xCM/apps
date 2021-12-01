//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedFormOperands : IRecord<XedFormOperands>
    {
        public const string TableId = "xed.iform.operands";

        public ushort Index;

        public XedIForm Form;

        public DelimitedIndex<string> Specifiers;

        public static ReadOnlySpan<byte> RenderWidths => new byte[]{8,64,64};
    }
}
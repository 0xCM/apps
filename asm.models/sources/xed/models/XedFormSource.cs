//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines a structure that reflects the content of the xed "idata.txt" file
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedFormSource : IRecord<XedFormSource>
    {
        public const string TableId = "xed.idata";

        public const byte FieldCount = 6;

        public string Class;

        public string Extension;

        public string Category;

        public string Form;

        public string IsaSet;

        public string Attributes;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,24,80,24,120};
    }
}
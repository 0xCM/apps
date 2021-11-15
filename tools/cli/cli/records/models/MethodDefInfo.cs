//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MethodDefInfo : IRecord<MethodDefInfo>
    {
        public const string TableId = "image.methods";

        public const byte FieldCount = 7;

        public string Component;

        public CliToken Token;

        public string Name;

        public Address32 Rva;

        public CliSig CliSig;

        public MethodImplAttributes ImplAttributes;

        public MethodAttributes Attributes;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,48,16,56,24,24};
    }
}
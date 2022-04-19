//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Characterizes a compile-time literal value
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct CompilationLiteral : IRecord<CompilationLiteral>
    {
        public const string TableId = "api.literals";

        public const byte FieldCount = 5;

        public string Source;

        public string Name;

        public string Kind;

        public uint Length;

        public RuntimeLiteralValue<string> Value;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{32,32,12,12,1};
    }
}
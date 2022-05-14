//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a compile-time literal value
    /// </summary>
    [StructLayout(StructLayout, Pack=1), Record(TableId)]
    public struct CompilationLiteral : IRecord<CompilationLiteral>
    {
        public const string TableId = "api.literals";

        public const byte FieldCount = 5;

        [Render(32)]
        public string Source;

        [Render(32)]
        public string Name;

        [Render(12)]
        public string Kind;

        [Render(12)]
        public uint Length;

        [Render(1)]
        public RuntimeLiteralValue<string> Value;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{32,32,12,12,1};
    }
}
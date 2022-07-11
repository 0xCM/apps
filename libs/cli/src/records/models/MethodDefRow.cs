//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct MethodDefRow
        {
            const string TableId = "method.defs";

            [Render(12)]
            public CliToken Token;

            [Render(12)]
            public Address32 Rva;

            [Render(12)]
            public CliStringIndex Name;

            [Render(12)]
            public CliBlobIndex Sig;

            [Render(12)]
            public CliRowKey FirstParam;

            [Render(12)]
            public ushort ParamCount;

            [Render(32)]
            public MethodImplAttributes ImplAttributes;

            [Render(1)]
            public MethodAttributes Attributes;
        }
    }
}
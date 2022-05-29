//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.MethodDef), StructLayout(LayoutKind.Sequential)]
        public struct MethodDefRow : ICliRecord<MethodDefRow>
        {
            public CliToken Key;

            public Address32 Rva;

            public MethodImplAttributes ImplAttributes;

            public MethodAttributes Attributes;

            public CliStringIndex Name;

            public CliBlobIndex Signature;

            public CliRowKey FirstParam;

            public ushort ParamCount;
        }
    }
}
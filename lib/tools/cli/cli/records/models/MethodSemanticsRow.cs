//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;

    partial struct CliRows
    {
        [CliRecord(CliTableKind.MethodSemantics), StructLayout(LayoutKind.Sequential)]
        public struct MethodSemanticsRow : ICliRecord<MethodSemanticsRow>
        {
            public MethodSemanticsAttributes Semantic;

            public CliRowKey Method;

            public CliRowKey Association;
        }
    }
}
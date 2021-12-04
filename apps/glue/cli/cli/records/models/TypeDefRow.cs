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
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct TypeDefRow : ICliRecord<TypeDefRow>
        {
            public const string TableId = "cli.metadata.typedefs";

            public TypeAttributes Attributes;

            public CliStringIndex Name;

            public CliStringIndex Namespace;

            public TypeLayout Layout;

            public int Extends;

            public int FieldList;

            public int MethodList;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct RecordField
    {
        public const string TableId = "llvm.fields";

        public const byte FieldCount = 4;

        /// <summary>
        /// The name of the declaring record
        /// </summary>
        public Identifier RecordName;

        /// <summary>
        /// The field data type
        /// </summary>
        public string DataType;

        /// <summary>
        /// The field name
        /// </summary>
        public string Name;

        /// <summary>
        /// The field value
        /// </summary>
        public string Value;

        [MethodImpl(Inline)]
        public RecordField(Identifier record, string type, string name, string value)
        {
            RecordName = record;
            DataType = type;
            Name = name;
            Value = value;
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{64,32,32,3};

        public static RecordField Empty => new RecordField(Identifier.Empty, EmptyString, EmptyString, EmptyString);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.records
{
    using System;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct RecordField
    {
        public const string TableId = "llvm.fields";

        public const byte FieldCount = 4;

        public const string RowFormat = "{0,-64} | {1,-32} | {2,-32} | {3}";

        public static string RowHeader
            => string.Format(RowFormat, nameof(RecordName), nameof(DataType), nameof(Name), nameof(Value));

        /// <summary>
        /// The name of the declaring record
        /// </summary>
        public Identifier RecordName;

        public string DataType;

        public string Name;

        public string Value;

        public RecordField(Identifier record, string type, string name, string value)
        {
            RecordName = record;
            DataType = type;
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0}.{1}:{2} = {3}", RecordName, Name, DataType, Value);

        public override string ToString()
            => Format();

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{64,32,32,3};

        public static RecordField Empty => new RecordField(Identifier.Empty, EmptyString, EmptyString, EmptyString);
    }
}
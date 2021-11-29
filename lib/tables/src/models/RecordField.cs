//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Describes a column in a table
    /// </summary>
    public readonly struct RecordField
    {
        /// <summary>
        /// The 0-based, declaration order of the field
        /// </summary>
        public ushort FieldIndex {get;}

        /// <summary>
        /// The defining field
        /// </summary>
        public FieldInfo Definition {get;}

        readonly string _Name;

        [MethodImpl(Inline)]
        public RecordField(ushort index, FieldInfo def, string name)
        {
            FieldIndex = index;
            Definition = def;
            _Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Definition != null;
        }

        /// <summary>
        /// The field name
        /// </summary>
        public string Name
        {
            [MethodImpl(Inline)]
            get => _Name ?? EmptyString;
        }

        /// <summary>
        /// The field datatype
        /// </summary>
        public Type DataType
        {
            [MethodImpl(Inline)]
            get => Definition?.FieldType ?? typeof(void);
        }

        public string Format()
            => string.Format("{0:D2} {1}", FieldIndex, Name);

        public override string ToString()
            => Format();
    }
}
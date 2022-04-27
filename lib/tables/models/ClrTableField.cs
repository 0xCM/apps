//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a column in a table
    /// </summary>
    public readonly struct ClrTableField
    {
        /// <summary>
        /// The 0-based, declaration order of the field
        /// </summary>
        public readonly ushort FieldIndex;

        /// <summary>
        /// The defining field
        /// </summary>
        public readonly FieldInfo Definition;

        /// <summary>
        /// The external field name
        /// </summary>
        public readonly Name FieldName;

        [MethodImpl(Inline)]
        public ClrTableField(ushort index, FieldInfo def)
        {
            FieldIndex = index;
            Definition = def;
            FieldName = Tables.name(def);
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
        /// The member field name
        /// </summary>
        public Name MemberName
        {
            [MethodImpl(Inline)]
            get => IsNonEmpty ? Definition.Name : Name.Empty;
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
            => string.Format("{0:D2} {1}", FieldIndex, FieldName);

        public override string ToString()
            => Format();
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct ApiDataType : IComparable<ApiDataType>
    {
        public const string TableId = "api.datatype";

        public const byte FieldCount = 6;

        public Identifier Name;

        public @string Specifier;

        public bool Parametric;

        public object Kind;

        public BitWidth ContentWidth;

        public BitWidth StorageWidth;

        [MethodImpl(Inline)]
        public ApiDataType(Identifier name, @string syntax, bool parametric, object kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Specifier = syntax;
            Parametric = parametric;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public int CompareTo(ApiDataType src)
            => Name.CompareTo(src.Name);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,32,12,12,12,12};

    }
}
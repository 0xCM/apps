//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a numeric literal relative to a specified base
    /// </summary>
    public readonly struct NumericLiteral : INumericLiteral<NumericLiteral>
    {
        public string Name {get;}

        public object Data {get;}

        public string Text {get;}

        public NumericBaseKind Base {get;}

        [MethodImpl(Inline)]
        public NumericLiteral(string name, object data, string text, NumericBaseKind @base)
        {
            Name = name;
            Data = data ?? 0;
            Text = text ?? Data.ToString();
            Base = @base;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => blank(Text);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasValue
        {
            [MethodImpl(Inline)]
            get => Data != null && Data.GetType() != typeof(string);
        }

        public Type SystemType
        {
            [MethodImpl(Inline)]
            get => Data.GetType();
        }

        public TypeCode TypeCode
        {
            [MethodImpl(Inline)]
            get => Type.GetTypeCode(SystemType);
        }

        public NumericLiteral Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public bool IsEnum
        {
            [MethodImpl(Inline)]
            get => SystemType.IsEnum;
        }
        public string Format()
            => Text;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(NumericLiteral src)
            => object.Equals(Data, src.Data);

        string ILiteral.Name
            => Name;

        object ILiteral.Data
            => Data;

        string ILiteral.Text
            => Text;

       public static NumericLiteral Empty
            => new NumericLiteral(EmptyString, EmptyString, EmptyString, 0);
    }
}
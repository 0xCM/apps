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
    /// Covers a value that can be interpreted as a compile-time literal constant
    /// </summary>
    public readonly struct LiteralInfo : ILiteral<LiteralInfo>
    {
        public string Name {get;}

        public object Data {get;}

        public string Text {get;}

        public TypeCode TypeCode {get;}

        public bool IsEnum {get;}

        public bool Polymorphic {get;}

        [MethodImpl(Inline)]
        public LiteralInfo(string name, object data, string text, TypeCode tc, bool isEnum, bool polymorphic)
        {
            Name = name;
            Data = data;
            Text = text;
            TypeCode = tc;
            IsEnum = isEnum;
            Polymorphic = polymorphic;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == null || empty(Text);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public LiteralInfo Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        public bool IsAnonymous
        {
            [MethodImpl(Inline)]
            get => blank(Name);
        }

        public Type SystemType
        {
            [MethodImpl(Inline)]
            get => Data?.GetType() ?? typeof(void);
        }

        [MethodImpl(Inline)]
        public bool Equals(LiteralInfo src)
            => object.Equals(Data, src.Data);

        [MethodImpl(Inline)]
        public string Format()
            => Data?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data?.GetHashCode() ?? 0;

        public override bool Equals(object src)
            => src is LiteralInfo v && Equals(v);

        public static LiteralInfo Empty
            => new LiteralInfo(EmptyString, EmptyString, EmptyString, 0, false, false);
    }
}
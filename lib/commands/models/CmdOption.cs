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

    public readonly struct CmdOption
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public CmdOption(string name, string value)
        {
            Data = string.Concat(name,Chars.Colon,value);
        }

        [MethodImpl(Inline)]
        public CmdOption(string data)
        {
            Data = data;
        }

        string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public string Name
            => name(Content);

        public string Value
            => value(Content);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        public bool HasName
        {
            [MethodImpl(Inline)]
            get => empty(Name);
        }

        public string Format()
            => HasName ? string.Format("{0}:{1}", Name,Value) : Value;

        public override string ToString()
            => Format();

        public static CmdOption Empty
        {
            [MethodImpl(Inline)]
            get => new CmdOption(EmptyString);
        }

        [MethodImpl(Inline)]
        static string value(string src)
        {
            if(empty(src))
                return EmptyString;

            var i = text.index(src,Chars.Colon);
            return i > 0 ? text.right(src,i) : src;
        }

        [MethodImpl(Inline)]
        static string name(string src)
        {
            if(empty(src))
                return EmptyString;

            var i = text.index(src,Chars.Colon);
            return i > 0 ? text.left(src,i) : EmptyString;
        }
    }
}
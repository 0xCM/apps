//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ScriptPattern<K> : ITypedIdentity<K>
        where K : unmanaged
    {
        public K Id {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public ScriptPattern(string content)
        {
            Id = default;
            Content = content;
        }

        [MethodImpl(Inline)]
        public ScriptPattern(K id, string content)
        {
            Id = id;
            Content = content;
        }

        public override string ToString()
            => Content ?? EmptyString;

        public override int GetHashCode()
            => Content?.GetHashCode() ?? 0;

        public bool Equals(ScriptPattern<K> src)
            => string.Equals(Content, src.Content, NoCase);

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern<K>(string src)
            => new ScriptPattern<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ScriptPattern<K> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern(ScriptPattern<K> src)
            => new ScriptPattern(src.Id.ToString(), src.Content);

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern<K>(Paired<K,string> src)
            => new ScriptPattern<K>(src.Left, src.Right);
    }
}
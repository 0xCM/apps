//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ScriptPattern
    {
        public string PatternId {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public ScriptPattern(string content)
        {
            PatternId = EmptyString;
            Content = content;
        }

        [MethodImpl(Inline)]
        public ScriptPattern(string id, string content)
        {
            PatternId = id;
            Content = content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.blank(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !core.blank(Content);
        }

        public override string ToString()
            => Content;

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern(string src)
            => new ScriptPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ScriptPattern src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ScriptPattern(Pair<string> src)
            => new ScriptPattern(src.Left, src.Right);

        public static ScriptPattern Empty
            => new ScriptPattern(EmptyString, EmptyString);
    }
}
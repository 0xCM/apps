//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScriptPattern
    {
        public string PatternId {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public CmdScriptPattern(string content)
        {
            PatternId = EmptyString;
            Content = content;
        }

        [MethodImpl(Inline)]
        public CmdScriptPattern(string id, string content)
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
        public static implicit operator CmdScriptPattern(string src)
            => new CmdScriptPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdScriptPattern src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(Pair<string> src)
            => new CmdScriptPattern(src.Left, src.Right);

        public static CmdScriptPattern Empty
            => new CmdScriptPattern(EmptyString, EmptyString);
    }
}
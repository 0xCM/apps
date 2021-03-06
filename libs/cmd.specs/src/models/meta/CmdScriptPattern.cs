//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdScriptPattern : TextTemplate
    {
        public NameOld Name {get;}

        [MethodImpl(Inline)]
        public CmdScriptPattern(TextBlock pattern)
            : base(pattern)
        {
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdScriptPattern(string name, TextBlock pattern)
            : base(pattern)
        {
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(string src)
            => new CmdScriptPattern(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(Pair<string> src)
            => new CmdScriptPattern(src.Left, src.Right);

        public static CmdScriptPattern Empty
            => new CmdScriptPattern(EmptyString, EmptyString);
    }
}
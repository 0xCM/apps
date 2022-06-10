//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CmdSpec
    {
        [Op, MethodImpl(Inline)]
        public static CmdSpec from(string name, CmdArgs args)
            => new CmdSpec(name, args);

        [Op]
        public static CmdSpec from(ReadOnlySpan<char> src)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                return new CmdSpec(text.format(src), CmdArgs.Empty);
            else
            {
                var name = text.format(text.left(src,i));
                var _args = text.format(text.right(src,i)).Split(Chars.Space);
                return new CmdSpec(name, CmdArgs.args(_args));
            }
        }

        public string Name {get;}

        public CmdArgs Args {get;}

        [MethodImpl(Inline)]
        public CmdSpec(string name, CmdArgs args)
        {
            Name = name;
            Args = args;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Name);
        }

        public string Format()
            => Cmd.format(this);

        public static CmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new CmdSpec(default, CmdArgs.Empty);
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdSpec((string name, CmdArgs args) src)
            => new CmdSpec(src.name, src.args);
    }
}
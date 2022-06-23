//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = ShellCmd;

    public readonly struct ShellCmdSpec
    {
        public readonly string Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ShellCmdSpec(string name, CmdArgs args)
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
            => api.format(this);

        public override string ToString()
            => Format();

        public static ShellCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ShellCmdSpec(default, CmdArgs.Empty);
        }

        [MethodImpl(Inline)]
        public static implicit operator ShellCmdSpec((string name, CmdArgs args) src)
            => new ShellCmdSpec(src.name, src.args);
    }
}
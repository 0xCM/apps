//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = ShellCmd;

    public record class ShellCmdSpec
    {
        public readonly asci32 Name;

        public readonly CmdArgs Args;

        [MethodImpl(Inline)]
        public ShellCmdSpec(asci32 name, CmdArgs args)
        {
            Name = name;
            Args = args;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ShellCmdSpec((string name, CmdArgs args) src)
            => new ShellCmdSpec(src.name, src.args);

        public static ShellCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ShellCmdSpec(default, CmdArgs.Empty);
        }
    }
}
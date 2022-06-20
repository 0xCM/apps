//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = CmdSpecs;

    public readonly struct CmdSpec
    {
        public readonly string Name;

        public readonly CmdArgs Args;

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
            => api.format(this);

        public override string ToString()
            => Format();

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
//-----------------------------------------------------------------------------
// Copyright   : (c) Chris Moore, 2020
// License     : MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdJob
    {
        public readonly NameOld Name;

        public readonly TextBlock Spec;

        [MethodImpl(Inline)]
        public CmdJob(NameOld name, TextBlock spec)
        {
            Name = name;
            Spec = spec;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Spec;

        public override string ToString()
            => Format();
    }
}
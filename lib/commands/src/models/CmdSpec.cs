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

    public readonly struct CmdSpec
    {
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
        {
            if(IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(Name);
            var count = Args.Length;
            for(ushort i=0; i<count; i++)
            {
                ref readonly var arg = ref Args[i];
                if(nonempty(arg.Name))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Name);
                }

                if(nonempty(arg.Value))
                {
                    dst.Append(Chars.Space);
                    dst.Append(arg.Value);
                }
            }
            return dst.Emit();
        }

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
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdOp
    {
        readonly AsciBlock32 _Name;

        public CliToken MethodId {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public CmdOp(string name, CliToken method)
        {
            AsciBlocks.encode(name, out _Name);
            MethodId = method;
            Hash = alg.hash.calc(_Name.Bytes);
        }

        [MethodImpl(Inline)]
        public CmdOp(string name, MethodInfo method)
        {
            AsciBlocks.encode(name, out _Name);
            MethodId = method;
            Hash = alg.hash.calc(_Name.Bytes);
        }

        public ReadOnlySpan<char> Name
        {
            [MethodImpl(Inline)]
            get => AsciBlocks.decode(_Name);
        }

        public string Format()
            => text.format(Name);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public static implicit operator CmdOp((string name, MethodInfo method) src)
            => new CmdOp(src.name, src.method);
    }
}
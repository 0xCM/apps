//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdOp
    {
        readonly AsciBlock32 _Name;

        public readonly CliToken MethodId;

        public readonly uint Hash;

        [MethodImpl(Inline)]
        public CmdOp(string name, CliToken method)
        {
            AsciBlocks.encode(name, out _Name);
            MethodId = method;
            Hash = alg.ghash.calc(_Name.Bytes);
        }

        [MethodImpl(Inline)]
        public CmdOp(string name, MethodInfo method)
        {
            AsciBlocks.encode(name, out _Name);
            MethodId = method;
            Hash = alg.ghash.calc(_Name.Bytes);
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
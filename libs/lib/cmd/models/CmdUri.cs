//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdUri
    {
        [MethodImpl(Inline)]
        public static CmdUri define(asci32 part, asci32 host, Name name)
            => new CmdUri(part,host,name);

        public readonly asci32 Part;

        public readonly asci32 Host;

        public readonly Name Name;

        [MethodImpl(Inline)]
        internal CmdUri(asci32 part, asci32 host, Name name)
        {
            Part = part;
            Host = host;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Part.IsEmpty && Host.IsEmpty && Name.IsEmpty;
        }

        public string Format()
            => $"cmd://{Part}/{Host}?name={Name}";

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
           get => Part.Hash | Host.Hash | Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();
    }
}
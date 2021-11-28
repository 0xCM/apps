//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdInfo<K>
        where K : unmanaged
    {
        public K Id {get;}

        public CharBlock16 Name {get;}

        public CharBlock32 Description {get;}

        [MethodImpl(Inline)]
        public CmdInfo(K id, in CharBlock16 name, in CharBlock32 desc)
        {
            Id = id;
            Name = name;
            Description = desc;
        }
    }
}
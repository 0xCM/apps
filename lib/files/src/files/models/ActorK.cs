//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public class Actor<K> : Actor<K,ObjectType,ObjectType>
            where K : unmanaged
        {
            public Actor(Name name, K modifier, ObjectType src, ObjectType dst)
                : base(name,modifier)
            {

            }

            public override ObjectType Source {get;}

            public override ObjectType Target {get;}
        }
    }
}
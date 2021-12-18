//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public class Actor : Actor<ObjectType,ObjectType>
        {
            public Actor(Name name, ObjectType src, ObjectType dst)
                : base(name)
            {
                Source = src;
                Target = dst;
            }

            public override ObjectType Source {get;}

            public override ObjectType Target {get;}
        }
    }
}
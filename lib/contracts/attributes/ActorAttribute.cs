//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple =true)]
    public class ActorAttribute : Attribute
    {
        public ActorAttribute()
        {
            ActorType = typeof(void);
            SourceType = typeof(void);
            TargetType = typeof(void);

        }
        public ActorAttribute(Type actor)
        {
            ActorType = actor;
            SourceType = typeof(void);
            TargetType = typeof(void);
        }

        public ActorAttribute(Type actor, Type src, Type dst)
        {
            ActorType = actor;
            SourceType = src;
            TargetType = dst;
        }

        public Type ActorType {get;}

        public Type SourceType {get;}

        public Type TargetType {get;}
    }
}
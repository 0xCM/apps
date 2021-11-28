//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WfHost : IWfHost<WfHost>
    {
        public WfStepId StepId {get;}

        public Type Type {get;}

        public string Name {get;}

        [MethodImpl(Inline)]
        public WfHost(WfStepId id, Type type)
        {
            StepId =id;
            Type = type;
            Name = type.Name;
        }

        public string Identifier
        {
            [MethodImpl(Inline)]
            get => Type.Name;
        }

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(WfHost src)
            => src.StepId;

        [MethodImpl(Inline)]
        public static implicit operator WfHost(Type src)
            => new WfHost(src,src);
    }
}
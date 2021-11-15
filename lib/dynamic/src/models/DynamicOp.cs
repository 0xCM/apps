//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DynamicOp
    {
        public Type DelegateType {get;}

        public DynamicMethod Definition {get;}

        public Delegate Delegate {get;}

        [MethodImpl(Inline)]
        public DynamicOp(DynamicMethod src, Delegate del, Type type)
        {
            DelegateType = type;
            Definition = src;
            Delegate = del;
        }
    }
}
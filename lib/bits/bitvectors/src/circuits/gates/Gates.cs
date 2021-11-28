//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class LegacyCircuits
    {
        public static class Gates
        {
            [MethodImpl(Inline)]
            public static AndGate and()
                => default(AndGate);

            [MethodImpl(Inline)]
            public static XOrGate xor()
                => default(XOrGate);

            [MethodImpl(Inline)]
            public static AndGate<T> and<T>()
                where T : unmanaged
                    => default(AndGate<T>);

            [MethodImpl(Inline)]
            public static OrGate<T> or<T>()
                where T : unmanaged
                    => default(OrGate<T>);

            [MethodImpl(Inline)]
            public static XOrGate<T> xor<T>()
                where T : unmanaged
                    => default(XOrGate<T>);

            [MethodImpl(Inline)]
            public static NotGate<T> not<T>()
                where T : unmanaged
                    => default(NotGate<T>);

            [MethodImpl(Inline)]
            public static NandGate<T> nand<T>()
                where T : unmanaged
                    => default(NandGate<T>);

            [MethodImpl(Inline)]
            public static NorGate<T> nor<T>()
                where T : unmanaged
                    => default(NorGate<T>);

            [MethodImpl(Inline)]
            public static XnorGate<T> xnor<T>()
                where T : unmanaged
                    => default(XnorGate<T>);

            [MethodImpl(Inline)]
            public static MuxGate<T> mux<T>()
                where T : unmanaged
                    => default(MuxGate<T>);
        }
    }
}
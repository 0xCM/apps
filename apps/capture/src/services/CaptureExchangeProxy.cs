//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CaptureExchangeProxy : ICaptureExchange
    {
        /// <summary>
        /// The buffer that receives the captured data
        /// </summary>
        public BufferToken TargetBuffer {get;}

        [MethodImpl(Inline)]
        internal CaptureExchangeProxy(BufferToken target)
        {
            TargetBuffer = target;
        }

        public CaptureExchange Context
        {
            [MethodImpl(Inline)]
            get => new CaptureExchange(memory.span(TargetBuffer));
        }
    }
}
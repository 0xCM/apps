//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a method entry point
    /// </summary>
    public readonly struct MethodEntryPoint
    {
        public MemoryAddress Location {get;}

        public OpUri Uri {get;}

        public MethodDisplaySig Sig {get;}

        [MethodImpl(Inline)]
        public MethodEntryPoint(OpUri uri, MethodDisplaySig sig, MemoryAddress address)
        {
            Uri = uri;
            Sig = sig;
            Location = address;
        }
    }
}
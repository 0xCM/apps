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
        public readonly MemoryAddress Location;

        public readonly OpUri Uri {get;}

        public readonly MethodDisplaySig Sig;

        [MethodImpl(Inline)]
        public MethodEntryPoint(MemoryAddress address, OpUri uri, MethodDisplaySig sig)
        {
            Location = address;
            Uri = uri;
            Sig = sig;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Location == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Location != 0;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiOpaqueClass;

    partial struct proxy
    {
        public static Process CurrentProcess
        {
            [MethodImpl(Options), Opaque(GetCurrentProcess)]
            get => Process.GetCurrentProcess();
        }
    }
}
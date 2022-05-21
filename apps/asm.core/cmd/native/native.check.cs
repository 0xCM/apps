//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("native/check")]
        Outcome CheckNativeTypes(CmdArgs args)
        {
            try
            {
                RunNativeChecks();
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        void RunNativeChecks()
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());

            CheckNativeAlloc();
        }


        void CheckNativeAlloc()
        {
            var n = n16;
            var count = Numbers.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = PolyBits.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }
        }
    }
}
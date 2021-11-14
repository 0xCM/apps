//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmInstructions;

    partial class AsmCaseArchive
    {
        [MethodImpl(Inline)]
        public static SyntaxFragment<T> line<T>(GridPoint<uint> location, T content)
            where T : ISyntaxPart<T>
                => new SyntaxFragment<T>(location, content);
        [Op]
        public static Index<CallRel32Case> loadRel32(Call_near call)
        {
            var caller = asm.caller(0x7ffe6818a0e0ul, "canonical/abi2/Run");
            var cases = alloc<CallRel32Case>(4);
            var buffer = span(cases);
            var index = 0u;
            var location = GridPoint.Zero;

            var l0 = line(location++, asm.comment("7ffe6818a108h 0028h call 7ffe65135260h | E8 cd | e8 53 b1 fa fc"));
            load(caller, 0x7ffe6818a108, 0x7ffe6818a10d, 0x7ffe65135260, "e8 53 b1 fa fc", l0, ref seek(buffer, index++));
            var l1 = line(location++, asm.comment("7ffe6818a120h 0040h call 7ffe65135268h | E8 cd | e8 43 b1 fa fc"));
            load(caller, 0x7ffe6818a120, 0x7ffe6818a125, 0x7ffe65135268, "e8 43 b1 fa fc", l1, ref seek(buffer, index++));
            var l2 = line(location++, asm.comment("7ffe6818a13bh 005bh call 7ffe65135270h | E8 cd |  e8 30 b1 fa fc"));
            load(caller, 0x7ffe6818a13b, 0x7ffe6818a140, 0x7ffe65135270, "e8 30 b1 fa fc", l2, ref seek(buffer, index++));
            var l3 = line(location++, asm.comment("7ffe6818a154h 0074h call 7ffe65135278h | E8 cd | e8 1f b1 fa fc"));
            load(caller, 0x7ffe6818a154, 0x7ffe6818a159, 0x7ffe65135278, "e8 1f b1 fa fc", l3, ref seek(buffer, index++));
            return cases;
        }

        static ref CallRel32Case load(AsmCaller caller, MemoryAddress ip, MemoryAddress next, MemoryAddress target, AsmHexCode encoding, SyntaxFragment line, ref CallRel32Case dst)
        {
            dst.Caller = caller;
            dst.Ip = ip;
            dst.NextIp = next;
            dst.Target = target;
            dst.RelTarget = (uint)(target - next);
            dst.Encoding = encoding;
            dst.AsmSource = line;
            return ref dst;
        }
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiCaptureResult
    {
        [MethodImpl(Inline), Op]
        public static ApiCaptureResult create(OpIdentity id, ExtractTermCode term, MemoryRange range, CodeBlockPair pair)
            => new ApiCaptureResult(term, range, pair);

        /// <summary>
        /// The capture termination code indicating why the capture process reached end-state
        /// </summary>
        public ExtractTermCode TermCode {get;}

        public CodeBlockPair Pair {get;}

        public MemoryRange CaptureRange {get;}

        [MethodImpl(Inline)]
        public ApiCaptureResult(ExtractTermCode term,  MemoryRange range, CodeBlockPair pair)
        {
            TermCode = term;
            Pair = pair;
            CaptureRange = range;
        }
    }
}
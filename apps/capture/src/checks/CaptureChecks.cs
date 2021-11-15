//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CaptureChecks : ICaptureChecks
    {
        static IJsonSettings json(FS.FilePath src)
            => JsonSettings.Load(src);

        public static ICheckContext context(IWfRuntime wf)
            => new CheckContext(wf.AppPaths, Rng.@default(), json(wf.AppPaths.AppConfigPath), MsgExchange.Create());

        public IAsmContextDepr Context {get;}

        readonly NativeBuffers _Buffers;

        public BufferTokens Tokens {get;}

        [MethodImpl(Inline)]
        public CaptureChecks(IWfRuntime wf)
        {
            Context = new AsmContextDepr(context(wf), wf);
            _Buffers = memory.native(Pow2.T16, 5);
            Tokens = _Buffers.Tokenize();
        }

        public ref readonly BufferToken this[BufferSeqId id]
        {
            [MethodImpl(Inline)]
            get => ref Tokens[id];
        }

        public void Dispose()
        {
            _Buffers.Dispose();
        }
    }
}
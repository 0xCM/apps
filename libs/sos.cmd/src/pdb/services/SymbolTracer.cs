//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.SymbolStore;

    readonly struct SymbolTracer : ITracer
    {
        readonly IWfRuntime Wf;

        [MethodImpl(Inline)]
        public SymbolTracer(IWfRuntime wf)
            => Wf = wf;

        [MethodImpl(Inline), Op]
        public void Error(string message)
            => Wf.Error(message);

        [MethodImpl(Inline), Op]
        public void Error(string format, params object[] arguments)
            => Wf.Error(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Information(string message)
            => Wf.Status(message);

        [MethodImpl(Inline), Op]
        public void Information(string format, params object[] arguments)
            => Wf.Status(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Verbose(string message)
            => Wf.Status(message);

        [MethodImpl(Inline), Op]
        public void Verbose(string format, params object[] arguments)
            => Wf.Status(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Warning(string message)
            => Wf.Warn(message);

        [MethodImpl(Inline), Op]
        public void Warning(string format, params object[] arguments)
            => Wf.Warn(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void WriteLine(string message)
            => Wf.Data(message);

        [MethodImpl(Inline), Op]
        public void WriteLine(string format, params object[] arguments)
            => Wf.Data(string.Format(format, arguments));
    }
}
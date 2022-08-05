//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RuntimeEmitter
    {
        public static ExecToken emit(IApiPack dst, WfEmit channel)
            => emit(Process.GetCurrentProcess(),dst,channel);

        public static ExecToken emit(ProcessAdapter src, IApiPack dst, WfEmit channel)
        {
            var running = channel.Running($"Emiting context for process {src.Id} based at {src.BaseAddress} from {src.Uri}");
            modules(src, dst, channel);
            dump(src, dst,channel);
            return channel.Ran(running);           
        }

        public static ExecToken modules(Process src, IApiPack dst, WfEmit channel)
        {
            return channel.TableEmit(ImageMemory.modules(src), dst.ProcessModules());
        }

        public static ExecToken dump(Process src, IApiPack dst, WfEmit channel)
        {
            var path = dst.DumpPath(src);
            var running = channel.EmittingFile(path);
            DumpEmitter.emit(src, path.Format(PathSeparator.BS), DumpTypeOption.Everything);
            return channel.EmittedBytes(running, path.Size);
        }
    }
}
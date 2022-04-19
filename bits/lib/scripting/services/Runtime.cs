//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Diagnostics;
    using System.Reflection;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Runtime
    {
        public static ClrAssemblyAdapter EntryAssembly
        {
            [MethodImpl(Inline), Op]
            get => Assembly.GetEntryAssembly();
        }

        public static ProcessAdapter CurrentProcess
        {
            [MethodImpl(Inline), Op]
            get => Process.GetCurrentProcess();
        }

        [Op]
        public static ProcessMemoryMap map(ProcessAdapter src)
        {
            var mods = modules(src);
            var count = mods.Length;
            var buffer = core.alloc<ModuleMemory>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var mod = ref skip(mods,i);
                seek(dst,i) = new ModuleMemory(mod.Path.FileName.WithoutExtension.Format(), mod.BaseAddress, mod.ModuleMemorySize);
            }
            var main = src.MainModule;
            return new ProcessMemoryMap(src.ProcessName, (uint)src.Id, main.BaseAddress, main.ModuleMemorySize, buffer);
        }

        [Op]
        public static ReadOnlySpan<ProcessModuleAdapter> modules(ProcessAdapter src)
            => src.Modules.OrderBy(x => x.BaseAddress).Array();

        [Op]
        public static ReadOnlySpan<ProcessModuleAdapter> modules()
            => modules(CurrentProcess);
    }
}
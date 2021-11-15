//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;
    using static core;
    using static DiagnosticRecords;

    using ClrMd = Microsoft.Diagnostics.Runtime;

    partial struct DiagnosticProcessors
    {
        public class ModuleProcessor
        {
            readonly IEventSink Events;

            readonly bool Pll;

            readonly ConcurrentBag<ModuleInfo> _Modules;

            readonly ConcurrentBag<MethodTableToken> _MethodTables;

            readonly object Locker;

            [MethodImpl(Inline)]
            internal ModuleProcessor(IEventSink sink, bool pll = true)
            {
                Events = sink;
                Pll = pll;
                _Modules = new();
                _MethodTables = new();
                Locker = new();
            }

            public void Process(ReadOnlySpan<ClrMd.ClrModule> src)
            {
                iter(src, Process, Pll);
            }

            public void Process(ClrMd.ClrModule src)
            {
                var dst = new ModuleInfo();
                dst.Address = src.Address;
                dst.Name = FS.path(src.Name).FileName.Format();
                dst.AssemblyAddress = src.AssemblyAddress;
                dst.MetadataAddress = src.MetadataAddress;
                dst.MetadataSize = src.MetadataLength;
                dst.Layout = src.Layout;
                dst.ImageBase = src.ImageBase;
                dst.ModulePath = FS.path(src.Name).ToUri().Format();
                var pdb = src.Pdb;
                if(pdb != null)
                    dst.Pdb = new PdbInfo(pdb.Guid, pdb.Revision, FS.path(pdb.Path));
                else
                    dst.Pdb = PdbInfo.Empty;

                _Modules.Add(dst);

                src.EnumerateTypeDefToMethodTableMap()
                    .Iter(x => _MethodTables.Add(new MethodTableToken(x.MethodTable, x.Token)));
            }

            public ModuleProcessPresult Processed()
            {
                var result = new ModuleProcessPresult();
                lock(Locker)
                {
                    result._Modules = _Modules.ToArray();
                    result._MethodTables = _MethodTables.ToArray().Sort();
                    _Modules.Clear();
                    _MethodTables.Clear();
                }
                return result;
            }
        }
    }
}
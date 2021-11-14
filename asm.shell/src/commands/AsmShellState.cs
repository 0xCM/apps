//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    public class AsmShellState : CmdShellState
    {
        Index<ProcessAsmRecord> _ProcessAsm;

        Index<ProcessAsmRecord> _ProcessAsmSelection;

        Index<HostAsmRecord> _HostAsm;

        Index<AsmDataBlock> _AsmBlocks;

        IApiCatalog _ApiCatalog;

        public AsmShellState()
        {
            _ProcessAsm = array<ProcessAsmRecord>();
            _ProcessAsmSelection = array<ProcessAsmRecord>();
            _HostAsm = array<HostAsmRecord>();
            _AsmBlocks = array<AsmDataBlock>();
        }

        public ReadOnlySpan<AsmDataBlock> Records(Func<Index<AsmDataBlock>> loader)
        {
            if(_AsmBlocks.IsEmpty)
                _AsmBlocks = loader();
            return _AsmBlocks;
        }

        public ReadOnlySpan<HostAsmRecord> HostAsm(Func<Index<HostAsmRecord>> loader)
        {
            if(_HostAsm.IsEmpty)
                _HostAsm = loader();
            return _HostAsm;
        }

        [MethodImpl(Inline)]
        public Span<ProcessAsmRecord> ProcessAsmSelection()
            => _ProcessAsmSelection.Edit;

        [MethodImpl(Inline)]
        public ReadOnlySpan<ProcessAsmRecord> ProcessAsm()
        {
            if(_ProcessAsm.IsEmpty)
            {
                var result = LoadProcessAsm();
                if(result.Fail)
                    Wf.Error(result.Message);
            }
            return _ProcessAsm;
        }

        Outcome LoadProcessAsm()
        {
            var archive = Wf.ApiPacks().Current().Archive();
            var path = archive.ProcessAsmPath();
            var count = FS.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var flow = Wf.Running(string.Format("Loading process asm from {0}", path.ToUri()));
            var result = asm.load(path, buffer);
            if(result.Fail)
                return (false, result.Message);

            _ProcessAsm = buffer;
            _ProcessAsmSelection = alloc<ProcessAsmRecord>(_ProcessAsm.Count);

            Wf.Ran(flow, string.Format("Loaded {0} process asm records from {1}", _ProcessAsm.Length, path.ToUri()));
            return true;
        }
    }
}
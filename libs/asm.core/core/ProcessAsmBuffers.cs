//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class ProcessAsmBuffers : AppService<ProcessAsmBuffers>
    {
        Index<ProcessAsmRecord> _ProcessAsm;

        Index<ProcessAsmRecord> _ProcessAsmSelection;

        public ProcessAsmBuffers()
        {
            _ProcessAsm = array<ProcessAsmRecord>();
            _ProcessAsmSelection = array<ProcessAsmRecord>();
        }

        public ReadOnlySpan<ProcessAsmRecord> Vex()
        {
            var counter = 0u;
            var records = Records();
            var buffer = Selected();
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.vex(records, ref i, buffer);
            return slice(buffer,0,count);
        }

        [MethodImpl(Inline)]
        public Span<ProcessAsmRecord> Selected()
            => _ProcessAsmSelection.Edit;

        [MethodImpl(Inline)]
        public ReadOnlySpan<ProcessAsmRecord> Records()
        {
            if(_ProcessAsm.IsEmpty)
            {
                var result = Load();
                if(result.Fail)
                    Error(result.Message);
            }
            return _ProcessAsm;
        }

        Outcome Load()
        {
            var archive = Wf.ApiPacks().Current().Archive();
            var path = archive.ProcessAsmPath();
            var count = FS.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var flow = Running(string.Format("Loading process asm from {0}", path.ToUri()));
            var result = AsmTables.load(path, buffer);
            if(result.Fail)
                return (false, result.Message);

            _ProcessAsm = buffer;
            _ProcessAsmSelection = alloc<ProcessAsmRecord>(_ProcessAsm.Count);

            Ran(flow, string.Format("Loaded {0} process asm records from {1}", _ProcessAsm.Length, path.ToUri()));
            return true;
        }
    }
}
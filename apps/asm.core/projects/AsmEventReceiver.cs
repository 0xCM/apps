//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmCorrelation
    {
        public readonly XedDisasmDetail XedDisasm;

        public readonly ObjDumpRow ObjDump;

        [MethodImpl(Inline)]
        public AsmCorrelation(XedDisasmDetail xed, ObjDumpRow objdump)
        {
            XedDisasm = xed;
            ObjDump = objdump;
        }


        public readonly struct Cmp1 : IComparer<AsmCorrelation>
        {
            public int Compare(AsmCorrelation x, AsmCorrelation y)
            {
                var result = x.ObjDump.DocName.CompareTo(y.ObjDump.DocName);
                if(result == 0)
                {
                    result = x.XedDisasm.IP.CompareTo(y.XedDisasm.IP);
                }
                return result;
            }
        }
    }



    public class AsmEventReceiver
    {
        FileCatalog Files;

        ConcurrentDictionary<InstructionId,AsmEncodingRow> EncodingRows;

        ConcurrentBag<AsmEncodingRow> EncodingDuplicates;

        ConcurrentDictionary<DocRowKey,AsmSyntaxRow> SyntaxRows;

        ConcurrentBag<AsmSyntaxRow> SyntaxDuplicates;

        ConcurrentDictionary<DocRowKey,AsmInstructionRow> InstructionRows;

        ConcurrentBag<AsmInstructionRow> InstructionDuplicates;

        ConcurrentDictionary<InstructionId,XedDisasmDetail> XedDisasmRows;

        ConcurrentBag<XedDisasmDetail> XedDisasmDuplicates;

        ConcurrentDictionary<InstructionId,ObjDumpRow> ObjDumpRows;

        ConcurrentBag<ObjDumpRow> ObjDumpDuplicates;

        Index<AsmInstructionRow> _CollectedInstructions;

        public AsmEventReceiver()
        {
            EncodingRows = new();
            EncodingDuplicates = new();
            SyntaxRows = new();
            SyntaxDuplicates = new();
            InstructionRows = new();
            InstructionDuplicates = new();
            XedDisasmRows = new();
            XedDisasmDuplicates = new();
            ObjDumpRows = new();
            ObjDumpDuplicates = new();
        }

        public void Seal()
        {
            _CollectedInstructions = InstructionRows.Values.Array();
        }

        static HashSet<InstructionId> intersect(HashSet<InstructionId> a, HashSet<InstructionId> b)
        {
            var dst = hashset<InstructionId>();
            foreach(var key in a)
            {
                if(b.Contains(key))
                {
                    dst.Add(key);
                }
            }

            foreach(var key in b)
            {
                if(a.Contains(key))
                {
                    dst.Add(key);
                }
            }
            return dst;
        }
        public Index<AsmCorrelation> Correlate()
        {
            var k1 = hashset<InstructionId>();
            var k2 = hashset<InstructionId>();

            iter(ObjDumpRows.Keys, k => k1.Add(k));
            iter(XedDisasmRows.Keys, k => k2.Add(k));

            var keys = intersect(k1,k2);
            var count = keys.Count;
            var dst = alloc<AsmCorrelation>(count);
            var i=0;
            foreach(var key in keys)
            {
                var xed = XedDisasmRows[key];
                var obj = ObjDumpRows[key];

                seek(dst,i++) = new AsmCorrelation(xed, obj);
            }

            Array.Sort(dst,new AsmCorrelation.Cmp1());
            return dst;
        }

        public ReadOnlySpan<AsmInstructionRow> CollectedInstructions()
            => _CollectedInstructions;


        public virtual void Initialized(WsContext context)
        {
            Files = context.Files;
        }

        public virtual void Collected(Index<ObjDumpRow> src)
        {
            iter(src, row => {
                if(!ObjDumpRows.TryAdd(row.InstructionId, row))
                    ObjDumpDuplicates.Add(row);
            }, true);

        }

        public virtual void Collected(Index<ObjBlock> src)
        {

        }

        public virtual void Collected(Index<ObjSymRow> src)
        {

        }

        public virtual void Collected(CoffSymIndex src)
        {

        }


        public virtual void Collected(Index<AsmEncodingRow> src)
        {
            iter(src, row => {
                if(!EncodingRows.TryAdd(row.InstructionId, row))
                    EncodingDuplicates.Add(row);
            }, true);
        }

        public virtual void Collected(Index<AsmSyntaxRow> src)
        {
            iter(src, row => {
                if(!SyntaxRows.TryAdd(row.Key, row))
                    SyntaxDuplicates.Add(row);
            }, true);
        }

        public virtual void Collected(Index<AsmInstructionRow> src)
        {
            iter(src, row => {
                if(!InstructionRows.TryAdd(row.Key, row))
                    InstructionDuplicates.Add(row);
            }, true);
        }

        public virtual void Collected(Index<XedDisasmDetail> src)
        {
            iter(src, row => {
                if(!XedDisasmRows.TryAdd(row.InstructionId, row))
                    XedDisasmDuplicates.Add(row);
            }, true);
        }
    }
}
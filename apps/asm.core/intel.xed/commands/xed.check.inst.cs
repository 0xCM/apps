//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        static Index<string> slots(byte i0, byte count, short pad)
        {
            var dst = alloc<string>(count);
            var j=i0;
            for(byte i=0; i<count; i++,j++)
                seek(dst,i) = RP.slot(j,pad);
            return dst;
        }

        static Index<string> slots(byte i0, short[] pad)
        {
            var count = pad.Length;
            var j=i0;
            var dst = alloc<string>(count);
            for(byte i=0; i<count; i++, j++)
                seek(dst,i) = RP.slot(j,skip(pad,i));
            return dst;
        }

        const byte MaxOpCount = 12;

        const byte LeadColCount = 10;

        const sbyte OpColPad = -8;

        static string[] LeadCols = new string[LeadColCount]{"Id", "InstClass", "OcIx[0]", "OxIx[1]", "OcClass", "OcMap", "OcValue", "Lockable", "Locked", "Mode"};

        static short[] LeadPad = new short[LeadColCount]{-8,-18,-8,-8,-8,-8,-16,-8,-8,-8};

        static string[] OpCols = new string[MaxOpCount]{"Op0", "Op1", "Op2", "Op3", "Op4", "Op5", "Op6", "Op7", "Op8", "Op9", "Op10", "Op11"};

        static string[] VectorCols = LeadCols.Append(OpCols);

        static Index<string> VectorSlots()
            => slots(0, LeadPad).Append(slots(LeadColCount, MaxOpCount, OpColPad));

        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var slots = VectorSlots();
            var render = slots.Join(" | ");
            var cols = VectorCols;
            Index<object> cells = alloc<object>(cols.Length);

            var src = Xed.Rules.CalcInstPatterns();
            var dst = XedPaths.Targets() + FS.file("xed.inst.patterns.vectors", FS.Csv);
            var @class = InstClass.Empty;
            var rows = text.buffer();
            var opcode = XedOpCode.Empty;
            var ocix0 = z8;
            var ocix1 = z8;
            rows.AppendLineFormat(render, cols);
            for(var i=0; i<src.Count; i++, ocix0++, ocix1++)
            {
                cells.Clear();
                ref readonly var pattern = ref src[i];
                ref readonly var ops = ref pattern.Ops;
                ref readonly var names = ref pattern.OpNames;
                ref readonly var poc = ref pattern.OpCode;

                if(@class != pattern.Classifier)
                {
                    ocix0 = z8;
                    @class = pattern.Classifier;
                }

                if(opcode != poc)
                {
                    ocix1 = z8;
                    opcode = poc;
                }

                var k=0;
                cells[k++] = pattern.PatternId;
                cells[k++] = pattern.Classifier;
                cells[k++] = ocix0;
                cells[k++] = ocix1;
                cells[k++] = poc.Class;
                cells[k++] = poc.Selector;
                cells[k++] = poc.Value;
                cells[k++] = pattern.LockState.Lockable;
                cells[k++] = pattern.LockState.Locked;
                cells[k++] = pattern.Mode;

                var ncount = min(names.Count, MaxOpCount);
                for(var j=0; j<ncount; j++)
                    cells[k++] = names[j];
                for(var j=ncount; j<MaxOpCount; j++)
                    cells[k++] = EmptyString;

                rows.AppendLine(string.Format(render, cells.Storage));
            }
            FileEmit(rows.Emit(), src.Count, dst, TextEncodingKind.Asci);
            return true;
        }
    }
}
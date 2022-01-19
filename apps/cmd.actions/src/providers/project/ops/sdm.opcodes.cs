//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static core;

    public readonly struct ListProduct<T>
    {
        public readonly Index<T> Left;

        public readonly Index<T> Right;

        public readonly Pairings<T,Index<T>> Result;

        public ListProduct(T[] left, T[] rigth, Pairings<T,Index<T>> result)
        {
            Result = result;
            Left = left;
            Right = rigth;
        }
    }

    public readonly struct SeqProduct<T>
    {
        public readonly Index<T> Left;

        public readonly Index<T> Right;

        public readonly Pairs<T> Result;

        public SeqProduct(T[] left, T[] rigth, Pairs<T> result)
        {
            Result = result;
            Left = left;
            Right = rigth;
        }
    }

    public readonly struct SeqProducts
    {
        public static ListProduct<T> dist<T>(Index<T> a, Index<T> b)
        {
            var count = a.Length;
            var dst = alloc<Paired<T,Index<T>>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (a[i], b);
            return new ListProduct<T>(a,b,dst);
        }

        public static SeqProduct<T> mul<T>(Index<T> a, Index<T> b)
        {
            var kA = a.Count;
            var kB = b.Count;
            var count = kA*kB;
            var buffer = alloc<Pair<T>>(count);
            var k=0u;
            for(var i=0; i<kA; i++)
            for(var j=0; j<kB; j++)
                seek(buffer,k++) = (a[i], b[j]);
            return new SeqProduct<T>(a,b,buffer);
        }

        public static string format<T>(SeqProduct<T> src)
        {
            var dst = text.buffer();
            var result = src.Result;
            var count = result.PointCount;
            dst.Append(Chars.LBracket);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(", ");

                ref var x = ref src.Result[i];
                dst.Append(x.Format());

            }
            dst.Append(Chars.RBracket);
            return dst.Emit();
        }
    }

    partial class ProjectCmdProvider
    {
        [CmdOp("seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }
        [CmdOp("sdm/productions")]
        Outcome SdmProductions(CmdArgs args)
        {
            var path = ProjectDb.Settings("asm.sigs.atomics", FS.ext("map"));
            var src = rules.atomics(path);
            foreach(var e in src.Entries)
            {
                var regs = e.Value;
                var expr = e.Key;
                Write(string.Format("{0} -> [{1}]", expr, regs));
            }
            return true;
        }

        [CmdOp("sdm/opcodes")]
        Outcome SdmOpCodes(CmdArgs args)
        {
            EmitSdmOpCodeDocs();
            return true;
        }

        void EmitSdmOpCodeDocs()
        {
            var codes = Sdm.LoadImportedOpCodes();
            var count = codes.Count;
            var buffer = alloc<AsmSigOpExpr>(12);
            var dst = ProjectDb.Subdir("sdm") + FS.file("sdm.opcodes.tables", FS.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();

            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var entry = ref codes[i];
                ref readonly var sig = ref entry.Sig;
                ref readonly var opcode = ref entry.OpCode;
                var opcount = sig.Operands(buffer);
                writer.WriteLine(string.Format("{0,-8} | {1,-64} | {2,-36}", entry.OpCodeKey, sig.Format(), opcode.Expr.Format()));
                for(var j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(buffer,j);
                    writer.WriteLine(string.Format("       {0} | {1}", j, op.Format()));
                }
            }
            EmittedFile(emitting,count);
        }
   }
}
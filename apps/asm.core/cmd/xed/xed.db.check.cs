//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static MemDb;
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/db/check")]
        Outcome CheckXedDb(CmdArgs args)
        {
            var formatter = RecordFormatter.create(typeof(TypeTableRow));
            var rows = Rules.CalcTypeTables().SelectMany(x => x.Rows).Sort().Resequence();
            AppSvc.TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
            CheckRender();
            return true;
        }

        [MethodImpl(Inline)]
        static ulong key(Type type, ushort selector)
        {
            var token = (uint)type.MetadataToken;
            var part = type.Assembly.Id();
            return (ulong)token | ((ulong)part << 32) | ((ulong)selector << 38);
        }

        void CheckRender()
        {
            var k0 = key(typeof(num4),z16);
            var points = Rules.CalcPoints();
            var f2 = Tables.formatter<Coordinate>();
            for(var i=0; i<points.Count; i++)
            {
                ref readonly var point = ref points[i];
                Write(f2.Format(point));
            }
        }

        void CheckMemDb(Dim2<uint> shape)
        {
            var r = shape.I;
            var c = shape.J;
            var m = (uint)(r*c);
            var grid = MemDb.grid<byte>(shape);
            ref readonly var rows = ref grid.Rows;
            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                    rows[i,j] = (byte)math.mod((i*c + j), r) ;
            }

            var cols = rows.Columns();
            var rDst = text.emitter();
            var cDst = text.emitter();

            for(var i=0u; i<r; i++)
            {
                for(var j=0u; j<c; j++)
                {
                    rDst.AppendFormat("{0:X2} | ", rows[i,j]);
                    cDst.AppendFormat("{0:X2} | ", cols[i,j]);
                }

                rDst.AppendLine();
                cDst.AppendLine();
            }

            var linear = Points.multilinear(shape);
            var lDst = text.emitter();
            Points.render(linear, lDst);

            var scope = "memdb";
            var suffix = $"{r}x{c}";
            FileEmit(lDst.Emit(), linear.Count, AppDb.Logs().Scoped(scope).Path($"{scope}.linear.{suffix}", FileKind.Csv));
            FileEmit(rDst.Emit(), m, AppDb.Logs().Scoped(scope).Path($"{scope}.rows.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
            FileEmit(cDst.Emit(), m, AppDb.Logs().Scoped(scope).Path($"{scope}.cols.{suffix}", FileKind.Txt), TextEncodingKind.Asci);
        }

        [CmdOp("memdb/check")]
        Outcome CheckMemDb(CmdArgs args)
        {
            CheckMemDb((32,32));
            CheckMemDb((12,12));
            CheckMemDb((8,8));
            CheckMemDb((256,256));
           return true;
        }

        [CmdOp("xed/import/cpuid")]
        Outcome ImportXedCpuid(CmdArgs args)
        {
            var path = XedPaths.CpuIdSource();
            var data = path.ReadLines(true);
            var parser = new CpuidParser();
            parser.Run(data);
            AppSvc.TableEmit(parser.IsaRecords, XedPaths.RefTable<IsaRecord>());
            AppSvc.TableEmit(parser.CpuIdRecords, XedPaths.RefTable<CpuIdIsa>());
            return true;
        }
    }

    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public record struct IsaRecord : ISequential<IsaRecord>, IComparable<IsaRecord>
    {
        public const string TableId = "isa.imported";

        [Render(6)]
        public byte Seq;

        [Render(48)]
        public asci64 XedName;

        [Render(32)]
        public asci32 IsaName;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = (byte)value;
        }

        public int CompareTo(IsaRecord src)
            => IsaName.CompareTo(src.IsaName);
    }

    [StructLayout(StructLayout,Pack=1),Record(TableId)]
    public record struct CpuIdIsa : IComparable<CpuIdIsa>, ISequential<CpuIdIsa>
    {
        public const string TableId = "cpuid.isa.imported";

        [Render(6)]
        public ushort Seq;

        [Render(32)]
        public asci32 IsaName;

        [Render(32)]
        public asci64 CpuIdSpec;

        [MethodImpl(Inline)]
        public CpuIdIsa(asci32 isa, uint key, asci64 spec)
        {
            Seq = 0;
            CpuIdSpec = spec;
            IsaName = isa;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = (ushort)value;
        }

        public int CompareTo(CpuIdIsa src)
        {
            var result = IsaName.CompareTo(src.IsaName);
            if(result == 0)
                CpuIdSpec.CompareTo(src.CpuIdSpec);
            return result;
        }
    }

    public class CpuidParser
    {
        ConcurrentDictionary<uint,asci64> IsaBuffer = new();

        ConcurrentBag<CpuIdIsa> CpuIdBuffer = new();

        SortedLookup<uint,string> SortedIsa = dict<uint,string>();

        Index<CpuIdIsa> CpuIdFinal = sys.empty<CpuIdIsa>();

        Index<IsaRecord> IsaFinal = sys.empty<IsaRecord>();

        public ref readonly Index<CpuIdIsa> CpuIdRecords => ref CpuIdFinal;

        public ref readonly Index<IsaRecord> IsaRecords => ref IsaFinal;

        public void Run(Index<string> data)
        {
            iter(data.Select(normalize), Parse, true);

            var _sortedIsa = IsaBuffer.Map(x => (key:x.Key, name:text.ifempty(x.Value, EmptyString))).ToSortedLookup();

            SortedIsa = _sortedIsa;
            var keys = SortedIsa.Keys;
            var count = keys.Length;
            var dst = alloc<IsaRecord>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                asci64 isa = text.ifempty(SortedIsa[key], EmptyString);
                record(isa, out dst[i]);
            }

            IsaFinal = dst.Sort().Resequence();
            CpuIdFinal = CpuIdBuffer.Index().Sort().Resequence();
        }

        uint IsaKey;

        uint CpuIdKey;

        [MethodImpl(Inline)]
        uint NextIsaKey()
            => inc(ref IsaKey);

        [MethodImpl(Inline)]
        uint NextCpuIdKey()
            => inc(ref CpuIdKey);

        uint StoreIsa(asci64 src)
        {
            var seq = NextIsaKey();
            IsaBuffer.TryAdd(seq,src);
            return seq;
        }

        void StoreCpuId(asci64 xedIsa, string src)
        {
            const string Null = "n/a";
            var parts = text.split(src, Chars.Space).ToIndex();
            var count = parts.Length;
            for(var i=0u; i<count; i++)
                if(parts[i] != Null)
                    CpuIdBuffer.Add(Record(IsaName(xedIsa), parts[i], out _));
        }

        [MethodImpl(Inline)]
        CpuIdIsa Record(asci32 isa, asci64 cpuidSpec, out CpuIdIsa dst)
            => dst = new CpuIdIsa(isa, NextCpuIdKey(), cpuidSpec);

        void Parse(string src)
        {
            var input = Require.notnull(src);
            if(!IsComment(input))
            {
                if(split(input, out asci64 isa, out string cpuid))
                {
                    StoreIsa(isa);
                    if(nonempty(cpuid))
                        StoreCpuId(isa, cpuid);
                }
            }
        }

        [MethodImpl(Inline)]
        static asci32 IsaName(asci64 src)
            => src.Format().Remove("XED_ISA_SET_");

        static void record(asci64 src, out IsaRecord dst)
        {
            dst.Seq = 0;
            dst.XedName = src;
            dst.IsaName = IsaName(src);
        }

        static bool split(string src, out asci64 isa, out string cpuid)
        {
            var result = true;
            var j = text.index(src,Chars.Colon);
            if(j > 0)
            {
                isa = text.ifempty(text.left(src,j),EmptyString);
                cpuid = text.ifempty(text.trim(text.right(src,j)), EmptyString);
            }
            else
            {
                isa = EmptyString;
                cpuid = EmptyString;
                result = false;
            }
            return result;
        }

        static bool IsComment(string src)
            => text.begins(src, Chars.Hash);

        static string normalize(string src)
        {
            var input = text.ifempty(text.trim(text.despace(src)), EmptyString);
            var output = input;
            if(IsComment(input))
                return output;

            var i = text.index(input, Chars.Hash);
            if(i > 0)
                output = text.trim(text.left(input,i));
            return output;
        }
    }
}
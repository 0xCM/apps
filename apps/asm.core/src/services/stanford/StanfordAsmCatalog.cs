//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Linq;

    using static Root;
    using static core;

    public sealed partial class StanfordAsmCatalog : AppService<StanfordAsmCatalog>
    {
        readonly TextDocFormat SourceFormat;

        readonly Index<StokeAsmAssetRow> RowBuffer;

        const uint MaxRowCount = 2500;

        const char AsmCatDelimiter = Chars.Tab;

        public StanfordAsmCatalog()
        {
            SourceFormat = TextDocFormat.Structured(AsmCatDelimiter, false);
            RowBuffer = alloc<StokeAsmAssetRow>(MaxRowCount);
        }

        public uint AssetImportCount {get; private set;}

        public ReadOnlySpan<StokeAsmExportRow> ImportExported()
        {
            var src = Db.Table<StokeAsmAssetRow>(TargetFolder);
            var doc = TextGrids.parse(src).Require();
            var data = doc.Rows;
            var count = data.Length;
            var buffer = span<StokeAsmExportRow>(count);
            for(var i=0; i<count; i++)
            {
                var export = default(StokeAsmExportRow);
                var import = default(StokeAsmAssetRow);
                map(skip(data, i), ref import);
                map(import, ref seek(buffer, i));
            }

            var dst = Db.Table<StokeAsmExportRow>(TargetFolder);
            var flow = Wf.EmittingTable<StokeAsmExportRow>(dst);
            var _count = Tables.emit(@readonly(buffer), dst);
            Wf.EmittedTable(flow, _count);
            return buffer;
        }

        /// <summary>
        /// Retrieves the forms present in the catalog
        /// </summary>
        public ReadOnlySpan<AsmFormInfo> DeriveFormExprssions()
        {
            var imported = LoadAsset();
            var count = imported.Length;
            var buffer = span<AsmFormInfo>(count);
            var j=0u;
            var k=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(imported, i);
                if(AsmParser.sigxpr(row.Instruction, out var sig))
                    seek(buffer, k++) = (asm.ocstring(row.OpCode), sig);
                else
                {
                    seek(buffer, k++) = AsmFormInfo.Empty;
                    Wf.Warn($"The opcode row {row.OpCode} could not be parsed");
                }
            }

            return buffer;
        }

        public ReadOnlySpan<Name> DeriveEncodingKinds()
        {
            var rows = LoadAsset();
            var count = rows.Length;
            var dst = hashset<Name>();
            mapi(rows, (i,n) => dst.Add(n.EncodingKind));
            return dst.Index().Sort();
        }

        public ReadOnlySpan<StokeAsmAssetRow> LoadAsset()
        {
            if(AssetImportCount != 0)
                return slice(RowBuffer.View,0, AssetImportCount);

            var descriptor = AsmData.Assets.StanfordAsmCatalog();
            var content = Resources.utf8(descriptor);
            ByteSize sz = content.Length*2;
            Wf.Status($"Loaded source catalog data of size {sz} bytes");

            var foundheader = false;
            var lines = Lines.read(content);

            Wf.Status($"Parsing {lines.Length} source catalog lines");

            var count = lines.Length;
            var buffer = RowBuffer.Edit;
            ref var dst = ref first(buffer);
            var j = z16;
            var failed = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                if(foundheader)
                {
                    var row = default(StokeAsmAssetRow);
                    if(line.IsNonEmpty)
                    {
                        if(parse(j, line, ref row))
                            seek(dst, j++) = row;
                        else
                        {
                            failed = true;
                            break;
                        }
                    }
                }
                else
                {
                    if(line.Content.Equals(SourceHeader))
                    {
                        foundheader = true;
                        Wf.Status($"Detected source catalog header with fields: {SourceHeaderFields.FormatList()}");
                    }
                }
            }

            AssetImportCount = j;
            return slice(buffer, 0, AssetImportCount);
        }

        public ReadOnlySpan<StokeAsmAssetRow> ExportAsset()
        {
            var dst = Db.Table<StokeAsmAssetRow>(TargetFolder);
            var flow = Wf.EmittingTable<StokeAsmAssetRow>(dst);
            var imports = LoadAsset();
            var count = Tables.emit(imports, dst);
            Wf.EmittedTable(flow, count);
            return imports;
        }

        public void EmitForms(ReadOnlySpan<AsmFormInfo> src)
            => Wf.AsmFormPipe().Emit(src, Db.Table<AsmFormRecord>(TargetFolder));

        Outcome parse(ushort seq, in TextLine src, ref StokeAsmAssetRow dst)
        {
            if(TextGrids.row(src, SourceFormat, out var row))
            {
                if(row.CellCount == 15)
                {
                    map(row, ref dst, (ushort)(seq + 1));
                    return true;
                }
                else
                {
                    Wf.Error($"Row content parse failure: {nameof(row.CellCount)} = {row.CellCount} != 15; Line: {src}");
                    return false;
                }
            }
            else
            {
                Wf.Error($"Row parse failure: {src.Content}");
                return false;
            }
        }

        FS.FolderName TargetFolder
            => FS.folder("asmcat");

        static bool mode64(string src)
            => src switch
            {
                "V" => true,
                _ => false
            };

        static void map(in StokeAsmAssetRow src, ref StokeAsmExportRow dst)
        {
            dst.Sequence = src.Sequence;
            dst.OpCode = src.OpCode;
            dst.Instruction = src.Instruction;
            dst.Mode64 = mode64(src.Mode64);
            dst.LegacyMode = src.LegacyMode;
            dst.EncodingKind = src.EncodingKind;
            dst.Properties = src.Properties;
            dst.ImplicitRead = src.ImplicitRead;
            dst.ImplicitWrite = src.ImplicitWrite;
            dst.ImplicitUndef = src.ImplicitUndef;
            dst.Protected = src.Protected;
            dst.Cpuid = src.Cpuid;
            dst.AttMnemonic = src.AttMnemonic;
            dst.Description = src.Description;
        }

        static void map(in TextRow src, ref StokeAsmAssetRow dst, ushort? seq = null)
        {
            var i = 0;
            var cells = src.Cells;
            if(seq == null)
                ScalarParser.parse(base10, skip(cells,i++).Text, out dst.Sequence);
            else
                dst.Sequence = seq.Value;
            dst.OpCode = skip(cells, i++);
            dst.Instruction = skip(cells, i++);
            dst.EncodingKind = skip(cells, i++);
            dst.Properties = skip(cells, i++);
            dst.ImplicitRead = skip(cells, i++);
            dst.ImplicitWrite = skip(cells, i++);
            dst.ImplicitUndef = skip(cells, i++);
            dst.Useful = skip(cells, i++);
            dst.Protected = skip(cells, i++);
            dst.Mode64 = skip(cells, i++);
            dst.LegacyMode = skip(cells, i++);
            dst.Cpuid = skip(cells, i++);
            dst.AttMnemonic = skip(cells, i++);
            dst.Preferred = skip(cells, i++);
            dst.Description = skip(cells, i++);
        }

        const string SourceHeader = "Opcode	Instruction	Op/En	Properties	Implicit Read	Implicit Write	Implicit Undef	Useful	Protected	64-bit Mode	Compat/32-bit-Legacy Mode	CPUID Feature Flags	AT&T Mnemonic	Preferred 	Description";

        static ReadOnlySpan<string> SourceHeaderFields
            => SourceHeader.Split(AsmCatDelimiter);
    }
}
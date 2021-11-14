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

    public class ApiResPackUnpacker : AppService<ApiResPackUnpacker>
    {
        public ReadOnlySpan<MemorySeg> Emit(FS.FolderPath dst)
        {
            var asmpath = dst + FS.file("respack",FS.Asm);
            var hexpath = asmpath.ChangeExtension(FS.Hex);
            var provider = Wf.ApiResProvider();
            var path = provider.ResPackPath();
            var assembly = Assembly.LoadFrom(path.Name);
            var accessors = provider.ResPackAccessors();
            var count = accessors.Length;
            var decoder = Wf.AsmDecoder();
            var buffer = text.buffer();
            var sequence = 0u;
            var segments = list<MemorySeg>(30000);
            var asmFlow = Wf.EmittingFile(asmpath);
            var hexFlow = Wf.EmittingFile(hexpath);
            using var asmwriter = asmpath.Writer();
            using var hexwriter = hexpath.Writer();
            for(var i=0; i<count; i++)
            {
                var seqlabel = sequence.ToString("d6") + ": ";
                ref readonly var accessor = ref skip(accessors,i);
                var bytes = SpanRes.definition(accessor);
                var decoded = decoder.Decode(bytes.ToArray(), MemoryAddress.Zero).View;
                var name = accessor.DeclaringType.Name + "/" + accessor.Member.Name;
                asmwriter.WriteLine(asm.comment(seqlabel + name));
                AsmFormatter.render(bytes, decoded, buffer);
                asmwriter.Write(buffer.Emit());

                var offset = z16;
                var mov = AsmHexCode.Empty;
                var movsize = AsmHexCode.Empty;
                hexwriter.Write(seqlabel);
                for(var j=0; j<decoded.Length; j++)
                {
                    ref readonly var fx = ref skip(decoded,j);
                    var size = (byte)fx.ByteLength;
                    var code = asm.hexcode(slice(bytes, offset, size));

                    if(j !=0)
                        hexwriter.Write(Chars.Space);
                    hexwriter.Write(code.Format());
                    if(size == 10)
                        mov = code;
                    else if(size == 7)
                        movsize = code;
                    offset += size;
                }

                var imm64 = bw64u(slice(mov.Bytes, 2));
                var imm32 = bw32u(slice(movsize.Bytes, 3));
                hexwriter.Write(string.Format(" ## {0:X} ## {1:X}", imm64, imm32));
                hexwriter.WriteLine();

                segments.Add(SpanRes.capture(accessor));
                sequence++;
            }

            Wf.EmittedFile(asmFlow, sequence);
            Wf.EmittedFile(hexFlow, sequence);
            var deposited = segments.ViewDeposited();
            EmitHexPack(deposited, dst + FS.file("respack", FS.XPack));
            EmitHexArrays(deposited, dst + FS.file("respack", FS.ext("xarray")));
            return deposited;
        }

        void EmitHexPack(ReadOnlySpan<MemorySeg> src, FS.FilePath dst)
        {
            var flow= Wf.EmittingFile(dst);
            var count = src.Length;
            var buffer = alloc<char>(Pow2.T16);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                ref readonly var seg = ref skip(src,i);
                buffer.Clear();
                writer.WriteLine(MemoryStore.linepack(seg, i, buffer));
            }
            Wf.EmittedFile(flow, count);
        }

        void EmitHexArrays(ReadOnlySpan<MemorySeg> src, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var count = src.Length;
            var buffer = alloc<char>(Pow2.T16);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                ref readonly var seg = ref skip(src,i);
                buffer.Clear();
                writer.WriteLine(MemoryStore.arraypack(seg, i, buffer));
            }
            Wf.EmittedFile(flow, count);
        }
    }
}
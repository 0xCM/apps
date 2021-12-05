//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ApiCaptureSet
    {
        [MethodImpl(Inline), Op]
        public static ApiCaptureSet create(OpUri id, MsilSourceBlock msil,  CodeBlock hex, AsmSourceBlock asm, MethodDisplaySig sig)
            => new ApiCaptureSet(id, msil, hex, asm,sig);

        [MethodImpl(Inline), Op]
        public static ApiCaptureSet create(in ApiCaptureBlock src, in AsmSourceBlock asm)
            => new ApiCaptureSet(src.OpUri, msil(src.Msil), src.CodeBlock, asm, src.Method.DisplaySig());

        [Op]
        public static ApiCaptureSet create(OpIdentity id, MethodInfo method, CodeBlock hex, AsmSourceBlock asm)
        {
            var uri = ApiUri.hex(method.DeclaringType.ApiHostUri(), method.Name, id);
            return new ApiCaptureSet(uri, msil(ClrDynamic.msil(hex.BaseAddress, uri, method)), hex, asm, method.DisplaySig());
        }

        [MethodImpl(Inline), Op]
        public static MsilSourceBlock msil(CliToken id, CliSig sig, BinaryCode encoded, MethodImplAttributes attributes = default)
            => new MsilSourceBlock(id, sig, encoded);

        [MethodImpl(Inline), Op]
        public static MsilSourceBlock msil(in ApiMsil src, MethodImplAttributes attributes = default)
            => msil(src.Token, src.CliSig, src.CliCode, attributes);

        public OpUri Id {get;}

        public MsilSourceBlock Msil {get;}

        public CodeBlock Hex {get;}

        public AsmSourceBlock Asm {get;}

        public MethodDisplaySig DisplaySig {get;}

        [MethodImpl(Inline)]
        public ApiCaptureSet(in OpUri id, in MsilSourceBlock msil,  in CodeBlock hex, in AsmSourceBlock asm, in MethodDisplaySig sig)
        {
            Id = id;
            Msil = msil;
            Hex = hex;
            Asm = asm;
            DisplaySig = sig;
        }

        public bool Complete
        {
            [MethodImpl(Inline)]
            get => Msil.Complete && Id.IsNonEmpty && Hex.IsNonEmpty && Asm.IsNonEmpty;
        }

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Id.Part;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Id.Host;
        }

        public ByteSize HexSize
        {
            [MethodImpl(Inline)]
            get => Hex.Size;
        }

        public ByteSize MsilSize
        {
            [MethodImpl(Inline)]
            get => Msil.Size;
        }

        public CliSig CliSig
        {
            [MethodImpl(Inline)]
            get => Msil.Sig;
        }
    }
}
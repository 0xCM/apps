//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct LlvmDataType
    {
        public static LlvmDataType parse(string src)
        {
            if(src.Equals("bit"))
                return new LlvmDataType(src, LlvmDataKind.Bit);
            else if(src.Equals("string"))
                return new LlvmDataType(src, LlvmDataKind.String);
            else if(src.Equals("int"))
                return new LlvmDataType(src, LlvmDataKind.Int);
            else if(src.Equals("dag"))
                return new LlvmDataType(src, LlvmDataKind.Dag);
            else if(src.StartsWith("bits"))
                return new LlvmDataType(src, LlvmDataKind.Bits);
            else if(src.StartsWith("list"))
                return new LlvmDataType(src, LlvmDataKind.List);
            else
                return new LlvmDataType(src,0);
        }

        public LlvmDataKind Kind {get;}

        public Identifier Decl {get;}

        [MethodImpl(Inline)]
        public LlvmDataType(Identifier decl, LlvmDataKind kind)
        {
            Decl = decl;
            Kind = kind;
        }

        public bool IsParametric
            => Decl.Content.Contains(Chars.Lt) && Decl.Content.Contains(Chars.Gt);

        public bool IsKnown
            => Kind != 0;

        public bool IsBits
            => Kind == LlvmDataKind.Bits;

        public bool IsBit
            => Kind == LlvmDataKind.Bit;

        public bool IsString
            => Kind == LlvmDataKind.String;

        public bool IsInt
            => Kind == LlvmDataKind.Int;

        public bool IsDag
            => Kind == LlvmDataKind.Dag;

        public bool TypeArgs(out string dst)
            => text.unfence(Decl, (Chars.Lt, Chars.Gt), out dst);

        public bool Equals(LlvmDataType src)
            => Kind == src.Kind && Decl.Equals(src.Decl);

        public override int GetHashCode()
            => (int)alg.hash.combine((uint)Kind, (uint)Decl.GetHashCode());

        public override bool Equals(object src)
            => src is LlvmDataType t && Equals(t);

        public string Format()
        {
            if(IsParametric)
            {
                if(TypeArgs(out var args))
                    return string.Format("{0}:{1}<{2}>", Decl.Name, Kind, args);
                else
                    return string.Format("{0}:{1}<error>", Decl.Name, Kind);
            }
            else
            {
                return string.Format("{0}:{1}", Decl.Name, Kind);
            }
        }

        public override string ToString()
            => Format();
   }
}
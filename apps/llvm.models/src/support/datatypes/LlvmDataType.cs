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
                return new LlvmDataType(src, LlvmTypeKind.Bit);
            else if(src.Equals("string"))
                return new LlvmDataType(src, LlvmTypeKind.String);
            else if(src.Equals("int"))
                return new LlvmDataType(src, LlvmTypeKind.Int);
            else if(src.Equals("dag"))
                return new LlvmDataType(src, LlvmTypeKind.Dag);
            else if(src.StartsWith("bits"))
                return new LlvmDataType(src, LlvmTypeKind.Bits);
            else if(src.StartsWith("list"))
                return new LlvmDataType(src, LlvmTypeKind.List);
            else if(src.StartsWith("names"))
                return new LlvmDataType(src, LlvmTypeKind.NameList);
            else
                return new LlvmDataType(src,0);
        }

        public LlvmTypeKind Kind {get;}

        public Identifier Decl {get;}

        [MethodImpl(Inline)]
        public LlvmDataType(Identifier decl, LlvmTypeKind kind)
        {
            Decl = decl;
            Kind = kind;
        }

        public bool IsParametric
            => Decl.Content.Contains(Chars.Lt) && Decl.Content.Contains(Chars.Gt);

        public bool IsKnown
            => Kind != 0;

        public bool IsBits
            => Kind == LlvmTypeKind.Bits;

        public bool IsBit
            => Kind == LlvmTypeKind.Bit;

        public bool IsString
            => Kind == LlvmTypeKind.String;

        public bool IsInt
            => Kind == LlvmTypeKind.Int;

        public bool IsDag
            => Kind == LlvmTypeKind.Dag;

        public bool IsNameList
            => Kind == LlvmTypeKind.NameList;

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
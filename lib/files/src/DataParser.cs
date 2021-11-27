//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata.Ecma335;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [ApiHost]
    public readonly struct DataParser
    {
        public static MsgPattern<Name,string> ParseFailure => "Parse failure {0}:{1}";

        public static Outcome parse(string src, out LineInterval<Identifier> dst)
            => LineInterval.parse(src, out dst);

        public static Outcome parse(TextLine src, out SymLiteralRow dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = src.Split(Chars.Pipe);
            if(cells.Length != SymLiteralRow.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            outcome += parse(skip(cells,j++), out dst.Component);
            outcome += parse(skip(cells,j++), out dst.Type);
            outcome += parse(skip(cells,j++), out dst.Class);
            outcome += parse(skip(cells,j++), out dst.Position);
            outcome += parse(skip(cells,j++), out dst.Name);
            outcome += parse(skip(cells,j++), out dst.Symbol);
            outcome += eparse(skip(cells,j++), out dst.DataType);
            outcome += parse(skip(cells,j++), out dst.ScalarValue);
            outcome += parse(skip(cells,j++), out dst.Hidden);
            outcome += parse(skip(cells,j++), out dst.Description);
            outcome += parse(skip(cells,j++), out dst.Identity);
            return outcome;
        }

        public static Outcome parse(TextLine src, out SymInfo dst)
        {
            var outcome = Outcome.Success;
            var j=0;
            var cells = src.Split(Chars.Pipe);
            if(cells.Length != SymInfo.FieldCount)
            {
                dst = default;
                return (false, AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, cells.Length));
            }

            outcome += parse(skip(cells,j++), out dst.TokenType);
            outcome += parse(skip(cells,j++), out dst.Index);
            outcome += parse(skip(cells,j++), out dst.Value);
            outcome += parse(skip(cells,j++), out dst.Name);
            outcome += parse(skip(cells,j++), out dst.Expr);
            outcome += parse(skip(cells,j++), out dst.Description);
            return outcome;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out SymKey dst)
        {
            dst = default;
            var result = parse(src, out uint x);
            if(result)
                dst = x;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out SymVal dst)
        {
            dst = default;
            var result = parse(src, out ulong x);
            if(result)
                dst = x;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out SymClass dst)
        {
            dst = new SymClass(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out LineNumber dst)
            => LineNumber.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out byte dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out sbyte dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out short dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out ushort dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out int dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out uint dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out long dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out ulong dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out float dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out double dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Hex8 dst)
            => Hex8.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Hex16 dst)
            => Hex16.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Hex32 dst)
        {
            var outcome = Hex.parse32u(src, out var x);
            dst = x;
            return outcome;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Hex64 dst)
        {
            var outcome = Hex.parse64u(src, out var x);
            dst = x;
            return outcome;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out bool dst)
        {
            dst = default;
            var result = BitParser.semantic(src, out var b);
            if(result)
                dst = b;
            return result;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out bit dst)
            => bit.parse(src, out dst);

        [MethodImpl(Inline)]
        public static Outcome numeric<T>(string src, out T dst)
            => NumericParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Timestamp dst)
            => Time.parse(src,out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out DateTime dst)
            => DateTime.TryParse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Name dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out utf8 dst)
        {
            dst = src ?? utf8.Empty;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Identifier dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out SymIdentity dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out TextBlock dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out MemoryAddress dst)
            => AddressParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Address64 dst)
            => AddressParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Address32 dst)
            => AddressParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Address16 dst)
            => AddressParser.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out Address8 dst)
            => AddressParser.parse(src, out dst);

        [MethodImpl(Inline)]
        public static Outcome eparse<T>(string src, out T dst)
            where T : unmanaged
                => Enums.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out ByteSize dst)
            => Sizes.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out BitWidth dst)
            => Sizes.parse(src, out dst);

        [MethodImpl(Inline)]
        public static Outcome parse<T>(string src, out Size<T> dst)
            where T : unmanaged
                => Sizes.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out string dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out SymExpr dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out ClrMemberName dst)
        {
            dst = Clr.membername(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out FS.FileName dst)
        {
            dst = FS.file(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out FS.FolderPath dst)
        {
            dst = FS.dir(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out FS.FilePath dst)
        {
            dst = FS.path(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out FS.FileExt dst)
        {
            dst = FS.ext(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out FS.FileUri dst)
        {
            dst = FS.path(src);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out BinaryCode dst)
        {
            var result = Hex.hexdata(src, out var data);
            if(result)
            {
                dst = data;
                return result;
            }
            else
            {
                dst = BinaryCode.Empty;
                return result;
            }
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out OpUri dst)
            => ApiUri.parse(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out CliToken dst)
        {
            var i = text.index(src, Chars.Colon);
            var outcome = Outcome.Empty;
            dst = CliToken.Empty;
            if(i != NotFound)
            {
                outcome = Hex.parse8u(src.LeftOfIndex(i), out var table);
                if(!outcome)
                    return outcome;

                outcome = Hex.parse32u(text.right(src,i), out var row);
                if(!outcome)
                    return outcome;

                dst = Clr.token((TableIndex)table, row);
                return true;
            }
            else
            {
                outcome = Hex.parse32u(src, out var token);
                if(!outcome)
                    return outcome;
                dst = token;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out MemoryRange dst)
            => AddressParser.range(src, out dst);

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out ToolId dst)
        {
            dst = src;
            return true;
        }

        public static Outcome parse(string src, out Setting<string> dst)
        {
            if(sys.empty(src))
            {
                dst = default;
                return (false, "!!Empty!!");
            }
            else
            {
                var i = src.IndexOf(Chars.Colon);
                if(i == NotFound)
                {
                    dst = default;
                    return (false, "Setting delimiter not found");
                }
                else
                {
                    if(i == 0)
                        dst = new Setting<string>(EmptyString, text.slice(src,i+1));
                    else
                        dst = new Setting<string>(text.slice(src,0, i), text.slice(src,i+1));
                    return true;
                }
            }
        }

        [MethodImpl(Inline)]
        public static Outcome block<T>(string src, out T block)
            where T : unmanaged, ICharBlock<T>
        {
            block = default;
            CharBlocks.init(src, out block);
            return true;
        }

        public static Outcome numeric(string src, Type type, out dynamic dst)
        {
            Outcome result = (false, string.Format("The {0} type is unsupported", type.Name));
            dst = 0;
            if(type.IsUInt8())
            {
                result = parse(src, out byte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt8())
            {
                result = parse(src, out sbyte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt16())
            {
                result = parse(src, out short x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt16())
            {
                result = parse(src, out ushort x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt32())
            {
                result = parse(src, out uint x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt32())
            {
                result = parse(src, out int x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt64())
            {
                result = parse(src, out ulong x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt64())
            {
                result = parse(src, out long x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat32())
            {
                result = parse(src, out float x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat64())
            {
                result = parse(src, out double x);
                if(result)
                    dst = x;
            }
            return result;
        }

        public static Outcome setting(string src, Type type, out Setting dst, char delimiter = Chars.Colon)
        {
            dst = Settings.empty();
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, delimiter))
                {
                    name = src.LeftOfFirst(delimiter);
                    input = src.RightOfFirst(delimiter);
                }

                if(type == typeof(string))
                {
                    dst = (name, input);
                    return true;
                }
                else if (type == typeof(bool))
                {
                    if(parse(input, out bool value))
                    {
                        dst = (name, value);
                        return true;
                    }
                }
                else if(type == typeof(bit))
                {
                    if(parse(input, out bit u1))
                    {
                        dst = (name, u1);
                        return true;
                    }
                }
                else if(type.IsPrimalNumeric())
                {
                    if(numeric(input, type, out var n))
                    {
                        dst = (name,n);
                        return true;
                    }
                }
                else if(type.IsEnum)
                {
                    if(Enums.parse(type, src, out object o))
                    {
                        dst = (name, o);
                        return true;
                    }
                }
                else if(src.Length == 1 && type == typeof(char))
                {
                    dst = (name, name[0]);
                    return true;
                }
            }
            return false;
        }

        [MethodImpl(Inline)]
        public static Outcome setting<T>(string src, out Setting<T> dst, char delimiter = Chars.Colon)
        {
            dst = Settings.empty<T>();
            if(nonempty(src))
            {
                var name = EmptyString;
                var input = src;
                if(SQ.contains(src, delimiter))
                {
                    name = src.LeftOfFirst(delimiter);
                    input = src.RightOfFirst(delimiter);
                }

                if(typeof(T) == typeof(string))
                {
                    dst = (name, generic<T>(input));
                    return true;
                }
                else if (typeof(T) == typeof(bool))
                {
                    if(parse(input, out bool value))
                    {
                        dst = (name, generic<T>(value));
                        return true;
                    }
                }
                else if(typeof(T) == typeof(bit))
                {
                    if(parse(input, out bit u1))
                    {
                        dst = (name, generic<T>((bool)u1));
                        return true;
                    }
                }
                else if(numeric(input, out T g))
                {
                    dst = (name, g);
                    return true;
                }
                else if(typeof(T).IsEnum)
                {
                    if(Enums.parse(typeof(T), src, out object o))
                    {
                        dst = (name, (T)o);
                        return true;
                    }
                }
                else if(src.Length == 1 && typeof(T) == typeof(char))
                {
                    dst = (name, generic<T>(name[0]));
                    return true;
                }
            }
            return false;
        }
     }
}
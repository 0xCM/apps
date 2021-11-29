//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Text;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct JsonText : ITextual, IContented<string>
    {
        public string Content {get;}

        [MethodImpl(Inline)]
        public JsonText(string src)
            => Content = src;

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public string Unescape()
        {
            if(unescape(Content, out var escaped))
                return escaped;
            else
                return EmptyString;
        }
        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Content.GetHashCode();
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content?.Length ?? 0;
        }

        [MethodImpl(Inline)]
        public static implicit operator JsonText(string src)
            => new JsonText(src);

        [MethodImpl(Inline)]
        public static implicit operator string(JsonText src)
            => src.Content;

       public static JsonText Empty
           => new JsonText(EmptyString);

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        /// <param name="src">The json input</param>
        /// <param name="dst">Receives the unescaped text, if successful</param>
        static Outcome unescape(string src, out string dst)
        {
            dst = EmptyString;
            var result = Outcome.Success;
            if(src == null)
                return Outcome.fail(RP.Null);

            var buffer = new StringBuilder();
            int startIndex = 0, count = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == '\\')
                {
                    i++;

                    buffer.Append(src, startIndex, count);

                    if (i >= src.Length)
                    {
                        result = Outcome.fail(string.Format("{0}>={1}", i, src.Length));
                        break;
                    }

                    switch (src[i])
                    {
                        case '"':
                        case '\'':
                        case '/':
                        case '\\':
                            buffer.Append(src[i]);
                            break;
                        case 'b':
                            buffer.Append('\b');
                            break;
                        case 'f':
                            buffer.Append('\f');
                            break;
                        case 'n':
                            buffer.Append('\n');
                            break;
                        case 'r':
                            buffer.Append('\r');
                            break;
                        case 't':
                            buffer.Append('\t');
                            break;
                        case 'u':
                            if ((i + 3) >= src.Length)
                            {
                                result = Outcome.fail(string.Format("{0} + 3 >={1}", i, src.Length));
                                break;
                            }

                            result = ParseChar(src.Substring(i + 1, 4), NumberStyles.HexNumber, out var c);
                            if(result)
                                buffer.Append(c);
                            else
                                break;
                            i += 4;
                            break;
                    }
                    startIndex = i + 1;
                    count = 0;
                }
                else
                    count++;
            }

            if(count > 0)
                buffer.Append(src, startIndex, count);

            dst = buffer.ToString();
            return result;
        }

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        static Outcome ParseChar(string src, NumberStyles style, out char dst)
        {
            var result = ParseInt(src, style, out var value);
            try
            {
                dst = Convert.ToChar(value);
                return true;
            }
            catch(Exception e)
            {
                dst = (char)0;
                return e;
            }
        }

        /// <summary>
        /// Adapted from https://github.com/dotnet/runtime/blob/36697a52c89caedd014b255695eae2058a9b0546/src/libraries/System.Private.DataContractSerialization/src/System/Runtime/Serialization/Json/XmlJsonReader.cs
        /// </summary>
        static Outcome ParseInt(string value, NumberStyles style, out int dst)
        {
            dst = default;
            try
            {
                dst = int.Parse(value, style, NumberFormatInfo.InvariantInfo);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }
    }
}
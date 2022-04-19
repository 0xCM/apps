//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial struct term
    {
        /// <summary>
        /// Writes specified content to the terminal using the current color scheme
        /// </summary>
        /// <param name="msg">The message to emit</param>
        public static void write(string msg)
            => T.Write(msg);

        /// <summary>
        /// Writes specified content to the terminal using the current color scheme
        /// </summary>
        /// <param name="msg">The message to emit</param>
        /// <param name="color">The emission color</param>
        public static void write(string msg, FlairKind color)
            => T.Write(msg, color);

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        public static void print()
            => T.WriteLine();

        /// <summary>
        /// Writes a colorized message to the console
        /// </summary>
        /// <param name="message">The message text</param>
        /// <param name="color">The emission color</param>
        public static void print(string message, FlairKind color)
            => T.WriteLine(message, color);

        /// <summary>
        /// Writes a single messages to the terminal
        /// </summary>
        /// <param name="msg">The message to print</param>
        public static void print(IAppMsg msg)
            => T.WriteMessage(msg);

        /// <summary>
        /// Writes a single messages to the terminal
        /// </summary>
        /// <param name="msg">The message to print</param>
        public static void print(IAppMsg msg, FlairKind color)
            => T.WriteMessage(msg, color);

        /// <summary>
        /// Writes a single messages to the terminal
        /// </summary>
        /// <param name="msg">The message to print</param>
        public static void print(AppMsg msg)
            => T.WriteMessage(msg);

        /// <summary>
        /// Writes a single line to the terminal
        /// </summary>
        /// <param name="content">The message to print</param>
        public static void print(object content)
            => T.WriteLine(content);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print<F>(F src, FlairKind color)
            where F : ITextual
                => T.WriteLine(src, color);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print<F>(F src)
            where F : ITextual
                => T.WriteLine(src, FlairKind.Status);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print(IAppEvent e)
            => T.WriteLine(e.Format(), e.Flair);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print<F>(params F[] src)
            where F : ITextual
                => T.WriteLines(src);

        /// <summary>
        /// Writes formattables to the console in a contiguous block using a specified foreground color
        /// </summary>
        /// <param name="color">The message foreground color</param>
        /// <param name="content">The content to print</param>
        public static void print<F>(FlairKind color, params F[] content)
            where F : ITextual
                => T.WriteLines(color,content);

        /// <summary>
        /// Prints a sequence of messages in an unbroken block
        /// </summary>
        /// <param name="content">The messages to print</param>
        public static void print(IEnumerable<IAppMsg> content)
            => T.WriteMessages(content);
    }
}
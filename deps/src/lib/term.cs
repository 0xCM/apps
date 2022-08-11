//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Lib
{
    class term
    {
        static readonly Terminal T = Terminal.service;

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        public static void print()
            => T.WriteLine();

        /// <summary>
        /// Write a parametric message to standard out
        /// </summary>
        /// <param name="msg"></param>
        /// <typeparam name="M"></typeparam>
        public static void print<M>(M msg)
            => T.WriteLine(msg);
    }
}
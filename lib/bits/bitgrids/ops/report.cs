//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid16<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid32<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid64<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid128<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(BitGrid256<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid16<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid32<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid64<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N>(g.Content, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid128<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Formats a grid with a title and the option to display row indices
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static string report<M,N,T>(SubGrid256<M,N,T> g, bool showrow = false, [CallerMemberName] string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => report<M,N,T>(g.Data, showrow, label);

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(ushort data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.lines(title(label, n16, default(M), default(N), default(ushort)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(uint data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.lines(title(label, n32, default(M), default(N), default(uint)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N>(ulong data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
                => text.lines(title(label, n64, default(M), default(N), default(ulong)), HeaderSep, format<M,N>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N,T>(Vector128<T> data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => text.lines(title(label, n128, default(M), default(N), default(T)), HeaderSep, format<M,N,T>(data,showrow));

        /// <summary>
        /// Renders grid data
        /// </summary>
        /// <param name="g">The grid to render</param>
        /// <param name="showrow">Whether grid row indices should be displayed</param>
        /// <param name="label">The grid label</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        static string report<M,N,T>(Vector256<T> data, bool showrow = false, string label = null)
            where M: unmanaged, ITypeNat
            where N: unmanaged, ITypeNat
            where T: unmanaged
                => text.lines(title(label, n256, default(M), default(N), default(T)), HeaderSep, format<M,N,T>(data,showrow));
    }
}
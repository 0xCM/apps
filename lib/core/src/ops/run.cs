//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Runs a task that executes a specified worker
        /// </summary>
        /// <param name="worker">The worker to execute</param>
        [MethodImpl(Inline), Op]
        public static Task run(Action worker)
            => Task.Run(worker);

        /// <summary>
        /// Runs a task that executes a specified worker
        /// </summary>
        /// <param name="worker">The worker to execute</param>
        [MethodImpl(Inline), Op]
        public static Task run(Action worker, CancellationToken ct)
            => Task.Run(worker, ct);

        /// <summary>
        /// Runs a task that computes a result
        /// </summary>
        /// <param name="f">The emitter</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Task<T> run<T>(Func<T> f)
            => Task.Run(f);

        /// <summary>
        /// Asyncronously executes a transformation
        /// </summary>
        /// <param name="f">The transformer</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Task<T> run<S,T>(Func<S,T> f, S src)
            => Task.Factory.StartNew(o => f((S)o), src);
    }
}
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Events
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static BufferedProjector<T> projector<T>(IPipeline pipeline)
            => projector(pipeline, new Queue<T>(), new SFxProjector<T>(identity));

        [Op, Closures(Closure)]
        public static BufferedProjector<T> projector<T>(IPipeline pipes, ISFxProjector<T> sfx)
            => projector(pipes, new Queue<T>(), sfx);

        public static BufferedProjector<S,T> projector<S,T>(IPipeline pipes, ISFxProjector<S,T> sfx)
            => projector<S,T>(pipes, new Queue<S>(), sfx);

        [MethodImpl(Inline)]
        internal static BufferedProjector<S,T> projector<S,T>(IPipeline pipes, Queue<S> buffer, ISFxProjector<S,T> fx)
            => new BufferedProjector<S,T>(pipes, buffer, fx);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static BufferedProjector<T> projector<T>(IPipeline pipes, Queue<T> buffer, ISFxProjector<T> projector)
            => new BufferedProjector<T>(pipes, buffer, projector);

        public static SpanProjector<S,T> projector<S,T>(IPipeline pipes, ISpanMap<S,T> map)
            => SpanProjector<S,T>.create(pipes).With(map);

        static T identity<T>(T src)
            => src;

        [Op, Closures(Closure)]
        public static void transmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<IReceiver<T>> dst)
        {
            var kSources = src.Length;
            var kTargets = dst.Length;
            for(var i=0; i<kSources; i++)
            {
                ref readonly var input = ref skip(src,i);
                for(var j=0; j<kTargets; j++)
                    skip(dst,j).Deposit(input);
            }
        }

        [Op, Closures(Closure)]
        public static uint transmit<T>(BufferedProjector<T> src, BufferedProjector<T> dst)
        {
            var count = 0u;
            while(src.Emit(out var cell))
            {
                dst.Deposit(cell);
                count++;
            }
            return count;
        }

        [Op, Closures(Closure)]
        public static uint transmit<T>(ReadOnlySpan<T> src, BufferedProjector<T> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                dst.Deposit(skip(src,i));
            return count;
        }

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='Receiver{T}'/>
        /// </summary>
        /// <param name="dst">The target receiver</param>
        /// <typeparam name="T">The reception type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Sink<T> sink<T>(Receiver<T> dst)
            => new Sink<T>(dst);

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='StreamWriter'/>
        /// </summary>
        /// <param name="dst">The target writer</param>
        /// <typeparam name="T">The reception type</typeparam>
        public static Sink<T> sink<T>(StreamWriter dst)
        {
            void Target(in T src) => dst.WriteLine(src);
            return new Sink<T>(Target);
        }

        /// <summary>
        /// Creates a <see cref='Sink{T}'/> from a <see cref='StreamWriter'/>
        /// </summary>
        /// <param name="dst">The target writer</param>
        /// <typeparam name="T">The reception type</typeparam>
        public static Sink<T> sink<T>(FileStream dst)
        {
            void Target(in T src)
                => FS.write(src?.ToString() ?? EmptyString, dst);

            return new Sink<T>(Target);
        }
    }
}
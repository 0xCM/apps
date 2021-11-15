//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.Extensions.DependencyModel;
    using System.Reflection;
    using System.Text;
    using System.IO;

    using static JsonDepsBuilder;
    using static JsonDepsModel;

    public readonly struct JsonDepsLoader
    {
        public static FS.FileExt Ext => FS.ext("deps", "json");

        [Op]
        public static JsonText json(Assembly src)
        {
            var path = FS.path(src.Location).ChangeExtension(Ext);
            return path.ReadText();
        }

        [Op]
        public static JsonDeps from(FS.FilePath src)
            => new JsonDeps(context(src.ReadText()));

        internal static ref RuntimeLibraryInfo extract(RuntimeLibrary src, ref RuntimeLibraryInfo dst)
        {
            dst.AssemblyGroups = sys.alloc<AssetGroupInfo>(src.RuntimeAssemblyGroups.Count);
            for(var i=0; i<dst.AssemblyGroups.Count; i++)
                extract(src.RuntimeAssemblyGroups[i], ref dst.AssemblyGroups[i]);

            dst.NativeLibraries = sys.alloc<AssetGroupInfo>(src.NativeLibraryGroups.Count);
            for(var i=0; i<dst.NativeLibraries.Count; i++)
                extract(src.NativeLibraryGroups[i], ref dst.NativeLibraries[i]);

            dst.ResourceAssemblies = sys.alloc<JsonDepsModel.ResourceAssembly>(src.ResourceAssemblies.Count);
            for(var i=0; i<dst.ResourceAssemblies.Count; i++)
            {

                ref var target = ref dst.ResourceAssemblies[i];
                target.Path = FS.path(src.ResourceAssemblies[i].Path);
                target.Locale = src.ResourceAssemblies[i].Locale;
            }


            return ref dst;
        }

        internal static ref AssetGroupInfo extract(RuntimeAssetGroup src, ref AssetGroupInfo dst)
        {
            dst.Runtime = src.Runtime;
            dst.AssetPaths = src.AssetPaths.Map(FS.path);
            var count = src.RuntimeFiles.Count;
            dst.RuntimeFiles = sys.alloc<RuntimeFileInfo>(count);
            for(var i=0; i<count; i++)
                extract(src.RuntimeFiles[i], ref dst.RuntimeFiles[i]);
            return ref dst;
        }

        internal static ref RuntimeFileInfo extract(RuntimeFile src, ref RuntimeFileInfo dst)
        {
            dst.AssemblyVersion = src.AssemblyVersion;
            dst.FileVersion = src.FileVersion;
            dst.Path = FS.path(src.Path);
            return ref dst;
        }


        [Op]
        public static JsonDeps from(JsonText src)
            => new JsonDeps(context(src));

        [Op]
        public static JsonDeps from(Assembly src)
            => new JsonDeps(DependencyContext.Load(src));

        [Op]
        internal static LibraryDependency[] dependencies(CompilationLibrary src)
            => src.Dependencies.Map(d => lib(d.Name, d.Version));

        [Op]
        internal static ref JsonDepsModel.TargetInfo extract(DependencyContext context, ref JsonDepsModel.TargetInfo dst)
        {
            var src = context.Target;
            dst.Framework = src.Framework;
            dst.IsPortable = src.IsPortable;
            dst.Runtime = src.Runtime;
            dst.RuntimeSignature = src.RuntimeSignature;
            return ref dst;
        }

        [Op]
        internal static ref LibraryInfo extract(CompilationLibrary src, ref LibraryInfo dst)
        {
            dst.Name = src.Name;
            dst.Dependencies = dependencies(src);
            dst.Assemblies = src.Assemblies.Array();
            dst.Type = src.Type;
            dst.Path = FS.path(src.Path);
            dst.Version = src.Version;
            dst.Hash = src.Hash;
            dst.Serviceable = src.Serviceable;
            dst.HashPath = src.HashPath;
            dst.RuntimeStoreManifestName = src.RuntimeStoreManifestName;
            dst.ReferencePaths = src.ResolveReferencePaths().Map(FS.path);
            return ref dst;
        }

        [Op]
        internal static ref Options extract(CompilationOptions src, ref Options dst)
        {
            dst.AllowUnsafe = src.AllowUnsafe;
            dst.DebugType = src.DebugType;
            dst.Defines = src.Defines.Array();
            dst.DelaySign = src.DelaySign;
            dst.EmitEntryPoint = src.EmitEntryPoint;
            dst.GenerateXmlDocumentation = src.GenerateXmlDocumentation;
            dst.KeyFile = src.KeyFile;
            dst.LanguageVersion = src.LanguageVersion;
            dst.Optimize = src.Optimize;
            dst.Platform = src.Platform;
            dst.PublicSign = src.PublicSign;
            dst.WarningsAsErrors = src.WarningsAsErrors;
            return ref dst;
        }

        internal static DependencyContext context(JsonText src)
        {
            var encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
            using(var stream = new MemoryStream(Encoding.UTF8.GetMaxByteCount(src.Length)))
            using(var writer = new StreamWriter(stream, encoding))
            {
                writer.Write(src.Content);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using var reader = new DependencyContextJsonReader();
                return reader.Read(stream);
            }
        }
    }

    public readonly partial struct JsonDepsModel
    {

    }
}
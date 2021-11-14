// using System;
// using System.Reflection;
// using System.IO;
// using System.Text;

// readonly struct App
// {
//     static Assembly EntryAssembly = typeof(App).Assembly;

//     static string[] ResourceNames()
//         => EntryAssembly.GetManifestResourceNames();

//     static StringBuilder FormatBuffer()
//         => new StringBuilder(8*1024);

//     static Stream ResourceStream(string name)
//         => EntryAssembly.GetManifestResourceStream(name);

//     static BinaryReader ResourceReader(Stream src)
//         => new BinaryReader(src);

//     static byte[] ReadBytes(BinaryReader src, long count)
//         => src.ReadBytes((int)count);

//     static void Show()
//     {
//         var names = ResourceNames();
//         var buffer = FormatBuffer();

//         foreach(var name in names)
//         {
//             buffer.Clear();
//             using var stream = ResourceStream(name);
//             using var reader = ResourceReader(stream);
//             render(name, ReadBytes(reader, stream.Length), buffer);
//             Console.WriteLine(buffer.ToString());
//         }
//     }

//     static void EmitFile(string dst)
//     {
//         var names = ResourceNames();
//         var buffer = FormatBuffer();
//         var count = names.Length;
//         using var writer = new StreamWriter(dst);
//         for(var i=0; i<count; i++)
//         {
//             var name = names[i];
//             buffer.Clear();
//             using var stream = ResourceStream(name);
//             using var reader = ResourceReader(stream);
//             var data = ReadBytes(reader, stream.Length);
//             buffer.AppendFormat("{0,-10} | {1,-36} | ", i, name);
//             RenderHexText(data,buffer);
//             writer.WriteLine(buffer.ToString());
//         }
//     }

//     static void RenderHexText(ReadOnlySpan<byte> src, StringBuilder dst)
//     {
//         var count = src.Length;
//         for(var i=0; i<count; i++)
//             dst.Append(string.Format("{0} ", src[i].ToString("x")));
//     }

//     static void render(string name, ReadOnlySpan<byte> src, StringBuilder dst)
//     {
//         dst.AppendLine(new string('-',120));
//         dst.AppendLine(name);
//         var length = src.Length;
//         for(var i=0; i<length; i++)
//         {
//             dst.Append(string.Format("{0} ", src[i].ToString("x")));
//             if(i != 0 && i % 80 == 0)
//                 dst.AppendLine();
//         }

//     }

//     static long Show(string resname)
//     {
//         using var stream = EntryAssembly.GetManifestResourceStream(resname);
//         using var reader = new BinaryReader(stream);
//         var length = stream.Length;
//         var data = reader.ReadBytes((int)length);
//         var target = new StringBuilder(data.Length);
//         var j = 0;
//         target.AppendLine(resname);
//         target.AppendLine(new string('-',120));
//         for(var i=0; i<length; i++, j++)
//         {
//             target.Append(string.Format("{0} ", data[i].ToString("x")));
//             if(j != 0 && j % 80 == 0)
//             {
//                 target.AppendLine();
//                 j = 0;
//             }
//         }
//         Console.WriteLine(target.ToString());
//         return length;

//     }

//     public static int Main(string[] args)
//     {
//         var path = @"J:\database\tables\indices\bytecode.csv";
//         EmitFile(path);
//         return 0;
//     }
// }

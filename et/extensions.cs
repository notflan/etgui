//#define FORMS
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

#if FORMS
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endif

namespace Tools
{
    namespace ByValStrings
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString1
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
            public string cstring;

            public ByValANSIString1(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString1(string s)
            {
                return new ByValANSIString1(s);
            }

            public static explicit operator string(ByValANSIString1 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString2
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string cstring;

            public ByValANSIString2(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString2(string s)
            {
                return new ByValANSIString2(s);
            }

            public static explicit operator string(ByValANSIString2 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString4
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string cstring;

            public ByValANSIString4(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString4(string s)
            {
                return new ByValANSIString4(s);
            }

            public static explicit operator string(ByValANSIString4 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString8
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            public string cstring;

            public ByValANSIString8(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString8(string s)
            {
                return new ByValANSIString8(s);
            }

            public static explicit operator string(ByValANSIString8 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString16
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string cstring;

            public ByValANSIString16(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString16(string s)
            {
                return new ByValANSIString16(s);
            }

            public static explicit operator string(ByValANSIString16 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString32
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string cstring;

            public ByValANSIString32(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString32(string s)
            {
                return new ByValANSIString32(s);
            }

            public static explicit operator string(ByValANSIString32 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString64
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string cstring;

            public ByValANSIString64(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString64(string s)
            {
                return new ByValANSIString64(s);
            }

            public static explicit operator string(ByValANSIString64 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString128
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string cstring;

            public ByValANSIString128(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString128(string s)
            {
                return new ByValANSIString128(s);
            }

            public static explicit operator string(ByValANSIString128 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString256
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string cstring;

            public ByValANSIString256(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString256(string s)
            {
                return new ByValANSIString256(s);
            }

            public static explicit operator string(ByValANSIString256 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString512
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string cstring;

            public ByValANSIString512(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString512(string s)
            {
                return new ByValANSIString512(s);
            }

            public static explicit operator string(ByValANSIString512 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString1024
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string cstring;

            public ByValANSIString1024(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString1024(string s)
            {
                return new ByValANSIString1024(s);
            }

            public static explicit operator string(ByValANSIString1024 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString2048
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
            public string cstring;

            public ByValANSIString2048(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString2048(string s)
            {
                return new ByValANSIString2048(s);
            }

            public static explicit operator string(ByValANSIString2048 s)
            {
                return s.cstring;
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValANSIString4096
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
            public string cstring;

            public ByValANSIString4096(string c)
            {
                this.cstring = c;
            }

            public static implicit operator ByValANSIString4096(string s)
            {
                return new ByValANSIString4096(s);
            }

            public static explicit operator string(ByValANSIString4096 s)
            {
                return s.cstring;
            }
        }
    }
    namespace ByValData
    {
        namespace Special
        {
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ByValSHA1Hash
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.U1)]
                public byte[] data;

                public ByValSHA1Hash(byte[] c)
                {
                    this.data = c.Pad<byte>(20);
                }

                public static implicit operator ByValSHA1Hash(byte[] s)
                {
                    return new ByValSHA1Hash(s);
                }

                public static explicit operator byte[] (ByValSHA1Hash s)
                {
                    return s.data;
                }
            }
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray1
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray1(byte[] c)
            {
                this.data = c.Pad<byte>(1);
            }

            public static implicit operator ByValFixedByteArray1(byte[] s)
            {
                return new ByValFixedByteArray1(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray1 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray2
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray2(byte[] c)
            {
                this.data = c.Pad<byte>(2);
            }

            public static implicit operator ByValFixedByteArray2(byte[] s)
            {
                return new ByValFixedByteArray2(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray2 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray4
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray4(byte[] c)
            {
                this.data = c.Pad<byte>(4);
            }

            public static implicit operator ByValFixedByteArray4(byte[] s)
            {
                return new ByValFixedByteArray4(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray4 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray8
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray8(byte[] c)
            {
                this.data = c.Pad<byte>(8);
            }

            public static implicit operator ByValFixedByteArray8(byte[] s)
            {
                return new ByValFixedByteArray8(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray8 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray16
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray16(byte[] c)
            {
                this.data = c.Pad<byte>(16);
            }

            public static implicit operator ByValFixedByteArray16(byte[] s)
            {
                return new ByValFixedByteArray16(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray16 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray32
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray32(byte[] c)
            {
                this.data = c.Pad<byte>(32);
            }

            public static implicit operator ByValFixedByteArray32(byte[] s)
            {
                return new ByValFixedByteArray32(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray32 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray64
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray64(byte[] c)
            {
                this.data = c.Pad<byte>(64);
            }

            public static implicit operator ByValFixedByteArray64(byte[] s)
            {
                return new ByValFixedByteArray64(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray64 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray128
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray128(byte[] c)
            {
                this.data = c.Pad<byte>(128);
            }

            public static implicit operator ByValFixedByteArray128(byte[] s)
            {
                return new ByValFixedByteArray128(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray128 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray256
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray256(byte[] c)
            {
                this.data = c.Pad<byte>(256);
            }

            public static implicit operator ByValFixedByteArray256(byte[] s)
            {
                return new ByValFixedByteArray256(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray256 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray512
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray512(byte[] c)
            {
                this.data = c.Pad<byte>(512);
            }

            public static implicit operator ByValFixedByteArray512(byte[] s)
            {
                return new ByValFixedByteArray512(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray512 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray1024
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray1024(byte[] c)
            {
                this.data = c.Pad<byte>(1024);
            }

            public static implicit operator ByValFixedByteArray1024(byte[] s)
            {
                return new ByValFixedByteArray1024(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray1024 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray2048
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray2048(byte[] c)
            {
                this.data = c.Pad<byte>(2048);
            }

            public static implicit operator ByValFixedByteArray2048(byte[] s)
            {
                return new ByValFixedByteArray2048(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray2048 s)
            {
                return s.data;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ByValFixedByteArray4096
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096, ArraySubType = UnmanagedType.U1)]
            public byte[] data;

            public ByValFixedByteArray4096(byte[] c)
            {
                this.data = c.Pad<byte>(4096);
            }

            public static implicit operator ByValFixedByteArray4096(byte[] s)
            {
                return new ByValFixedByteArray4096(s);
            }

            public static explicit operator byte[] (ByValFixedByteArray4096 s)
            {
                return s.data;
            }
        }



    }

    public static class Extensions
    {
        public static void Shuffle<T>(this T[] t, Random r)
        {
            int num = ((IEnumerable<T>)t).Count<T>();
            for (int i = num - 1; i > 0; --i)
                t.Swap<T>(i, r.Next(0, num - 1));
        }

        public static void Swap<T>(this T[] t, int i, int j)
        {
            T obj = t[i];
            t[i] = t[j];
            t[j] = obj;
        }

        public static IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> t)
        {
            List<T> objList = new List<T>();
            foreach (T obj in t)
            {
                if (!objList.Contains(obj))
                    objList.Add(obj);
            }
            return (IEnumerable<T>)objList.ToArray();
        }

        public static bool ContainsAny(this string t, string[] o)
        {
            foreach (string str in o)
            {
                if (t.Contains(str))
                    return true;
            }
            return false;
        }

        public static bool AllValidTypes(this object[] objs, params Type[] t)
        {
            if (objs.Length != t.Length)
                return false;
            for (int index = 0; index < objs.Length; ++index)
            {
                if (!objs[index].GetType().Equals(t[index]))
                    return false;
            }
            return true;
        }

        public static void Shred(this FileInfo fi)
        {
            fi.Shred(true);
        }

        public static void Shred(this FileInfo fi, bool delete)
        {
            fi.Shred(delete, 3);
        }

        public static void Shred(this FileInfo fi, bool delete, int passes)
        {
            fi.Shred(delete, passes, 4096L);
        }

        public static double ToUnixTime(this DateTime d)
        {
            return (d.ToUniversalTime() - new DateTime(1970, 1, 1).ToUniversalTime()).TotalSeconds;
        }

        public static void Shred(this FileInfo fi, bool delete, int passes, long bufsize)
        {
            FileStream fileStream = fi.Open(FileMode.Open);
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            for (int index = 0; index < passes; ++index)
            {
                byte[] numArray = new byte[bufsize];
                fileStream.Position = 0L;
                long num = 0;
                while (num < fileStream.Length)
                {
                    cryptoServiceProvider.GetBytes(numArray);
                    fileStream.Write(numArray, 0, (int)bufsize);
                    num += bufsize;
                }
            }
            cryptoServiceProvider.Dispose();
            fileStream.Close();
            if (!delete)
                return;
            fi.Delete();
        }

        public static void CopyTo(this Stream input, Stream output, int buffersize, long bytes)
        {
            byte[] buffer = new byte[buffersize];
            int count;
            while (bytes > 0L && (count = input.Read(buffer, 0, (int)Math.Min((long)buffer.Length, bytes))) > 0)
            {
                output.Write(buffer, 0, count);
                bytes -= (long)count;
            }
        }

        public static byte[] CreateZeroMemory(this Type t)
        {
            if (t.IsValueType)
                return new byte[Marshal.SizeOf(t)];
            throw new ArgumentException("Object is not value type");
        }

        public static object ZeroMemory(this Type t)
        {
            byte[] zeroMemory = t.CreateZeroMemory();
            Marshal.SizeOf(t);
            GCHandle gcHandle = GCHandle.Alloc((object)zeroMemory, GCHandleType.Pinned);
            object structure = Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), t);
            gcHandle.Free();
            return Convert.ChangeType(structure, t);
        }

        public static byte[] SHA1Hash(this byte[] by)
        {
            SHA1 shA1 = SHA1.Create();
            byte[] hash = shA1.ComputeHash(by);
            shA1.Dispose();
            return hash;
        }

        public static T[] SingleArray<T>(this T t)
        {
            return new T[1] { t };
        }

        public static T[] Pad<T>(this T[] t, int l)
        {
            T[] objArray = new T[l];
            for (int index = 0; index < t.Length && index < l; ++index)
                objArray[index] = t[index];
            return objArray;
        }

        public static bool ValueExists(this RegistryKey @this, string name)
        {
            return @this.GetValue(name) != null;
        }

        public static bool SubkeyExists(this RegistryKey @this, string name)
        {
            RegistryKey registryKey = @this.OpenSubKey(name);
            if (registryKey == null)
                return false;
            registryKey.Close();
            return true;
        }

        public static byte[] ToByteArray<T>(this T t) where T : struct
        {
            byte[] numArray = new byte[Marshal.SizeOf(typeof(T))];
            GCHandle gcHandle = GCHandle.Alloc((object)numArray, GCHandleType.Pinned);
            Marshal.StructureToPtr((object)t, gcHandle.AddrOfPinnedObject(), true);
            gcHandle.Free();
            return numArray;
        }

        public static T ToStructure<T>(this byte[] bytes) where T : struct
        {
            return bytes.ToStructure<T>(0);
        }

        public static T ToStructure<T>(this byte[] bytes, int offset) where T : struct
        {
            Marshal.SizeOf(typeof(T));
            GCHandle gcHandle = GCHandle.Alloc((object)bytes, GCHandleType.Pinned);
            T structure = (T)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject() + offset, typeof(T));
            gcHandle.Free();
            return structure;
        }

        public static void WriteValue<T>(this Stream s, T t) where T : struct
        {
            byte[] byteArray = t.ToByteArray<T>();
            s.Write(byteArray, 0, byteArray.Length);
        }

        public static byte[] ReadNew(this Stream s, int len)
        {
            byte[] buffer = new byte[len];
            s.Read(buffer, 0, len);
            return buffer;
        }

        public static T[] PadWith<T>(this T[] t, int len, Func<int, T> selector)
        {
            return Enumerable.Range(0, len).Select<int, T>((Func<int, T>)(x =>
           {
               if (x < t.Length)
                   return t[x];
               return selector(x);
           })).ToArray<T>();
        }

        public static byte[] EncodeToByteArray(this string s, Encoding e)
        {
            return e.GetBytes(s);
        }

        public static byte[] EncodeToByteArray(this string s)
        {
            return s.EncodeToByteArray(Encoding.ASCII);
        }

        public static string DecodeToString(this byte[] byt, Encoding e)
        {
            return e.GetString(byt);
        }

        public static string DecodeToString(this byte[] byt)
        {
            return byt.DecodeToString(Encoding.ASCII);
        }

        public static bool ElementsEqual<T>(this T[] ar, T[] o, int len)
        {
            return ar.ElementsEqual<T>(o, 0, len);
        }

        public static bool ElementsEqual<T>(this T[] ar, T[] o, int offset, int len)
        {
            return ar.ElementsEqual<T>(o, offset, offset, len);
        }

        public static byte[] ToFinalArray(this MemoryStream ms)
        {
            byte[] by = ms.ToArray();
            ms.Close();
            return by;
        }

        public static IEnumerable<T> ConcatAll<T>(this IEnumerable<T[]> t)
        {
            foreach (T[] objArray in t)
            {
                foreach (T obj in objArray)
                    yield return obj;
            }
        }

        public static T[] SubArray<T>(this T[] ar, int index)
        {
            return ar.SubArray<T>(index, ar.Length - index);
        }

        public static T[] SubArray<T>(this T[] ar, int index, int length)
        {
            T[] objArray = new T[length];
            for (int index1 = 0; index1 < length; ++index1)
                objArray[index1] = ar[index + index1];
            return objArray;
        }

        public static bool ElementsEqual<T>(this T[] ar, T[] o, int of1, int of2, int len)
        {
            for (int index = 0; index < len; ++index)
            {
                if (!ar[of1 + index].Equals((object)o[of2 + index]))
                    return false;
            }
            return true;
        }

        public static T ReadValue<T>(this Stream s) where T : struct
        {
            int len = Marshal.SizeOf(typeof(T));
            return s.ReadNew(len).ToStructure<T>();
        }

        public static void WriteAll(this Stream s, byte[] by)
        {
            s.Write(by, 0, by.Length);
        }

        public static int ReadAll(this Stream s, byte[] by)
        {
            return s.Read(by, 0, by.Length);
        }

        public static string Hex(this byte[] byt)
        {
            return BitConverter.ToString(byt).Replace("-", "");
        }

        public static byte[] UnHex(this string s)
        {
            return Enumerable.Range(0, s.Length).Where<int>((Func<int, bool>)(x => x % 2 == 0)).Select<int, byte>((Func<int, byte>)(x => Convert.ToByte(s.Substring(x, 2)))).ToArray<byte>();
        }
    }
	//TODO: Fix this
    public class UniqueRandom
    {
        private int _shufflePasses = 1;
        private Random rand;
        private byte[] ar;
        private int i;
        private int ent;

        public bool AutoReset { get; set; }

        public int ShufflePasses
        {
            get
            {
                return this._shufflePasses;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Cannot shuffle less than once");
                this._shufflePasses = value;
            }
        }

        public UniqueRandom(int entropy, int seed)
        {
            this.ent = entropy;
            this.rand = new Random(seed);
            this.setup(true);
            this.intsu();
        }

        public UniqueRandom(int entropy)
        {
            this.ent = entropy;
            this.rand = new Random();
            this.setup(true);
            this.intsu();
        }

        public UniqueRandom()
          : this(256)
        {
        }

        public UniqueRandom(byte[] entropy, int seed)
        {
            this.ent = entropy.Length;
            this.rand = new Random(seed);
            this.ar = new byte[this.ent];
            entropy.CopyTo((Array)this.ar, 0);
            this.i = 0;
            this.ar.Shuffle<byte>(this.rand);
            this.intsu();
        }

        public UniqueRandom(byte[] entropy)
        {
            this.ent = entropy.Length;
            this.rand = new Random();
            this.ar = new byte[this.ent];
            entropy.CopyTo((Array)this.ar, 0);
            this.i = 0;
            this.ar.Shuffle<byte>(this.rand);
            this.intsu();
        }

        protected virtual void intsu()
        {
            this.AutoReset = false;
        }

        public static int TimeSeed
        {
            get
            {
                long binary = DateTime.Now.ToBinary();
                int[] numArray = new int[2]
                {
          binary.ToByteArray<long>().SubArray<byte>(0, 4).ToStructure<int>(),
          binary.ToByteArray<long>().SubArray<byte>(4, 4).ToStructure<int>()
                };
                return numArray[0] ^ numArray[1];
            }
        }

        private void setup(bool fresh)
        {
            if (fresh)
                this.ar = Enumerable.Range(0, this.ent).Select<int, byte>((Func<int, byte>)(x => (byte)x)).ToArray<byte>();
            if (this.ShufflePasses > 1)
                Help.DoX((Action)(() => this.ar.Shuffle<byte>(this.rand)), this.ShufflePasses);
            else
                this.ar.Shuffle<byte>(this.rand);
            this.i = 0;
        }

        public void Reset()
        {
            this.setup(false);
        }

        public int Left
        {
            get
            {
                return this.ent - this.i;
            }
        }

        public byte NextByte()
        {
            if (this.i < this.ar.Length)
                return this.ar[this.i++];
            if (!this.AutoReset)
                throw new NotEnoughEntropyException(this.ent, this.i);
            this.setup(false);
            return this.NextByte();
        }

        public void NextBytes(byte[] fil)
        {
            for (int index = 0; index < fil.Length; ++index)
                fil[index] = this.NextByte();
        }

        public byte[] NextNewBytes(int i)
        {
            byte[] fil = new byte[i];
            this.NextBytes(fil);
            return fil;
        }

        public T NextStructure<T>() where T : struct
        {
            byte[] zeroMemory = typeof(T).CreateZeroMemory();
            this.NextBytes(zeroMemory);
            return zeroMemory.ToStructure<T>();
        }
    }
	public class NotEnoughEntropyException : Exception
    {
        public NotEnoughEntropyException(int ent, int req)
          : base("Out of entropy (had " + (object)ent + ", requested " + (object)req)
        {
        }
    }
	
	public static class Help
    {
        public static int PROGRESS_SIZE = 50;

        public static void DoX(Action a, int t)
        {
            for (int index = 0; index < t; ++index)
                a();
        }

        public static void Progress(double s, double l)
        {
            double num1 = s / l;
            double num2 = num1 * 100.0;
            Console.Write("\r[");
            for (int index = 0; index < Help.PROGRESS_SIZE; ++index)
            {
                if ((double)index < (double)Help.PROGRESS_SIZE * num1)
                    Console.Write("=");
                else
                    Console.Write(" ");
            }
            Console.Write("]: " + num2.ToString("##0.00") + "%   ");
        }

        public static void ClearProgress()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
        }
#if FORMS
        public static void ErrMsg(string text, string title)
        {
            int num = (int)MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
#endif
    }
	
	public class GCHPinned : IDisposable
    {
        private GCHandle handle;

        public IntPtr Pointer
        {
            get
            {
                return this.handle.AddrOfPinnedObject();
            }
        }

        public GCHPinned(GCHandle h)
        {
            this.handle = h;
        }

        public GCHPinned(object o)
          : this(GCHandle.Alloc(o, GCHandleType.Pinned))
        {
        }

        public void Dispose()
        {
            this.handle.Free();
        }

        public static implicit operator IntPtr(GCHPinned p)
        {
            return p.Pointer;
        }
    }
	
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BitField
    {
        private byte b;

        public bool fieldn(int n, bool? val)
        {
            if (!val.HasValue)
                return ((int)this.b & 1 << n) != 0;
            if (val.Value != this.fieldn(n, new bool?()))
                this.b ^= (byte)(1 << n);
            return val.Value;
        }

        public bool Field0
        {
            get
            {
                return this.fieldn(0, new bool?());
            }
            set
            {
                this.fieldn(0, new bool?(value));
            }
        }

        public bool Field1
        {
            get
            {
                return this.fieldn(1, new bool?());
            }
            set
            {
                this.fieldn(1, new bool?(value));
            }
        }

        public bool Field2
        {
            get
            {
                return this.fieldn(2, new bool?());
            }
            set
            {
                this.fieldn(2, new bool?(value));
            }
        }

        public bool Field3
        {
            get
            {
                return this.fieldn(3, new bool?());
            }
            set
            {
                this.fieldn(3, new bool?(value));
            }
        }

        public bool Field4
        {
            get
            {
                return this.fieldn(4, new bool?());
            }
            set
            {
                this.fieldn(4, new bool?(value));
            }
        }

        public bool Field5
        {
            get
            {
                return this.fieldn(5, new bool?());
            }
            set
            {
                this.fieldn(5, new bool?(value));
            }
        }

        public bool Field6
        {
            get
            {
                return this.fieldn(6, new bool?());
            }
            set
            {
                this.fieldn(6, new bool?(value));
            }
        }

        public bool Field7
        {
            get
            {
                return this.fieldn(7, new bool?());
            }
            set
            {
                this.fieldn(7, new bool?(value));
            }
        }

        public bool this[int n]
        {
            get
            {
                return this.fieldn(n, new bool?());
            }
            set
            {
                this.fieldn(n, new bool?(value));
            }
        }
    }

	public class AsyncSchedulerTaskHandleUnhandledExceptionEventArgs : EventArgs
    {
        public AsyncSchedulerTaskException Exception { get; private set; }

        public AsyncSchedulerTaskHandleUnhandledExceptionEventArgs(AsyncSchedulerTaskException ex)
        {
            this.Exception = ex;
        }
    }
	public class AsyncSchedulerTaskException : Exception
    {
        public Thread CallingThread { get; set; }

        public AsyncSchedulerTaskException(Exception e, Thread t, string message)
          : base(message, e)
        {
            this.CallingThread = t;
        }
    }
	public class AsyncScheduler : IDisposable
    {
        public static int AllowedJoinTimeOnDispose = 100;
        public const int NO_MAX = -1;
        private bool disposed;
        private List<Thread> threads;
        private Thread collector;

        public int MaxTasks { get; set; }

        public AsyncScheduler(int max)
        {
            this.MaxTasks = max;
            this.threads = new List<Thread>();
            this.collector = new Thread(new ThreadStart(this.collect));
            this.collector.Start();
        }

        public AsyncScheduler()
          : this(-1)
        {
        }

        private void no_param(object o)
        {
            ((ThreadStart)o)();
        }

        private void param(object o)
        {
            ParameterizedThreadStart parameterizedThreadStart = (ParameterizedThreadStart)((object[])o)[0];
            object obj = ((object[])o)[1];
            try
            {
                parameterizedThreadStart(obj);
            }
            catch (Exception ex)
            {
                this.raiseUEEvent(new AsyncSchedulerTaskException(ex, Thread.CurrentThread, "Exception (" + ex.GetBaseException().GetType().Name + ") on thread (" + (Thread.CurrentThread.Name ?? "(unbound)") + "): " + ex.Message));
            }
        }

        protected virtual void raiseUEEvent(AsyncSchedulerTaskException e)
        {
            if (this.OnUnhandledException == null)
                throw e;
            this.OnUnhandledException((object)this, new AsyncSchedulerTaskHandleUnhandledExceptionEventArgs(e));
        }

        public event AsyncScheduler.UnhandledExceptionOnThreadHandler OnUnhandledException;

        private void collect()
        {
            while (!this.disposed)
            {
                lock (this.threads)
                {
                    for (int index = 0; index < this.threads.Count; ++index)
                    {
                        if (this.threads[index] != null && !this.threads[index].IsAlive)
                            this.threads[index] = (Thread)null;
                    }
                    this.threads.RemoveAll((Predicate<Thread>)(x => x == null));
                }
                Thread.Sleep(500);
            }
        }

        public Thread RunTask<T>(AsyncScheduler.GenericParameterisedAsyncStart<T> pts, T o)
        {
            return this.RunTask((ThreadStart)(() => pts(o)));
        }

        public Thread RunTask(ParameterizedThreadStart pts, object o)
        {
            lock (this.threads)
            {
                if (this.MaxTasks != -1 && this.threads.Count >= this.MaxTasks)
                    return (Thread)null;
                Thread thread = new Thread(new ParameterizedThreadStart(this.param));
                this.threads.Add(thread);
                thread.Start((object)new object[2]
                {
          (object) pts,
          o
                });
                return thread;
            }
        }

        public Thread RunTask(ThreadStart ts)
        {
            return this.RunTask<ThreadStart>(new AsyncScheduler.GenericParameterisedAsyncStart<ThreadStart>(this.no_param), ts);
        }

        public void Dispose()
        {
            this.disposed = true;
            if (!this.collector.Join(550))
                this.collector.Abort();
            foreach (Thread thread in this.threads)
            {
                if (thread != null && thread.IsAlive && !thread.Join(AsyncScheduler.AllowedJoinTimeOnDispose))
                    thread.Abort();
            }
            this.threads.Clear();
        }

        public void Purge(bool instant)
        {
            lock (this.threads)
            {
                foreach (Thread thread in this.threads)
                {
                    if (thread != null && thread.IsAlive && (instant || !thread.Join(AsyncScheduler.AllowedJoinTimeOnDispose)))
                        thread.Abort();
                }
                this.threads.Clear();
            }
        }

        public void Purge()
        {
            this.Purge(false);
        }

        public void JoinAll(int timeout)
        {
            lock (this.threads)
            {
                foreach (Thread thread in this.threads)
                {
                    if (thread != null && thread.IsAlive && !thread.Join(timeout))
                        thread.Abort();
                }
                this.threads.Clear();
            }
        }

        public void JoinAll()
        {
            lock (this.threads)
            {
                foreach (Thread thread in this.threads)
                {
                    if (thread != null && thread.IsAlive)
                        thread.Join();
                }
                this.threads.Clear();
            }
        }

        public delegate void GenericParameterisedAsyncStart<T>(T param);

        public delegate void UnhandledExceptionOnThreadHandler(object sender, AsyncSchedulerTaskHandleUnhandledExceptionEventArgs eventArgs);
    }
	
	public class ArrayBuilder<T>
    {
        private List<T[]> list;

        public ArrayBuilder()
        {
            this.list = new List<T[]>();
        }

        public ArrayBuilder<T> Append(T[] ar)
        {
            this.list.Add(ar);
            return this;
        }

        public ArrayBuilder<T> Append(T[][] arar)
        {
            this.list.Add(((IEnumerable<T[]>)arar).ConcatAll<T>().ToArray<T>());
            return this;
        }

        public ArrayBuilder<T> Append(T single)
        {
            this.list.Add(new T[1] { single });
            return this;
        }

        public T[] ToArray()
        {
            return ((IEnumerable<T[]>)this.list.ToArray()).ConcatAll<T>().ToArray<T>();
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayBuilder<T>)
            {
                if (this.Length == (obj as ArrayBuilder<T>).Length)
                    return this.ToArray().ElementsEqual<T>((obj as ArrayBuilder<T>).ToArray(), this.Length);
            }
            else if (obj is T[] && this.Length == (obj as T[]).Length)
                return this.ToArray().ElementsEqual<T>(obj as T[], this.Length);
            return obj.Equals((object)this);
        }

        public override int GetHashCode()
        {
            return this.ToArray().GetHashCode();
        }

        public int Length
        {
            get
            {
                return this.list.Select<T[], int>((Func<T[], int>)(x => x.Length)).Sum();
            }
        }
    }
	
	public class ArgHelper
    {
        private static bool _d_groupString = false;
        private static bool _d_anyCase = true;
        private List<ArgHelper.ArgHandle> handles = new List<ArgHelper.ArgHandle>();

        public static bool SetDefaultGroupString(bool? value)
        {
            if (!value.HasValue)
                return ArgHelper._d_groupString;
            return ArgHelper._d_groupString = value.Value;
        }

        public static bool SetDefaultAnyCase(bool? value)
        {
            if (!value.HasValue)
                return ArgHelper._d_anyCase;
            return ArgHelper._d_anyCase = value.Value;
        }

        public ArgHelper(params ArgHelper.ArgHandle[] ags)
        {
            this.Add(ags);
        }

        public ArgHelper Add(params ArgHelper.ArgHandle[] ars)
        {
            this.handles.AddRange((IEnumerable<ArgHelper.ArgHandle>)ars);
            return this;
        }

        public ArgHelper Reset()
        {
            foreach (ArgHelper.ArgHandle handle in this.handles)
                handle.Reset();
            return this;
        }

        public ArgHelper Parse(string[] args)
        {
            for (int i = 0; i < args.Length; ++i)
            {
                List<string> stringList = new List<string>();
                for (int index = 0; index < this.handles.Count && (!this.handles[index].GroupString || !stringList.Contains(this.handles[index].Argument)); ++index)
                {
                    if (this.handles[index].AttemptHandle(args, i))
                    {
                        stringList.Add(this.handles[index].Argument);
                        i += this.handles[index].Requires;
                        break;
                    }
                }
            }
            return this;
        }

        public static ArgHelper CreateObj(params object[][] o)
        {
            List<ArgHelper.ArgHandle> argHandleList = new List<ArgHelper.ArgHandle>();
            foreach (object[] objs in o)
            {
                if (!objs.AllValidTypes(typeof(string), typeof(int), typeof(ArgHelper.ArgHandler)))
                    throw new ArgumentException("Invalid Format");
                argHandleList.Add(new ArgHelper.ArgHandle(objs[0] as string, (int)objs[1], objs[2] as ArgHelper.ArgHandler));
            }
            return new ArgHelper(argHandleList.ToArray());
        }

        public static ArgHelper Create(params object[] o)
        {
            if (o.Length % 3 != 0)
                throw new ArgumentException("Invalid Format");
            List<object[]> objArrayList = new List<object[]>();
            int index = 0;
            while (index < o.Length)
            {
                objArrayList.Add(o.SubArray<object>(index, 3));
                index += 3;
            }
            return ArgHelper.CreateObj(objArrayList.ToArray());
        }

        public delegate bool ArgHandler(string[] args, int index);

        public class ArgHandle
        {
            public string Argument { get; set; }

            public int Requires { get; set; }

            public ArgHelper.ArgHandler Handle { get; set; }

            public bool Handled { get; private set; }

            public ArgHandle(string str, int left, ArgHelper.ArgHandler handle)
            {
                this.GroupString = ArgHelper._d_groupString;
                this.AnyCase = ArgHelper._d_anyCase;
                this.Argument = str;
                this.Requires = left;
                this.Handle = handle;
                this.Handled = false;
            }

            public bool AttemptHandle(string[] ar, int i)
            {
                int length = ar.Length;
                if (i < 0 || i >= length || (this.Handled || length - (i + 1) < this.Requires) || (this.AnyCase ? (this.Argument.ToLower().Equals(ar[i].ToLower()) ? 1 : 0) : (this.Argument.Equals(ar[i]) ? 1 : 0)) == 0)
                    return false;
                this.Handled = true;
                return this.Handle(ar, i);
            }

            public void Reset()
            {
                this.Handled = false;
            }

            public bool GroupString { get; set; }

            public bool AnyCase { get; set; }

            public override string ToString()
            {
                return this.Argument + "(" + (object)this.Requires + ")";
            }
        }
    }

#if FORMS
	namespace Forms
	{
		public static class FormBackgroundWorker
		{
			public static void DoWork(FormBackgroundWorker.ParameterisedWorkerAction a, object arg, string m, bool mq)
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += new DoWorkEventHandler(FormBackgroundWorker.bg_DoWork);
				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FormBackgroundWorker.bg_RunWorkerCompleted);
				WorkingForm workingForm = new WorkingForm(m, mq ? -1 : 0);
				backgroundWorker.RunWorkerAsync((object)new object[3]
				{
			(object) workingForm,
			(object) a,
			arg
				});
				int num = (int)workingForm.ShowDialog();
				backgroundWorker.Dispose();
			}

			public static void DoWork(FormBackgroundWorker.ParameterisedWorkerAction a, object arg, string m, bool mq, bool allowCancel)
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += new DoWorkEventHandler(FormBackgroundWorker.bg_DoWork);
				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FormBackgroundWorker.bg_RunWorkerCompleted);
				WorkingForm workingForm = new WorkingForm(m, mq ? -1 : 0);
				workingForm.AllowCancel = allowCancel;
				backgroundWorker.RunWorkerAsync((object)new object[3]
				{
			(object) workingForm,
			(object) a,
			arg
				});
				int num = (int)workingForm.ShowDialog();
				backgroundWorker.Dispose();
			}

			public static void DoWork(FormBackgroundWorker.ParameterisedWorkerAction a, object arg, string m, bool mq, bool allowCancel, IWin32Window parent)
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += new DoWorkEventHandler(FormBackgroundWorker.bg_DoWork);
				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FormBackgroundWorker.bg_RunWorkerCompleted);
				WorkingForm workingForm = new WorkingForm(m, mq ? -1 : 0);
				workingForm.AllowCancel = allowCancel;
				backgroundWorker.RunWorkerAsync((object)new object[3]
				{
			(object) workingForm,
			(object) a,
			arg
				});
				int num = (int)workingForm.ShowDialog(parent);
				backgroundWorker.Dispose();
			}

			public static void DoWork(FormBackgroundWorker.ParameterisedWorkerAction a, object arg, string m, bool mq, IWin32Window parent)
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += new DoWorkEventHandler(FormBackgroundWorker.bg_DoWork);
				backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FormBackgroundWorker.bg_RunWorkerCompleted);
				WorkingForm workingForm = new WorkingForm(m, mq ? -1 : 0);
				backgroundWorker.RunWorkerAsync((object)new object[3]
				{
			(object) workingForm,
			(object) a,
			arg
				});
				int num = (int)workingForm.ShowDialog(parent);
				backgroundWorker.Dispose();
			}

			private static void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
			{
				WorkingForm result = (WorkingForm)e.Result;
				result.Stop();
				result.Close();
				result.Dispose();
			}

			private static void bg_DoWork(object sender, DoWorkEventArgs e)
			{
				object[] objArray = (object[])e.Argument;
				WorkingForm wf = (WorkingForm)objArray[0];
				((FormBackgroundWorker.ParameterisedWorkerAction)objArray[1])(wf, objArray[2]);
				e.Result = (object)wf;
			}

			public delegate void ParameterisedWorkerAction(WorkingForm wf, object param);
		}
	
		public class WorkingForm : Form
		{
			private string sm;
			private string smc;
			private volatile int progress;
			private bool cancelCalled;
			private IContainer components;
			private Label label1;
			private Label label2;
			private ProgressBar progressBar1;
			private Label label3;
			private System.Windows.Forms.Timer timer1;
			private Button button1;

			public string Message
			{
				get
				{
					return this.label2.Text;
				}
				set
				{
					this.label2.Text = value;
				}
			}

			public WorkingForm(string msg, int startP)
			{
				this.sm = msg;
				this.progress = startP;
				this.InitializeComponent();
			}

			public int Progress
			{
				get
				{
					return this.progress;
				}
				set
				{
					this.progress = value;
				}
			}

			public bool AllowCancel
			{
				get
				{
					return this.button1.Visible;
				}
				set
				{
					this.button1.Visible = value;
				}
			}

			private void WorkingForm_Load(object sender, EventArgs e)
			{
				this.Message = this.sm;
				this.setProgress(this.progress);
				this.Start();
			}

			private void Start()
			{
				this.timer1.Start();
			}

			public void Stop()
			{
				this.timer1.Stop();
			}

			public void SetMessage(string s)
			{
				this.smc = s;
			}

			public void SetProgress(double small, double large)
			{
				this.Progress = (int)Math.Floor(small / large * 100.0);
			}

			private void setProgress(int p)
			{
				if (p >= 0)
				{
					if (this.progressBar1.Style != ProgressBarStyle.Blocks)
						this.progressBar1.Style = ProgressBarStyle.Blocks;
					if (this.progressBar1.MarqueeAnimationSpeed != 0)
						this.progressBar1.MarqueeAnimationSpeed = 0;
					this.progressBar1.Value = p;
					this.label3.Text = p.ToString() + "%";
				}
				else
				{
					if (this.progressBar1.Value != 10)
						this.progressBar1.Value = 10;
					if (this.progressBar1.Style != ProgressBarStyle.Marquee)
						this.progressBar1.Style = ProgressBarStyle.Marquee;
					if (this.progressBar1.MarqueeAnimationSpeed != 100)
						this.progressBar1.MarqueeAnimationSpeed = 100;
					switch (this.label3.Text)
					{
						case "|":
							this.label3.Text = "/";
							break;
						case "/":
							this.label3.Text = "-";
							break;
						case "-":
							this.label3.Text = "\\";
							break;
						default:
							this.label3.Text = "|";
							break;
					}
				}
			}

			private void timer1_Tick(object sender, EventArgs e)
			{
				this.setProgress(this.progress);
				if (this.smc == null)
					return;
				this.Message = this.smc;
				this.smc = (string)null;
			}

			public bool CancelCalled()
			{
				return this.cancelCalled;
			}

			private void button1_Click(object sender, EventArgs e)
			{
				this.cancelCalled = true;
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing && this.components != null)
					this.components.Dispose();
				base.Dispose(disposing);
			}

			private void InitializeComponent()
			{
				this.components = (IContainer)new Container();
				this.label1 = new Label();
				this.label2 = new Label();
				this.progressBar1 = new ProgressBar();
				this.label3 = new Label();
				this.timer1 = new System.Windows.Forms.Timer(this.components);
				this.button1 = new Button();
				this.SuspendLayout();
				this.label1.AutoSize = true;
				this.label1.Location = new Point(12, 34);
				this.label1.Name = "label1";
				this.label1.Size = new Size(36, 13);
				this.label1.TabIndex = 0;
				this.label1.Text = "Done:";
				this.label2.AutoSize = true;
				this.label2.Location = new Point(12, 9);
				this.label2.Name = "label2";
				this.label2.Size = new Size(55, 13);
				this.label2.TabIndex = 1;
				this.label2.Text = "(unbound)";
				this.progressBar1.Location = new Point(54, 34);
				this.progressBar1.Name = "progressBar1";
				this.progressBar1.Size = new Size(182, 13);
				this.progressBar1.TabIndex = 2;
				this.label3.AutoSize = true;
				this.label3.Location = new Point(242, 34);
				this.label3.Name = "label3";
				this.label3.Size = new Size(63, 13);
				this.label3.TabIndex = 3;
				this.label3.Text = "(unbound)%";
				this.timer1.Tick += new EventHandler(this.timer1_Tick);
				this.button1.Location = new Point(199, 4);
				this.button1.Name = "button1";
				this.button1.Size = new Size(75, 23);
				this.button1.TabIndex = 4;
				this.button1.Text = "Cancel";
				this.button1.UseVisualStyleBackColor = true;
				this.button1.Visible = false;
				this.button1.Click += new EventHandler(this.button1_Click);
				this.AutoScaleDimensions = new SizeF(6f, 13f);
				this.AutoScaleMode = AutoScaleMode.Font;
				this.ClientSize = new Size(286, 51);
				this.ControlBox = false;
				this.Controls.Add((Control)this.button1);
				this.Controls.Add((Control)this.label3);
				this.Controls.Add((Control)this.progressBar1);
				this.Controls.Add((Control)this.label2);
				this.Controls.Add((Control)this.label1);
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = nameof(WorkingForm);
				this.ShowIcon = false;
				this.StartPosition = FormStartPosition.CenterParent;
				this.Text = "Working";
				this.Load += new EventHandler(this.WorkingForm_Load);
				this.ResumeLayout(false);
				this.PerformLayout();
			}
		}
	}
#endif
}
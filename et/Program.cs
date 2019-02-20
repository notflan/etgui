using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace et
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("et --encrypt <input> <output> <key>");
                Console.WriteLine("et --decrypt <input> <output> <key>");
            }
            else if (args[0].Equals("--encrypt"))
            {
                string i = args[1];
                string o = args[2];
                string k = args[3];

                if (File.Exists(i))
                {
                    using (var os = new FileStream(o, FileMode.Create))
                    {
                        ET.EncryptText(File.ReadAllText(i), ET.HashPassword(k).Hex()).Save(os);
                    }
                }
            }
            else if (args[0].Equals("--decrypt"))
            {
                string i = args[1];
                string o = args[2];
                string k = args[3];

                if (File.Exists(i))
                {
                    using (var iis = new FileStream(i, FileMode.Open))
                    {
                        EncryptedTextContainer c = new EncryptedTextContainer();
                        c.Load(iis);
                        File.WriteAllText(o, ET.DecryptText(c, ET.HashPassword(k).Hex()));
                    }
                }
            }
        }
    }
    public static class ET
    {
        public static byte[] HashPassword(string s)
        {
            return s.EncodeToByteArray().SHA1Hash();
        }
        
        public static EncryptedTextContainer EncryptText(string t, string pw)
        {
            using (EncryptedText e = new EncryptedText(pw))
            {
                return new EncryptedTextContainer() { Data = e.Encrypt(t), Salt = e.Salt };
            }
        }
        public static string DecryptText(EncryptedTextContainer t, string pw)
        {
            using (var e = new EncryptedText(pw, t.Salt))
            {
                return e.Decrypt(t.Data);
            }
        }
    }
    public class EncryptedText : IDisposable
    {
        private AesCryptoServiceProvider aes;
        private Rfc2898DeriveBytes pf;
        private EncryptedTextSalt salt;
        private RNGCryptoServiceProvider rng;

        private byte[] key;

        public byte[] Salt { get { return salt.salt.data; } }
        public byte[] Key { get { return key; } }

        public EncryptedText(string pw, byte[] s)
        {
            aes = new AesCryptoServiceProvider();
            rng = new RNGCryptoServiceProvider();
            salt = new EncryptedTextSalt();
            
            if (s == null)
                salt.populate(rng);
            else salt.salt = new Tools.ByValData.ByValFixedByteArray16(s);

            pf = new Rfc2898DeriveBytes(pw, salt.salt.data);

            key = pf.GetBytes(32);
            aes.Key = key;
            aes.IV = salt.salt.data; //DamienG.Security.Cryptography.Crc32.Compute(salt.salt.data).ToByteArray();
        }
        public EncryptedText(string pw) : this(pw, null) { }

        public EncryptedText Clone(string pw)
        {
            return new EncryptedText(pw, Salt);
        }

        public PadSettings? PadSettings { get; set; }

        public byte[] CreatePad(ref byte[] padHeaderFull, ref PadHeader ph)
        {
            if (PadSettings == null) return null;
            else
            {
                var ps = PadSettings.Value;
                byte[] seq = null;
                ph = ps.CreatePadHeader(rng, ref seq);
                if (seq != null)
                    padHeaderFull = global::et.PadHeader.PAD_ENABLED_MAGIC.ToByteArray().Concat(ph.ToByteArray().Concat(seq)).ToArray();
                else padHeaderFull = global::et.PadHeader.PAD_ENABLED_MAGIC.ToByteArray().Concat(ph.ToByteArray()).ToArray();
                MemoryStream actualPad = new MemoryStream();
                switch (ph.Type)
                {
                    case PadType.Zero: actualPad.WriteAll(new byte[ph.size]); break;
                    case PadType.Random:
                        {
                            byte[] v = new byte[ph.size];
                            rng.GetBytes(v);
                            actualPad.WriteAll(v);
                        } break;
                    case PadType.FixedC:
                        {
                            for (int i = 0; i < ph.size; i++) actualPad.WriteByte((byte)ph.fc_char);
                        } break;
                    case PadType.FixedS:
                        {
                            for (int i = 0, j = 0; i < ph.size; i++)
                            {
                                if (j >= seq.Length) j = 0;
                                actualPad.WriteByte(seq[j]);
                                j += 1;
                            }
                        } break;
                }
                return actualPad.ToFinalArray();
                /*
                var ps = PadSettings.Value;
                MemoryStream ms = new MemoryStream();
                ms.WriteValue<uint>(PadHeader.PAD_ENABLED_MAGIC);
                ph = new PadHeader();
                ph.size = ps.size ?? r.Next(global::et.PadSettings.RANDOM_SIZE_BOUND_LOW, global::et.PadSettings.RANDOM_SIZE_BOUND_HIGH);
                ph.Location = ps.location?? (PadLocation) r.Next(0, 1);
                header = ms.ToFinalArray();

                var type = ps.type ?? (PadType)(r.Next(0, 3));
                MemoryStream actualPad = new MemoryStream();
                switch (type)
                {
                    case PadType.Zero: ms.WriteAll(new byte[ph.size]); break;
                    case PadType.Random:
                        {
                            byte[] v = new byte[ph.size];
                            rng.GetBytes(v);
                            actualPad.WriteAll(v);
                        } break;
                    case PadType.FixedC:
                        {
                            char c = ps.type == null ? (char)r.Next(0, 255) : ps._t_fc_char;
                            for (int i = 0; i < ph.size; i++) actualPad.WriteByte((byte)c);
                        } break;
                    case PadType.FixedS:
                        {
                            byte[] seq = ps.type == null ? pad_rng_seq(r) : ps._t_fc_seq;
                            for (int i = 0, j = 0; i < ph.size; i++)
                            {
                                if (j >= seq.Length) j = 0;
                                actualPad.WriteByte(seq[j]);
                                j += 1;
                            }
                        } break;
                }
                return actualPad.ToFinalArray();*/
            }
        }
        

        byte[] createRawData(string s)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pad = null;
            if (PadSettings.HasValue)
            {
                byte[] h = null;
                PadHeader ph = new PadHeader();
                pad = CreatePad(ref h,ref ph);
                if (h != null)
                {
                    ms.WriteAll(h);
                }
                if (ph.Location == PadLocation.Start)
                {
                    ms.WriteAll(pad);
                    pad = null;
                }
            }

            ms.WriteAll(s.EncodeToByteArray(Encoding.UTF8));

            if (pad != null) ms.WriteAll(pad);
            return ms.ToFinalArray();
        }

        public byte[] Encrypt(string s)
        {
            byte[] b;
            using (var c = aes.CreateEncryptor())
            {
                return c.TransformFinalBlock(b = createRawData(s), 0, b.Length);
            }
        }


        public string Decrypt(byte[] s)
        {
            using (var c = aes.CreateDecryptor())
            {
                var raw = c.TransformFinalBlock(s, 0, s.Length);
                global::et.PadSettings? ps;
                var r = stripPadding(raw, out ps);
                PadSettings = ps;
                return r;
            }
        }

        private string stripPadding(byte[] raw, out PadSettings? ps)
        {
            MemoryStream ms = new MemoryStream(raw);
            ms.Position = 0;
            if (ms.ReadValue<uint>() == PadHeader.PAD_ENABLED_MAGIC)
            {
                PadHeader ph = ms.ReadValue<PadHeader>();
                byte[] seq = new byte[ph.fc_seq_size];
                ms.ReadAll(seq);

                var _ps = new PadSettings();
                _ps.FromPadHeader(ph, seq);
                ps = _ps;

                if (ph.Location == PadLocation.Start)
                {
                    ms.Position += ph.size;
                    using (var ms2 = new MemoryStream())
                    {
                        ms.CopyTo(ms2);
                        ms.Close();
                        return ms2.ToArray().DecodeToString(Encoding.UTF8);
                    }
                }
                else
                {
                    using (var ms2 = new MemoryStream())
                    {
                        ms.CopyTo(ms2);
                        ms.Close();
                        byte[] ar =  ms2.ToArray();
                        return ar.SubArray(0, ar.Length - ph.size).DecodeToString(Encoding.UTF8);
                    }
                }
            }
            else
            {
                ms.Close();
                ps = null;
                return raw.DecodeToString(Encoding.UTF8);
            }
        }

        public void Dispose()
        {
            aes.Dispose();
            pf.Dispose();
            rng.Dispose();

        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PadHeader
    {
        public const uint PAD_ENABLED_MAGIC = 0xABAD1DEA;

        public int size;
        private int loc;
        private int typ;
        public PadLocation Location { get { return (PadLocation)loc; } set { loc = (int)value; } }
        public PadType Type { get { return (PadType)typ; } set { typ = (int)value; } }
        public char fc_char;
        public int fc_seq_size;
        
    }
    public enum PadType
    {
        Zero = 0, Random, FixedC, FixedS
    }
    public enum PadLocation
    {
        Start = 0, End
    }
    public struct PadSettings
    {
        public const int RANDOM_SIZE_BOUND_LOW = 1;
        public const int RANDOM_SIZE_BOUND_HIGH = 512;

        public const int RANDOM_SEQUENCE_BOUND_LOW = 16;
        public const int RANDOM_SEQUENCE_BOUND_HIGH = 32;
        public int? size;

        public PadType? type;
        public char _t_fc_char;
        public byte[] _t_fc_seq;

        public PadLocation? location;

        public PadHeader CreatePadHeader(RNGCryptoServiceProvider rng, ref byte[] seq)
        {
            PadHeader ph = new PadHeader();
            Random r = pad_rng(rng);
            ph.size = size ?? r.Next(global::et.PadSettings.RANDOM_SIZE_BOUND_LOW, global::et.PadSettings.RANDOM_SIZE_BOUND_HIGH);
            ph.Location = location ?? (PadLocation)r.Next(0, 1);
            ph.fc_char = type == null ? (char)r.Next(0, 255) : _t_fc_char;
            seq = type == null ? pad_rng_seq(rng, r) : _t_fc_seq;
            if (seq == null)
                ph.fc_seq_size = 0;
            else
                ph.fc_seq_size = seq.Length;
            ph.Type = type ?? (PadType)(r.Next(0, 3));
            return ph;
        }
        public void FromPadHeader(PadHeader ph, byte[] seq)
        {
            size = ph.size;
            location = ph.Location;
            type = ph.Type;
            _t_fc_char = ph.fc_char;
            _t_fc_seq = (seq!=null&&seq.Length>0)?seq:null;
        }

        public void Save(Stream s)
        {
            s.WriteValue<int>(size ?? -1);
            if (type.HasValue) s.WriteValue<int>((int)type.Value);
            else s.WriteValue<int>(-1);
            s.WriteValue<char>(_t_fc_char);
            if (_t_fc_seq == null)
            {
                s.WriteValue<int>(0);
            }
            else
            {
                s.WriteValue<int>(_t_fc_seq.Length);
                s.WriteAll(_t_fc_seq);
            }
            if (location.HasValue)
                s.WriteValue<int>((int)location.Value);
            else s.WriteValue<int>(-1);
        }
        public void Load(Stream s)
        {
            int i;
            i = s.ReadValue<int>();
            if (i < 0) size = null; else size = i;
            i = s.ReadValue<int>();
            if (i < 0) type = null; else type = (PadType)i;
            _t_fc_char = s.ReadValue<char>();
            i = s.ReadValue<int>();
            if (i < 0) _t_fc_seq = null; else _t_fc_seq = s.ReadNew(i);
            i = s.ReadValue<int>();
            if (i < 0) location = null; else location = (PadLocation)i;
        }

        private byte[] pad_rng_seq(RNGCryptoServiceProvider rng, Random r)
        {
            byte[] b = new byte[r.Next(global::et.PadSettings.RANDOM_SEQUENCE_BOUND_LOW, global::et.PadSettings.RANDOM_SEQUENCE_BOUND_HIGH)];
            rng.GetBytes(b);
            return b;
        }
        private Random pad_rng(RNGCryptoServiceProvider rng)
        {

            byte[] b = new byte[sizeof(int)];
            rng.GetBytes(b);

            Random r = new Random(b.ToStructure<int>());
            return r;
        }
    }
    public class EncryptedTextContainer
    {
        public byte[] Salt { get; set; }
        public byte[] Data { get; set; }
        public EncryptedTextContainer(byte[] e, EncryptedTextSalt s)
        {
            Data = e;
            Salt = s.salt.data;
        }
        public EncryptedTextContainer()
        {

        }
        
        public void Save(Stream s)
        {
            s.WriteValue(new EncryptedTextSalt() { salt = new Tools.ByValData.ByValFixedByteArray16(Salt) });
            s.WriteValue(Data.Length);
            s.WriteAll(Data);
        }
        public void Load(Stream s)
        {
            var ec = s.ReadValue<EncryptedTextSalt>();
            int l = s.ReadValue<int>();
            Data = s.ReadNew(l);
            Salt = ec.salt.data;
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct EncryptedTextSalt
    {
        public Tools.ByValData.ByValFixedByteArray16 salt;
        public void populate(RNGCryptoServiceProvider r)
        {
            salt = new Tools.ByValData.ByValFixedByteArray16();
            salt.data = new byte[16];
            r.GetBytes(salt.data);

        }
    }
    
}

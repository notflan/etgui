using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tools;
using System.Runtime.InteropServices;

namespace et
{
    //Todo: add flags for compression, encryption, etc
    public class EmbeddedFilesystem
    {
        EFSNode root;
        public EFSNode Root { get { return root; } }
        public EmbeddedFilesystem()
        {
            root = new EFSNode(EFSNodeType.Folder, "", null);
        }
        public void Serialise(Stream s)
        {
            root.Serialise(s);
        }
        public void Unserialise(Stream s)
        {
            root.Unserialise(s);

            root.Name = "";
            root.Type = EFSNodeType.Folder;
            root.Data = null;
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EFSNodeInformation //todo: something with this
    {
        private double ctime_utc, mtime_utc;
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public DateTime TimeCreatedUTC { get { return UnixTimeStampToDateTime(ctime_utc); } set { ctime_utc = value.ToUnixTime(); } }
        public DateTime TimeModifiedUTC { get { return UnixTimeStampToDateTime(mtime_utc); } set { mtime_utc = value.ToUnixTime(); } }

        public static EFSNodeInformation CreateNew()
        {
            EFSNodeInformation n = new EFSNodeInformation();
            n.TimeCreatedUTC = n.TimeModifiedUTC = DateTime.UtcNow;
            return n;
        }
    }
    public class EFSNode
    {
        public EFSNode AddChild(EFSNode n)
        {
            if (c_list == null) c_list = new List<EFSNode>();
            lock (c_list)
            {
                int i = c_list.Count;
                c_list.Add(n);
                return c_list[i];
            }
        }
        public EFSNodeType Type { get; set; }
        private List<EFSNode> c_list;
        public EFSNode[] Children { get { return c_list == null ? null : c_list.ToArray(); } set { if (value == null)c_list = null; else c_list = new List<EFSNode>(value); } }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public uint Flags { get; set; }//i'll do something with this right?

        public EFSNodeInformation Metadata { get; set; }

        public EFSNode(EFSNodeType t, string name, byte[] data, EFSNodeInformation meta)
        {
            c_list = null;
            Type = t;
            Metadata = meta;
            Name = name;
            Data = data;
            Flags = 0;

        }
        public EFSNode(EFSNodeType t, string name, byte[] data) : this(t, name, data, EFSNodeInformation.CreateNew()) { }
        public static EFSNode CreateFromStream(Stream s)
        {
            EFSNode n = new EFSNode();
            
            n.Unserialise(s);
            return n;
        }
        private EFSNode()
        {

        }
        public void Serialise(Stream s)
        {
            s.WriteValue<int>((int)Type);
            s.WriteValue(new Tools.ByValStrings.ByValANSIString128(Name));
            s.WriteValue<EFSNodeInformation>(Metadata);
            s.WriteValue<uint>(Flags);
            if (Data == null)
            {
                s.WriteValue<int>(0);
            }
            else
            {
                s.WriteValue<int>(Data.Length);
                s.WriteAll(Data);
            }

            s.WriteValue<int>(Children == null ? 0 : Children.Length);
            if (Children != null)
                foreach (var c in Children)
                {
                    c.Serialise(s);
                }
        }
        public void Unserialise(Stream s)
        {
            Type = (EFSNodeType)s.ReadValue<int>();
            Name = s.ReadValue<Tools.ByValStrings.ByValANSIString128>().cstring;
            Metadata = s.ReadValue<EFSNodeInformation>();
            Flags = s.ReadValue<uint>();
            int dl = s.ReadValue<int>();
            if (dl > 0)
            {
                Data = s.ReadNew(dl);
            }
            else Data = null;
            int cl = s.ReadValue<int>();
            if (cl > 0)
            {
                c_list = new List<EFSNode>();
                for (int i = 0; i < cl; i++)
                {
                    EFSNode child = new EFSNode();
                    child.Unserialise(s);
                    c_list.Add(child);
                }
            }
            else Children = null;
        }
    }
    public enum EFSNodeType
    {
        Folder = 0, File = 1
    }
    
}

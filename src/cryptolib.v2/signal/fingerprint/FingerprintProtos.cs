// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: FingerprintProtocol.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace citronindo.cryptolib.signal.fingerprint
{

    /// <summary>Holder for reflection information generated from FingerprintProtocol.proto</summary>
    public static partial class FingerprintProtocolReflection
    {

        #region Descriptor
        /// <summary>File descriptor for FingerprintProtocol.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static FingerprintProtocolReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "ChlGaW5nZXJwcmludFByb3RvY29sLnByb3RvIjgKEkxvZ2ljYWxGaW5nZXJw",
                  "cmludBIRCgdjb250ZW50GAEgASgMSABCDwoNY29udGVudF9vbmVvZiLSAQoU",
                  "Q29tYmluZWRGaW5nZXJwcmludHMSEQoHdmVyc2lvbhgBIAEoDUgAEi8KEGxv",
                  "Y2FsRmluZ2VycHJpbnQYAiABKAsyEy5Mb2dpY2FsRmluZ2VycHJpbnRIARIw",
                  "ChFyZW1vdGVGaW5nZXJwcmludBgDIAEoCzITLkxvZ2ljYWxGaW5nZXJwcmlu",
                  "dEgCQg8KDXZlcnNpb25fb25lb2ZCGAoWbG9jYWxGaW5nZXJwcmludF9vbmVv",
                  "ZkIZChdyZW1vdGVGaW5nZXJwcmludF9vbmVvZkIYqgIVbGlic2lnbmFsLmZp",
                  "bmdlcnByaW50YgZwcm90bzM="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { },
                new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint), global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint.Parser, new[]{ "Content" }, new[]{ "ContentOneof" }, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::citronindo.cryptolib.signal.fingerprint.CombinedFingerprints), global::citronindo.cryptolib.signal.fingerprint.CombinedFingerprints.Parser, new[]{ "Version", "LocalFingerprint", "RemoteFingerprint" }, new[]{ "VersionOneof", "LocalFingerprintOneof", "RemoteFingerprintOneof" }, null, null)
                }));
        }
        #endregion

    }
    #region Messages
    public sealed partial class LogicalFingerprint : pb::IMessage<LogicalFingerprint>
    {
        private static readonly pb::MessageParser<LogicalFingerprint> _parser = new pb::MessageParser<LogicalFingerprint>(() => new LogicalFingerprint());
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<LogicalFingerprint> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::citronindo.cryptolib.signal.fingerprint.FingerprintProtocolReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LogicalFingerprint()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LogicalFingerprint(LogicalFingerprint other) : this()
        {
            switch (other.ContentOneofCase)
            {
                case ContentOneofOneofCase.Content:
                    Content = other.Content;
                    break;
            }

        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LogicalFingerprint Clone()
        {
            return new LogicalFingerprint(this);
        }

        /// <summary>Field number for the "content" field.</summary>
        public const int ContentFieldNumber = 1;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pb::ByteString Content
        {
            get { return contentOneofCase_ == ContentOneofOneofCase.Content ? (pb::ByteString)contentOneof_ : pb::ByteString.Empty; }
            set
            {
                contentOneof_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
                contentOneofCase_ = ContentOneofOneofCase.Content;
            }
        }

        private object contentOneof_;
        /// <summary>Enum of possible cases for the "content_oneof" oneof.</summary>
        public enum ContentOneofOneofCase
        {
            None = 0,
            Content = 1,
        }
        private ContentOneofOneofCase contentOneofCase_ = ContentOneofOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ContentOneofOneofCase ContentOneofCase
        {
            get { return contentOneofCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearContentOneof()
        {
            contentOneofCase_ = ContentOneofOneofCase.None;
            contentOneof_ = null;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as LogicalFingerprint);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(LogicalFingerprint other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Content != other.Content) return false;
            if (ContentOneofCase != other.ContentOneofCase) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (contentOneofCase_ == ContentOneofOneofCase.Content) hash ^= Content.GetHashCode();
            hash ^= (int)contentOneofCase_;
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (contentOneofCase_ == ContentOneofOneofCase.Content)
            {
                output.WriteRawTag(10);
                output.WriteBytes(Content);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (contentOneofCase_ == ContentOneofOneofCase.Content)
            {
                size += 1 + pb::CodedOutputStream.ComputeBytesSize(Content);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(LogicalFingerprint other)
        {
            if (other == null)
            {
                return;
            }
            switch (other.ContentOneofCase)
            {
                case ContentOneofOneofCase.Content:
                    Content = other.Content;
                    break;
            }

        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 10:
                        {
                            Content = input.ReadBytes();
                            break;
                        }
                }
            }
        }

    }

    public sealed partial class CombinedFingerprints : pb::IMessage<CombinedFingerprints>
    {
        private static readonly pb::MessageParser<CombinedFingerprints> _parser = new pb::MessageParser<CombinedFingerprints>(() => new CombinedFingerprints());
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<CombinedFingerprints> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::citronindo.cryptolib.signal.fingerprint.FingerprintProtocolReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public CombinedFingerprints()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public CombinedFingerprints(CombinedFingerprints other) : this()
        {
            switch (other.VersionOneofCase)
            {
                case VersionOneofOneofCase.Version:
                    Version = other.Version;
                    break;
            }

            switch (other.LocalFingerprintOneofCase)
            {
                case LocalFingerprintOneofOneofCase.LocalFingerprint:
                    LocalFingerprint = other.LocalFingerprint.Clone();
                    break;
            }

            switch (other.RemoteFingerprintOneofCase)
            {
                case RemoteFingerprintOneofOneofCase.RemoteFingerprint:
                    RemoteFingerprint = other.RemoteFingerprint.Clone();
                    break;
            }

        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public CombinedFingerprints Clone()
        {
            return new CombinedFingerprints(this);
        }

        /// <summary>Field number for the "version" field.</summary>
        public const int VersionFieldNumber = 1;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint Version
        {
            get { return versionOneofCase_ == VersionOneofOneofCase.Version ? (uint)versionOneof_ : 0; }
            set
            {
                versionOneof_ = value;
                versionOneofCase_ = VersionOneofOneofCase.Version;
            }
        }

        /// <summary>Field number for the "localFingerprint" field.</summary>
        public const int LocalFingerprintFieldNumber = 2;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint LocalFingerprint
        {
            get { return localFingerprintOneofCase_ == LocalFingerprintOneofOneofCase.LocalFingerprint ? (global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint)localFingerprintOneof_ : null; }
            set
            {
                localFingerprintOneof_ = value;
                localFingerprintOneofCase_ = value == null ? LocalFingerprintOneofOneofCase.None : LocalFingerprintOneofOneofCase.LocalFingerprint;
            }
        }

        /// <summary>Field number for the "remoteFingerprint" field.</summary>
        public const int RemoteFingerprintFieldNumber = 3;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint RemoteFingerprint
        {
            get { return remoteFingerprintOneofCase_ == RemoteFingerprintOneofOneofCase.RemoteFingerprint ? (global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint)remoteFingerprintOneof_ : null; }
            set
            {
                remoteFingerprintOneof_ = value;
                remoteFingerprintOneofCase_ = value == null ? RemoteFingerprintOneofOneofCase.None : RemoteFingerprintOneofOneofCase.RemoteFingerprint;
            }
        }

        private object versionOneof_;
        /// <summary>Enum of possible cases for the "version_oneof" oneof.</summary>
        public enum VersionOneofOneofCase
        {
            None = 0,
            Version = 1,
        }
        private VersionOneofOneofCase versionOneofCase_ = VersionOneofOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public VersionOneofOneofCase VersionOneofCase
        {
            get { return versionOneofCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearVersionOneof()
        {
            versionOneofCase_ = VersionOneofOneofCase.None;
            versionOneof_ = null;
        }

        private object localFingerprintOneof_;
        /// <summary>Enum of possible cases for the "localFingerprint_oneof" oneof.</summary>
        public enum LocalFingerprintOneofOneofCase
        {
            None = 0,
            LocalFingerprint = 2,
        }
        private LocalFingerprintOneofOneofCase localFingerprintOneofCase_ = LocalFingerprintOneofOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public LocalFingerprintOneofOneofCase LocalFingerprintOneofCase
        {
            get { return localFingerprintOneofCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearLocalFingerprintOneof()
        {
            localFingerprintOneofCase_ = LocalFingerprintOneofOneofCase.None;
            localFingerprintOneof_ = null;
        }

        private object remoteFingerprintOneof_;
        /// <summary>Enum of possible cases for the "remoteFingerprint_oneof" oneof.</summary>
        public enum RemoteFingerprintOneofOneofCase
        {
            None = 0,
            RemoteFingerprint = 3,
        }
        private RemoteFingerprintOneofOneofCase remoteFingerprintOneofCase_ = RemoteFingerprintOneofOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public RemoteFingerprintOneofOneofCase RemoteFingerprintOneofCase
        {
            get { return remoteFingerprintOneofCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearRemoteFingerprintOneof()
        {
            remoteFingerprintOneofCase_ = RemoteFingerprintOneofOneofCase.None;
            remoteFingerprintOneof_ = null;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as CombinedFingerprints);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(CombinedFingerprints other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Version != other.Version) return false;
            if (!object.Equals(LocalFingerprint, other.LocalFingerprint)) return false;
            if (!object.Equals(RemoteFingerprint, other.RemoteFingerprint)) return false;
            if (VersionOneofCase != other.VersionOneofCase) return false;
            if (LocalFingerprintOneofCase != other.LocalFingerprintOneofCase) return false;
            if (RemoteFingerprintOneofCase != other.RemoteFingerprintOneofCase) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (versionOneofCase_ == VersionOneofOneofCase.Version) hash ^= Version.GetHashCode();
            if (localFingerprintOneofCase_ == LocalFingerprintOneofOneofCase.LocalFingerprint) hash ^= LocalFingerprint.GetHashCode();
            if (remoteFingerprintOneofCase_ == RemoteFingerprintOneofOneofCase.RemoteFingerprint) hash ^= RemoteFingerprint.GetHashCode();
            hash ^= (int)versionOneofCase_;
            hash ^= (int)localFingerprintOneofCase_;
            hash ^= (int)remoteFingerprintOneofCase_;
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (versionOneofCase_ == VersionOneofOneofCase.Version)
            {
                output.WriteRawTag(8);
                output.WriteUInt32(Version);
            }
            if (localFingerprintOneofCase_ == LocalFingerprintOneofOneofCase.LocalFingerprint)
            {
                output.WriteRawTag(18);
                output.WriteMessage(LocalFingerprint);
            }
            if (remoteFingerprintOneofCase_ == RemoteFingerprintOneofOneofCase.RemoteFingerprint)
            {
                output.WriteRawTag(26);
                output.WriteMessage(RemoteFingerprint);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (versionOneofCase_ == VersionOneofOneofCase.Version)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Version);
            }
            if (localFingerprintOneofCase_ == LocalFingerprintOneofOneofCase.LocalFingerprint)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LocalFingerprint);
            }
            if (remoteFingerprintOneofCase_ == RemoteFingerprintOneofOneofCase.RemoteFingerprint)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(RemoteFingerprint);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(CombinedFingerprints other)
        {
            if (other == null)
            {
                return;
            }
            switch (other.VersionOneofCase)
            {
                case VersionOneofOneofCase.Version:
                    Version = other.Version;
                    break;
            }

            switch (other.LocalFingerprintOneofCase)
            {
                case LocalFingerprintOneofOneofCase.LocalFingerprint:
                    LocalFingerprint = other.LocalFingerprint;
                    break;
            }

            switch (other.RemoteFingerprintOneofCase)
            {
                case RemoteFingerprintOneofOneofCase.RemoteFingerprint:
                    RemoteFingerprint = other.RemoteFingerprint;
                    break;
            }

        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 8:
                        {
                            Version = input.ReadUInt32();
                            break;
                        }
                    case 18:
                        {
                            global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint subBuilder = new global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint();
                            if (localFingerprintOneofCase_ == LocalFingerprintOneofOneofCase.LocalFingerprint)
                            {
                                subBuilder.MergeFrom(LocalFingerprint);
                            }
                            input.ReadMessage(subBuilder);
                            LocalFingerprint = subBuilder;
                            break;
                        }
                    case 26:
                        {
                            global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint subBuilder = new global::citronindo.cryptolib.signal.fingerprint.LogicalFingerprint();
                            if (remoteFingerprintOneofCase_ == RemoteFingerprintOneofOneofCase.RemoteFingerprint)
                            {
                                subBuilder.MergeFrom(RemoteFingerprint);
                            }
                            input.ReadMessage(subBuilder);
                            RemoteFingerprint = subBuilder;
                            break;
                        }
                }
            }
        }

    }

    #endregion

}

#endregion Designer generated code

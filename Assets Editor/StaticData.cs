// <made-by>
//     Static-Data reader/writer maded by @marcosvf132.
//     'Assets-Editor' source: @arch-mina.
//		To-Do list:
//		- House (with images)
//		- Achievments
// </made-by>
#pragma warning disable 1591, 0612, 3021
#region StaticData by marcosvf132

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
namespace Tibia.Protobuf.StaticData
{

    /// <summary>Holder for reflection information generated from StaticDatas.proto</summary>
    public static partial class StaticDataReflection
    {

        #region Descriptor
        /// <summary>File descriptor for StaticDatas.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static StaticDataReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "ChFhcHBlYXJhbmNlcy5wcm90bxIadGliaWEucHJvdG9idWYuYXBwZWFyYW5j",
                  "ZXMaDHNoYXJlZC5wcm90byLPAgoLQXBwZWFyYW5jZXMSNgoGb2JqZWN0GAEg",
                  "AygLMiYudGliaWEucHJvdG9idWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5jZRI2",
                  "CgZvdXRmaXQYAiADKAsyJi50aWJpYS5wcm90b2J1Zi5hcHBlYXJhbmNlcy5B",
                  "cHBlYXJhbmNlEjYKBmVmZmVjdBgDIAMoCzImLnRpYmlhLnByb3RvYnVmLmFw",
                  "cGVhcmFuY2VzLkFwcGVhcmFuY2USNwoHbWlzc2lsZRgEIAMoCzImLnRpYmlh",
                  "LnByb3RvYnVmLmFwcGVhcmFuY2VzLkFwcGVhcmFuY2USXwoec3BlY2lhbF9t",
                  "ZWFuaW5nX2FwcGVhcmFuY2VfaWRzGAUgASgLMjcudGliaWEucHJvdG9idWYu",
                  "YXBwZWFyYW5jZXMuU3BlY2lhbE1lYW5pbmdBcHBlYXJhbmNlSWRzIjkKC1Nw",
                  "cml0ZVBoYXNlEhQKDGR1cmF0aW9uX21pbhgBIAEoDRIUCgxkdXJhdGlvbl9t",
                  "YXgYAiABKA0i8gEKD1Nwcml0ZUFuaW1hdGlvbhIbChNkZWZhdWx0X3N0YXJ0",
                  "X3BoYXNlGAEgASgNEhQKDHN5bmNocm9uaXplZBgCIAEoCBIaChJyYW5kb21f",
                  "c3RhcnRfcGhhc2UYAyABKAgSPQoJbG9vcF90eXBlGAQgASgOMioudGliaWEu",
                  "cHJvdG9idWYuc2hhcmVkLkFOSU1BVElPTl9MT09QX1RZUEUSEgoKbG9vcF9j",
                  "b3VudBgFIAEoDRI9CgxzcHJpdGVfcGhhc2UYBiADKAsyJy50aWJpYS5wcm90",
                  "b2J1Zi5hcHBlYXJhbmNlcy5TcHJpdGVQaGFzZSI6CgNCb3gSCQoBeBgBIAEo",
                  "DRIJCgF5GAIgASgNEg0KBXdpZHRoGAMgASgNEg4KBmhlaWdodBgEIAEoDSKm",
                  "AgoKU3ByaXRlSW5mbxIVCg1wYXR0ZXJuX3dpZHRoGAEgASgNEhYKDnBhdHRl",
                  "cm5faGVpZ2h0GAIgASgNEhUKDXBhdHRlcm5fZGVwdGgYAyABKA0SDgoGbGF5",
                  "ZXJzGAQgASgNEhEKCXNwcml0ZV9pZBgFIAMoDRIXCg9ib3VuZGluZ19zcXVh",
                  "cmUYByABKA0SPgoJYW5pbWF0aW9uGAYgASgLMisudGliaWEucHJvdG9idWYu",
                  "YXBwZWFyYW5jZXMuU3ByaXRlQW5pbWF0aW9uEhEKCWlzX29wYXF1ZRgIIAEo",
                  "CBJDChpib3VuZGluZ19ib3hfcGVyX2RpcmVjdGlvbhgJIAMoCzIfLnRpYmlh",
                  "LnByb3RvYnVmLmFwcGVhcmFuY2VzLkJveCKfAQoKRnJhbWVHcm91cBJIChFm",
                  "aXhlZF9mcmFtZV9ncm91cBgBIAEoDjItLnRpYmlhLnByb3RvYnVmLmFwcGVh",
                  "cmFuY2VzLkZJWEVEX0ZSQU1FX0dST1VQEgoKAmlkGAIgASgNEjsKC3Nwcml0",
                  "ZV9pbmZvGAMgASgLMiYudGliaWEucHJvdG9idWYuYXBwZWFyYW5jZXMuU3By",
                  "aXRlSW5mbyK0AQoKQXBwZWFyYW5jZRIKCgJpZBgBIAEoDRI7CgtmcmFtZV9n",
                  "cm91cBgCIAMoCzImLnRpYmlhLnByb3RvYnVmLmFwcGVhcmFuY2VzLkZyYW1l",
                  "R3JvdXASOgoFZmxhZ3MYAyABKAsyKy50aWJpYS5wcm90b2J1Zi5hcHBlYXJh",
                  "bmNlcy5BcHBlYXJhbmNlRmxhZ3MSDAoEbmFtZRgEIAEoCRITCgtkZXNjcmlw",
                  "dGlvbhgFIAEoCSLADAoPQXBwZWFyYW5jZUZsYWdzEjwKBGJhbmsYASABKAsy",
                  "Li50aWJpYS5wcm90b2J1Zi5hcHBlYXJhbmNlcy5BcHBlYXJhbmNlRmxhZ0Jh",
                  "bmsSDAoEY2xpcBgCIAEoCBIOCgZib3R0b20YAyABKAgSCwoDdG9wGAQgASgI",
                  "EhEKCWNvbnRhaW5lchgFIAEoCBISCgpjdW11bGF0aXZlGAYgASgIEg4KBnVz",
                  "YWJsZRgHIAEoCBIQCghmb3JjZXVzZRgIIAEoCBIQCghtdWx0aXVzZRgJIAEo",
                  "CBI+CgV3cml0ZRgKIAEoCzIvLnRpYmlhLnByb3RvYnVmLmFwcGVhcmFuY2Vz",
                  "LkFwcGVhcmFuY2VGbGFnV3JpdGUSRwoKd3JpdGVfb25jZRgLIAEoCzIzLnRp",
                  "YmlhLnByb3RvYnVmLmFwcGVhcmFuY2VzLkFwcGVhcmFuY2VGbGFnV3JpdGVP",
                  "bmNlEhIKCmxpcXVpZHBvb2wYDCABKAgSDgoGdW5wYXNzGA0gASgIEg4KBnVu",
                  "bW92ZRgOIAEoCBIPCgd1bnNpZ2h0GA8gASgIEg0KBWF2b2lkGBAgASgIEh0K",
                  "FW5vX21vdmVtZW50X2FuaW1hdGlvbhgRIAEoCBIMCgR0YWtlGBIgASgIEhcK",
                  "D2xpcXVpZGNvbnRhaW5lchgTIAEoCBIMCgRoYW5nGBQgASgIEjwKBGhvb2sY",
                  "FSABKAsyLi50aWJpYS5wcm90b2J1Zi5hcHBlYXJhbmNlcy5BcHBlYXJhbmNl",
                  "RmxhZ0hvb2sSDgoGcm90YXRlGBYgASgIEj4KBWxpZ2h0GBcgASgLMi8udGli",
                  "aWEucHJvdG9idWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5jZUZsYWdMaWdodBIR",
                  "Cglkb250X2hpZGUYGCABKAgSEwoLdHJhbnNsdWNlbnQYGSABKAgSPgoFc2hp",
                  "ZnQYGiABKAsyLy50aWJpYS5wcm90b2J1Zi5hcHBlYXJhbmNlcy5BcHBlYXJh",
                  "bmNlRmxhZ1NoaWZ0EkAKBmhlaWdodBgbIAEoCzIwLnRpYmlhLnByb3RvYnVm",
                  "LmFwcGVhcmFuY2VzLkFwcGVhcmFuY2VGbGFnSGVpZ2h0EhQKDGx5aW5nX29i",
                  "amVjdBgcIAEoCBIWCg5hbmltYXRlX2Fsd2F5cxgdIAEoCBJCCgdhdXRvbWFw",
                  "GB4gASgLMjEudGliaWEucHJvdG9idWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5j",
                  "ZUZsYWdBdXRvbWFwEkQKCGxlbnNoZWxwGB8gASgLMjIudGliaWEucHJvdG9i",
                  "dWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5jZUZsYWdMZW5zaGVscBIQCghmdWxs",
                  "YmFuaxggIAEoCBITCgtpZ25vcmVfbG9vaxghIAEoCBJCCgdjbG90aGVzGCIg",
                  "ASgLMjEudGliaWEucHJvdG9idWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5jZUZs",
                  "YWdDbG90aGVzEk8KDmRlZmF1bHRfYWN0aW9uGCMgASgLMjcudGliaWEucHJv",
                  "dG9idWYuYXBwZWFyYW5jZXMuQXBwZWFyYW5jZUZsYWdEZWZhdWx0QWN0aW9u",
                  "EkAKBm1hcmtldBgkIAEoCzIwLnRpYmlhLnByb3RvYnVmLmFwcGVhcmFuY2Vz",
                  "LkFwcGVhcmFuY2VGbGFnTWFya2V0EgwKBHdyYXAYJSABKAgSDgoGdW53cmFw",
                  "GCYgASgIEhEKCXRvcGVmZmVjdBgnIAEoCBJCCgtucGNzYWxlZGF0YRgoIAMo",
                  "CzItLnRpYmlhLnByb3RvYnVmLmFwcGVhcmFuY2VzLkFwcGVhcmFuY2VGbGFn",
                  "TlBDElIKD2NoYW5nZWR0b2V4cGlyZRgpIAEoCzI5LnRpYmlhLnByb3RvYnVm",
                  "LmFwcGVhcmFuY2VzLkFwcGVhcmFuY2VGbGFnQ2hhbmdlZFRvRXhwaXJlEg4K",
                  "BmNvcnBzZRgqIAEoCBIVCg1wbGF5ZXJfY29ycHNlGCsgASgIEkwKDmN5Y2xv",
                  "cGVkaWFpdGVtGCwgASgLMjQudGliaWEucHJvdG9idWYuYXBwZWFyYW5jZXMu",
                  "QXBwZWFyYW5jZUZsYWdDeWNsb3BlZGlhEgwKBGFtbW8YLSABKAgiJwoSQXBw",
                  "ZWFyYW5jZUZsYWdCYW5rEhEKCXdheXBvaW50cxgBIAEoDSIuChNBcHBlYXJh",
                  "bmNlRmxhZ1dyaXRlEhcKD21heF90ZXh0X2xlbmd0aBgBIAEoDSI3ChdBcHBl",
                  "YXJhbmNlRmxhZ1dyaXRlT25jZRIcChRtYXhfdGV4dF9sZW5ndGhfb25jZRgB",
                  "IAEoDSI4ChNBcHBlYXJhbmNlRmxhZ0xpZ2h0EhIKCmJyaWdodG5lc3MYASAB",
                  "KA0SDQoFY29sb3IYAiABKA0iKQoUQXBwZWFyYW5jZUZsYWdIZWlnaHQSEQoJ",
                  "ZWxldmF0aW9uGAEgASgNIisKE0FwcGVhcmFuY2VGbGFnU2hpZnQSCQoBeBgB",
                  "IAEoDRIJCgF5GAIgASgNIiUKFUFwcGVhcmFuY2VGbGFnQ2xvdGhlcxIMCgRz",
                  "bG90GAEgASgNIlMKG0FwcGVhcmFuY2VGbGFnRGVmYXVsdEFjdGlvbhI0CgZh",
                  "Y3Rpb24YASABKA4yJC50aWJpYS5wcm90b2J1Zi5zaGFyZWQuUExBWUVSX0FD",
                  "VElPTiLmAQoUQXBwZWFyYW5jZUZsYWdNYXJrZXQSNgoIY2F0ZWdvcnkYASAB",
                  "KA4yJC50aWJpYS5wcm90b2J1Zi5zaGFyZWQuSVRFTV9DQVRFR09SWRIaChJ0",
                  "cmFkZV9hc19vYmplY3RfaWQYAiABKA0SGQoRc2hvd19hc19vYmplY3RfaWQY",
                  "AyABKA0SSAoWcmVzdHJpY3RfdG9fcHJvZmVzc2lvbhgFIAMoDjIoLnRpYmlh",
                  "LnByb3RvYnVmLnNoYXJlZC5QTEFZRVJfUFJPRkVTU0lPThIVCg1taW5pbXVt",
                  "X2xldmVsGAYgASgNIqUBChFBcHBlYXJhbmNlRmxhZ05QQxIMCgRuYW1lGAEg",
                  "ASgJEhAKCGxvY2F0aW9uGAIgASgJEhIKCnNhbGVfcHJpY2UYAyABKA0SEQoJ",
                  "YnV5X3ByaWNlGAQgASgNEh8KF2N1cnJlbmN5X29iamVjdF90eXBlX2lkGAUg",
                  "ASgNEigKIGN1cnJlbmN5X3F1ZXN0X2ZsYWdfZGlzcGxheV9uYW1lGAYgASgJ",
                  "IiYKFUFwcGVhcmFuY2VGbGFnQXV0b21hcBINCgVjb2xvchgBIAEoDSJJChJB",
                  "cHBlYXJhbmNlRmxhZ0hvb2sSMwoJZGlyZWN0aW9uGAEgASgOMiAudGliaWEu",
                  "cHJvdG9idWYuc2hhcmVkLkhPT0tfVFlQRSIkChZBcHBlYXJhbmNlRmxhZ0xl",
                  "bnNoZWxwEgoKAmlkGAEgASgNIj0KHUFwcGVhcmFuY2VGbGFnQ2hhbmdlZFRv",
                  "RXhwaXJlEhwKFGZvcm1lcl9vYmplY3RfdHlwZWlkGAEgASgNIjMKGEFwcGVh",
                  "cmFuY2VGbGFnQ3ljbG9wZWRpYRIXCg9jeWNsb3BlZGlhX3R5cGUYASABKA0i",
                  "sQEKG1NwZWNpYWxNZWFuaW5nQXBwZWFyYW5jZUlkcxIUCgxnb2xkX2NvaW5f",
                  "aWQYASABKA0SGAoQcGxhdGludW1fY29pbl9pZBgCIAEoDRIXCg9jcnlzdGFs",
                  "X2NvaW5faWQYAyABKA0SFQoNdGliaWFfY29pbl9pZBgEIAEoDRIZChFzdGFt",
                  "cGVkX2xldHRlcl9pZBgFIAEoDRIXCg9zdXBwbHlfc3Rhc2hfaWQYBiABKA0q",
                  "gQEKEUZJWEVEX0ZSQU1FX0dST1VQEiEKHUZJWEVEX0ZSQU1FX0dST1VQX09V",
                  "VEZJVF9JRExFEAASIwofRklYRURfRlJBTUVfR1JPVVBfT1VURklUX01PVklO",
                  "RxABEiQKIEZJWEVEX0ZSQU1FX0dST1VQX09CSkVDVF9JTklUSUFMEAI="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { global::Tibia.Protobuf.Shared.SharedReflection.Descriptor, },
                new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
                    new pbr::GeneratedClrTypeInfo(typeof(global::Tibia.Protobuf.StaticData.StaticData), global::Tibia.Protobuf.StaticData.StaticData.Parser, new[]{ "Monsters" }, null, null, null, null), /// , "Achiev", "Houses"
                    new pbr::GeneratedClrTypeInfo(typeof(global::Tibia.Protobuf.StaticData.StaticDataLookChild), global::Tibia.Protobuf.StaticData.StaticDataLookChild.Parser, new[]{ "LookTypeEx", "LookType", "LookTypeExValue", "LookTypeValue", "LookColors" }, null, null, null, null),
                    new pbr::GeneratedClrTypeInfo(typeof(global::Tibia.Protobuf.StaticData.StaticDataLookColors), global::Tibia.Protobuf.StaticData.StaticDataLookColors.Parser, new[]{ "LookHead", "LookBody", "LookLegs", "LookFeet", "Addon" }, null, null, null, null)

                }));
        }
        #endregion
    }

    public class Monsterptr
    {
        private uint raceid = 0;
        private string name = "name";
        private bool looktypeexbool = false;
        private uint looktypeex = 0;
        private bool looktypebool = true;
        private uint looktype = 0;
        private uint lookhead = 0;
        private uint lookbody = 0;
        private uint looklegs = 0;
        private uint lookfeet = 0;
        private uint addon = 0;
        public uint RaceId { get { return raceid; } set { raceid = value; } }
        public string Name { get { return name; } set { name = value; } }
        public bool LookTypeExBool { get { return looktypeexbool; } set { looktypeexbool = value; } }
        public uint LookTypeEx { get { return looktypeex; } set { looktypeex = value; } }
        public bool LookTypeBool { get { return looktypebool; } set { looktypebool = value; } }
        public uint LookType { get { return looktype; } set { looktype = value; } }
        public uint LookHead { get { return lookhead; } set { lookhead = value; } }
        public uint LookBody { get { return lookbody; } set { lookbody = value; } }
        public uint LookLegs { get { return looklegs; } set { looklegs = value; } }
        public uint LookFeet { get { return lookfeet; } set { lookfeet = value; } }
        public uint Addon { get { return addon; } set { addon = value; } }

    }

    #region Messages
    public sealed partial class StaticData : pb::IMessage<StaticData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
    {

        private static readonly pb::MessageParser<StaticData> _parser = new pb::MessageParser<StaticData>(() => new StaticData());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<StaticData> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Tibia.Protobuf.StaticData.StaticDataReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticData()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticData(StaticData other) : this()
        {
            Monsters_ = other.Monsters_.Clone();
         ///   Achiev_ = other.Achiev_.Clone();
         ///   Houses_ = other.Houses_.Clone();
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticData Clone()
        {
            return new StaticData(this);
        }

        /// <summary>Field number for the "Monsters" field.</summary>
        public const int ObjectFieldNumber = 1;
        private static readonly pb::FieldCodec<global::Tibia.Protobuf.StaticData.StaticDataMonster> _repeated_Monsters_codec
            = pb::FieldCodec.ForMessage(10, global::Tibia.Protobuf.StaticData.StaticDataMonster.Parser);
        private readonly pbc::RepeatedField<global::Tibia.Protobuf.StaticData.StaticDataMonster> Monsters_ = new pbc::RepeatedField<global::Tibia.Protobuf.StaticData.StaticDataMonster>();
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::Tibia.Protobuf.StaticData.StaticDataMonster> Monsters
        {
            get { return Monsters_; }
        }

        /// <summary>Field number for the "Achievments" field.</summary>
      ///  public const int AchievFieldNumber = 2;
       /// private static readonly pb::FieldCodec<global::Tibia.Protobuf.StaticDatas.StaticData> _repeated_Achiev_codec
       ///     = pb::FieldCodec.ForMessage(18, global::Tibia.Protobuf.StaticDatas.StaticData.Parser);
       /// private readonly pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData> Achiev_ = new pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData>();
       /// [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
       /// public pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData> Achiev
        ///{
        ///    get { return Achiev_; }
        ///}

        /// <summary>Field number for the "Houses" field.</summary>
       /// public const int HousesFieldNumber = 3;
       /// private static readonly pb::FieldCodec<global::Tibia.Protobuf.StaticDatas.StaticData> _repeated_Houses_codec
       ///     = pb::FieldCodec.ForMessage(26, global::Tibia.Protobuf.StaticDatas.StaticData.Parser);
       /// private readonly pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData> Houses_ = new pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData>();
       /// [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        ///public pbc::RepeatedField<global::Tibia.Protobuf.StaticDatas.StaticData> Houses
        ///{
        ///    get { return Houses_; }
        ///}

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as StaticData);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StaticData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!Monsters_.Equals(other.Monsters_)) return false;
            //if (!Achiev_.Equals(other.Achiev_)) return false;
            //if (!Houses_.Equals(other.Houses_)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            hash ^= Monsters_.GetHashCode();
            //hash ^= Achiev_.GetHashCode();
            //hash ^= Houses_.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
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
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      Monsters_.WriteTo(output, _repeated_Monsters_codec);
     // Achiev_.WriteTo(output, _repeated_Achiev_codec);
     // Houses_.WriteTo(output, _repeated_Houses_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            Monsters_.WriteTo(ref output, _repeated_Monsters_codec);
           // Achiev_.WriteTo(ref output, _repeated_Achiev_codec);
          //  Houses_.WriteTo(ref output, _repeated_Houses_codec);
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            size += Monsters_.CalculateSize(_repeated_Monsters_codec);
           // size += Achiev_.CalculateSize(_repeated_Achiev_codec);
           // size += Houses_.CalculateSize(_repeated_Houses_codec);
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StaticData other)
        {
            if (other == null)
            {
                return;
            }
            Monsters_.Add(other.Monsters_);
            //Achiev_.Add(other.Achiev_);
            //Houses_.Add(other.Houses_);
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Monsters_.AddEntriesFrom(input, _repeated_Monsters_codec);
            break;
          }
         // case 18: {
           // Achiev_.AddEntriesFrom(input, _repeated_Achiev_codec);
            break;
        //  }
        //  case 26: {
           // Houses_.AddEntriesFrom(input, _repeated_Houses_codec);
        //    break;
        //  }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 10:
                        {
                            Monsters_.AddEntriesFrom(ref input, _repeated_Monsters_codec);
                            break;
                        }
                  ///  case 18:
                 ///       {
                       //     Achiev_.AddEntriesFrom(ref input, _repeated_Achiev_codec);
                 ///           break;
                 ///       }
                 ///   case 26:
                 ///       {
                      //      Houses_.AddEntriesFrom(ref input, _repeated_Houses_codec);
                  ///          break;
                  ///      }
                }
            }
        }
#endif

    }

    public sealed partial class StaticDataMonster : pb::IMessage<StaticDataMonster>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<StaticDataMonster> _parser = new pb::MessageParser<StaticDataMonster>(() => new StaticDataMonster());
        private pb::UnknownFieldSet _unknownFields;
        private int _hasBits0;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<StaticDataMonster> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Tibia.Protobuf.StaticData.StaticDataReflection.Descriptor.MessageTypes[4]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataMonster()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataMonster(StaticDataMonster other) : this()
        {
            _hasBits0 = other._hasBits0;
            RaceId_ = other.RaceId_;
            Name_ = other.Name_;
            LookChild = other.LookChild_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataMonster Clone()
        {
            return new StaticDataMonster(this);
        }

        /// <summary>Field number for the "RaceId" field.</summary>
        public const int RaceIdFieldNumber = 1;
        private readonly static uint RaceIdDefaultValue = 0;

        private uint RaceId_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint RaceId
        {
            get { if ((_hasBits0 & 1) != 0) { return RaceId_; } else { return RaceIdDefaultValue; } }
            set
            {
                _hasBits0 |= 1;
                RaceId_ = value;
            }
        }
        /// <summary>Gets whether the "RaceId" field is set</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool HasRaceId
        {
            get { return (_hasBits0 & 1) != 0; }
        }
        /// <summary>Clears the value of the "RaceId" field</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearRaceId()
        {
            _hasBits0 &= ~1;
        }

        /// <summary>Field number for the "Name" field.</summary>
        public const int NameFieldNumber = 2;
        private readonly static string NameDefaultValue = "";

        private string Name_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name
        {
            get { return Name_ ?? NameDefaultValue; }
            set
            {
                Name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }
        /// <summary>Gets whether the "Name" field is set</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool HasName
        {
            get { return Name_ != null; }
        }
        /// <summary>Clears the value of the "Name" field</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearName()
        {
            Name_ = null;
        }

        /// <summary>Field number for the "LookChild" field.</summary>
        public const int LookChildFieldNumber = 3;
        private global::Tibia.Protobuf.StaticData.StaticDataLookChild LookChild_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Tibia.Protobuf.StaticData.StaticDataLookChild LookChild
        {
            get { return LookChild_; }
            set
            {
                LookChild_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as StaticDataMonster);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StaticDataMonster other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (RaceId != other.RaceId) return false;
            if (Name != other.Name) return false;
            if (!object.Equals(LookChild, other.LookChild)) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (HasRaceId) hash ^= RaceId.GetHashCode();
            if (HasName) hash ^= Name.GetHashCode();
            if (LookChild_ != null) hash ^= LookChild.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
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
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      if (HasRaceId) {
        output.WriteRawTag(8);
        output.WriteUInt32(Id);
      }
      if (HasName) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (LookChild_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(LookChild);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            if (HasRaceId)
            {
                output.WriteRawTag(8);
                output.WriteUInt32(RaceId);
            }
            if (HasName)
            {
                output.WriteRawTag(18);
                output.WriteString(Name);
            }
            if (LookChild_ != null)
            {
                output.WriteRawTag(26);
                output.WriteMessage(LookChild);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (HasRaceId)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(RaceId);
            } 
            if (HasName)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
            }
            if (LookChild_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LookChild);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StaticDataMonster other)
        {
            if (other == null)
            {
                return;
            }
            if (other.HasRaceId)
            {
                RaceId = other.RaceId;
            }
            if (other.HasName)
            {
                Name = other.Name;
            }
            if (other.LookChild_ != null)
            {
                if (LookChild_ == null)
                {
                    LookChild = new global::Tibia.Protobuf.StaticData.StaticDataLookChild();
                }
                LookChild.MergeFrom(other.LookChild);
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RaceId = input.ReadUInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            if (LookChild_ == null) {
              LookChild = new global::Tibia.Protobuf.StaticDatas.StaticDataLookChild();
            }
            input.ReadMessage(LookChild);
            break;
          }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 8:
                        {
                            RaceId = input.ReadUInt32();
                            break;
                        }
                    case 18:
                        {
                            Name = input.ReadString();
                            break;
                        }
                    case 26:
                        {
                            if (LookChild_ == null)
                            {
                                LookChild = new global::Tibia.Protobuf.StaticData.StaticDataLookChild();
                            }
                            input.ReadMessage(LookChild);
                            break;
                        }
                }
            }
        }
#endif

    }

    public sealed partial class StaticDataLookChild : pb::IMessage<StaticDataLookChild>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<StaticDataLookChild> _parser = new pb::MessageParser<StaticDataLookChild>(() => new StaticDataLookChild());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<StaticDataLookChild> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Tibia.Protobuf.StaticData.StaticDataReflection.Descriptor.MessageTypes[6]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookChild()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookChild(StaticDataLookChild other) : this()
        {
            LookTypeEx_ = other.LookTypeEx_;
            LookTypeExValue_ = other.LookTypeExValue_;
            LookType_ = other.LookType_;
            LookTypeValue_ = other.LookTypeExValue_;
            LookColors_ = other.LookColors_.Clone();
            Addon_ = other.Addon_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookChild Clone()
        {
            return new StaticDataLookChild(this);
        }

        /// <summary>Field number for the "LookTypeEx" field.</summary>
        public const int LookTypeExFieldNumber = 1;
        private bool LookTypeEx_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool LookTypeEx
        {
            get { return LookTypeEx_; }
            set
            {
                LookTypeEx_ = value;
            }
        }

        /// <summary>Field number for the "LookType" field.</summary>
        public const int LookTypeFieldNumber = 2;
        private bool LookType_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool LookType
        {
            get { return LookType_; }
            set
            {
                LookType_ = value;
            }
        }

        /// <summary>Field number for the "LookTypeExValue" field.</summary>
        public const int LookTypeExValueFieldNumber = 3;
        private readonly static uint LookTypeExValueDefaultValue = 0;

        private uint LookTypeExValue_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookTypeExValue
        {
            get { if (LookTypeExValue_ >= 0) { return LookTypeExValue_; } else { return LookTypeExValueDefaultValue; } }
            set
            {
                LookTypeExValue_ = value;
            }
        }

        /// <summary>Field number for the "LookTypeValue" field.</summary>
        public const int LookTypeValueFieldNumber = 4;
        private readonly static uint LookTypeValueDefaultValue = 0;

        private uint LookTypeValue_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookTypeValue
        {
            get { if (LookTypeValue_ >= 0) { return LookTypeValue_; } else { return LookTypeValueDefaultValue; } }
            set
            {
                LookTypeValue_ = value;
            }
        }

        /// <summary>Field number for the "LookColors" field.</summary>
        public const int LookColorsFieldNumber = 5;
        private global::Tibia.Protobuf.StaticData.StaticDataLookColors LookColors_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Tibia.Protobuf.StaticData.StaticDataLookColors LookColors
        {
            get { return LookColors_; }
            set
            {
                LookColors_ = value;
            }
        }

        /// <summary>Field number for the "Addon" field.</summary>
        public const int AddonFieldNumber = 6;
        private readonly static uint AddonDefaultValue = 0;

        private uint Addon_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint Addon
        {
            get { if (Addon_ >= 0) { return Addon_; } else { return AddonDefaultValue; } }
            set
            {
                Addon_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as StaticDataLookChild);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StaticDataLookChild other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (!object.Equals(LookTypeEx, other.LookTypeEx)) return false;
            if (!object.Equals(LookType, other.LookType)) return false;
            if (!object.Equals(LookColors, other.LookColors)) return false;
            if (LookTypeExValue != other.LookTypeExValue) return false;
            if (LookTypeValue != other.LookTypeValue) return false;
            if (Addon != other.Addon) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (LookTypeEx_) hash ^= LookTypeEx.GetHashCode();
            if (LookTypeEx_) hash ^= LookTypeEx.GetHashCode();
            if (LookColors_ != null) hash ^= LookColors.GetHashCode();
            if (Addon >= 0) hash ^= Addon.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
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
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      if (LookTypeEx_) {
        output.WriteRawTag(32);
        output.WriteUInt32(LookTypeExValue);
      }
      else
      {
        output.WriteRawTag(8);
        output.WriteUInt32(LookTypeValue);
        output.WriteRawTag(18);
        output.WriteMessage(LookColors);
        if (Addon >= 0) {
          output.WriteRawTag(24);
          output.WriteUInt32(Addon);
        }
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            if (LookTypeEx_)
            {
                output.WriteRawTag(32);
                output.WriteUInt32(LookTypeExValue);
            }
            else
            {
                output.WriteRawTag(8);
                output.WriteUInt32(LookTypeValue);
                output.WriteRawTag(18);
                output.WriteMessage(LookColors);
                if (Addon >= 0)
                {
                    output.WriteRawTag(24);
                    output.WriteUInt32(Addon);
                }
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (LookTypeEx_)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookTypeExValue);
            }
            else
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookTypeValue);
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(LookColors);
                if (Addon >= 0)
                {
                    size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Addon);
                }
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StaticDataLookChild other)
        {
            if (other == null)
            {
                return;
            }
            if (other.LookTypeEx_)
            {
                LookTypeEx = true;
                LookType = false;
                LookTypeExValue = other.LookTypeExValue;
            }
            else
            {
                LookTypeEx = false;
                LookType = true;
                LookTypeValue = other.LookTypeValue;
                if (other.LookColors_ != null)
                {
                    if (LookColors_ == null)
                    {
                        LookColors = new global::Tibia.Protobuf.StaticData.StaticDataLookColors();
                    }
                    LookColors.MergeFrom(other.LookColors);
                }
            Addon = other.Addon;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            LookTypeEx = false;
            LookType = true;
            LookTypeValue = input.ReadUInt32();
            break;
          }
          case 18: {
                if (LookColors_ == null) {
                  LookColors = new global::Tibia.Protobuf.StaticDatas.StaticDataLookColors();
                }
                input.ReadMessage(LookColors);
                break;
            }
          case 24: {
            Addon = input.ReadUInt32();
            break;
            }
          case 32: {
            LookTypeEx = true;
            LookType = false;
            LookTypeExValue = input.ReadUInt32();
            break;
          }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 8:
                        {
                            LookTypeEx = false;
                            LookType = true;
                            LookTypeValue = input.ReadUInt32();
                            break;
                        }
                    case 18:
                        {
                            if (LookColors_ == null)
                            {
                                LookColors = new global::Tibia.Protobuf.StaticData.StaticDataLookColors();
                            }
                            input.ReadMessage(LookColors);
                            break;
                        }
                    case 24:
                        {
                            Addon = input.ReadUInt32();
                            break;
                        }
                    case 32:
                        {
                            LookTypeEx = true;
                            LookType = false;
                            LookTypeExValue = input.ReadUInt32();
                            break;
                        }
                }
            }
        }
#endif

    }


    public sealed partial class StaticDataLookColors : pb::IMessage<StaticDataLookColors>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<StaticDataLookColors> _parser = new pb::MessageParser<StaticDataLookColors>(() => new StaticDataLookColors());
        private pb::UnknownFieldSet _unknownFields;
        private int _hasBits0;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<StaticDataLookColors> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Tibia.Protobuf.StaticData.StaticDataReflection.Descriptor.MessageTypes[4]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookColors()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookColors(StaticDataLookColors other) : this()
        {
            _hasBits0 = other._hasBits0;
            LookHead_ = other.LookHead_;
            LookBody_ = other.LookBody_;
            LookLegs_ = other.LookLegs_;
            LookFeet_ = other.LookFeet_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public StaticDataLookColors Clone()
        {
            return new StaticDataLookColors(this);
        }

        /// <summary>Field number for the "LookHead" field.</summary>
        public const int LookHeadFieldNumber = 1;
        private readonly static uint LookHeadDefaultValue = 0;

        private uint LookHead_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookHead
        {
            get { if (LookHead_ >= 0) { return LookHead_; } else { return LookHeadDefaultValue; } }
            set
            {
                LookHead_ = value;
            }
        }

        /// <summary>Field number for the "LookBody" field.</summary>
        public const int LookBodyFieldNumber = 2;
        private readonly static uint LookBodyDefaultValue = 0;

        private uint LookBody_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookBody
        {
            get { if (LookBody_ >= 0) { return LookBody_; } else { return LookBodyDefaultValue; } }
            set
            {
                LookBody_ = value;
            }
        }

        /// <summary>Field number for the "LookLegs" field.</summary>
        public const int LookLegsFieldNumber = 3;
        private readonly static uint LookLegsDefaultValue = 0;

        private uint LookLegs_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookLegs
        {
            get { if ((_hasBits0 & 1) != 0) { return LookLegs_; } else { return LookLegsDefaultValue; } }
            set
            {
                _hasBits0 |= 1;
                LookLegs_ = value;
            }
        }

        /// <summary>Gets whether the "LookLegs" field is set</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool HasLookLegs
        {
            get { return (_hasBits0 & 1) != 0; }
        }
        /// <summary>Clears the value of the "LookLegs" field</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearLookLegs()
        {
            _hasBits0 &= ~1;
        }

        /// <summary>Field number for the "LookFeet" field.</summary>
        public const int LookFeetsFieldNumber = 4;
        private readonly static uint LookFeetDefaultValue = 0;

        private uint LookFeet_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public uint LookFeet
        {
            get { if (LookFeet_ >= 0) { return LookFeet_; } else { return LookFeetDefaultValue; } }
            set
            {
                LookFeet_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as StaticDataLookColors);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(StaticDataLookColors other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (LookHead != other.LookHead) return false;
            if (LookBody != other.LookBody) return false;
            if (LookLegs != other.LookLegs) return false;
            if (LookFeet != other.LookFeet) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (LookHead_ >= 0) hash ^= LookHead.GetHashCode();
            if (LookBody_ >= 0) hash ^= LookBody.GetHashCode();
            if (LookLegs_ >= 0) hash ^= LookLegs.GetHashCode();
            if (LookFeet_ >= 0) hash ^= LookFeet.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
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
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
            output.WriteRawTag(8);
            output.WriteUInt32(LookHead);

            output.WriteRawTag(16);
            output.WriteUInt32(LookBody);

            output.WriteRawTag(24);
            output.WriteUInt32(LookLegs);

            output.WriteRawTag(32);
            output.WriteUInt32(LookFeet);

      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            output.WriteRawTag(8);
            output.WriteUInt32(LookHead);

            output.WriteRawTag(16);
            output.WriteUInt32(LookBody);

            output.WriteRawTag(24);
            output.WriteUInt32(LookLegs);

            output.WriteRawTag(32);
            output.WriteUInt32(LookFeet);

            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;

            if (LookHead >= 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookHead);
            }
            if (LookBody >= 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookBody);
            }
            if (LookLegs >= 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookLegs);
            }
            if (LookFeet >= 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LookFeet);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(StaticDataLookColors other)
        {
            if (other == null)
            {
                return;
            }
            if (other.LookHead >= 0)
            {
                LookHead = other.LookHead;
            }
            if (other.LookBody >= 0)
            {
                LookBody = other.LookBody;
            }
            if (other.LookLegs >= 0)
            {
                LookLegs = other.LookLegs;
            }
            if (other.LookFeet >= 0)
            {
                LookFeet = other.LookFeet;
            }
            if (other._unknownFields != null)
                _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          case 8: {
            LookHead = input.ReadUInt32();
            break;
          }
          case 16: {
            LookBody = input.ReadUInt32();
            break;
          }
          case 24: {
            LookLegs = input.ReadUInt32();
            break;
          }
          case 32: {
            LookFeet = input.ReadUInt32();
            break;
          }
          default: {
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
            }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    case 8:
                        {
                            LookHead = input.ReadUInt32();
                            break;
                        }
                    case 16:
                        {
                            LookBody = input.ReadUInt32();
                            break;
                        }
                    case 24:
                        {
                            LookLegs = input.ReadUInt32();
                            break;
                        }
                    case 32:
                        {
                            LookFeet = input.ReadUInt32();
                            break;
                        }
                    default:
                        {
                            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                            break;
                        }
                }
            }
        }
#endif

    }

    #endregion


}
#endregion StaticData by marcosvf132

using ProtoBuf;

namespace YeetReborn;

[ProtoContract]
public class YeetPacket
{
    [ProtoMember(1)]
    public bool WholeStack;
}

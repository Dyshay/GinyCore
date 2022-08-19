using Giny.Core.IO.Interfaces;
using Giny.Core.Network.Messages;
using System;

namespace Giny.Protocol.Messages
{
    public class NetworkDataContainerMessage : NetworkMessage
    {
        public const ushort Id = 2;
        public override ushort MessageId => Id;

        public byte[] content;
        public bool isInitialized = false;

        public NetworkDataContainerMessage()
        {
        }

        public NetworkDataContainerMessage(
            byte[] content,
            bool _isInitialized
        )
        {
            this.content = content;
            this.isInitialized = _isInitialized;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBytes(content);
            writer.WriteBoolean(isInitialized);
        }

        public override void Deserialize(IDataReader reader)
        {
            content = reader.ReadBytes(content.Length);
            isInitialized = reader.ReadBoolean();
        }
    }
}
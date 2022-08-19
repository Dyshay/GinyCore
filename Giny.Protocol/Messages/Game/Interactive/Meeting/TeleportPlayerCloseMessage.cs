using System.Collections.Generic;
using Giny.Core.Network.Messages;
using Giny.Protocol.Types;
using Giny.Core.IO.Interfaces;
using Giny.Protocol;
using Giny.Protocol.Enums;

namespace Giny.Protocol.Messages
{     public class TeleportPlayerCloseMessage : NetworkMessage  
    {         public  const ushort Id = 2332;
        public override ushort MessageId => Id;

        public double mapId;
        public long requesterId;

        public TeleportPlayerCloseMessage()
        {
        }
        public TeleportPlayerCloseMessage(double mapId,long requesterId)
        {
            this.mapId = mapId;
            this.requesterId = requesterId;
        }
        public override void Serialize(IDataWriter writer)
        {
            if (mapId < 0 || mapId > 9.00719925474099E+15)
            {
                throw new System.Exception("Forbidden value (" + mapId + ") on element mapId.");
            }

            writer.WriteDouble((double)mapId);
            if (requesterId < 0 || requesterId > 9.00719925474099E+15)
            {
                throw new System.Exception("Forbidden value (" + requesterId + ") on element requesterId.");
            }

            writer.WriteVarLong((long)requesterId);
        }
        public override void Deserialize(IDataReader reader)
        {
            mapId = (double)reader.ReadDouble();
            if (mapId < 0 || mapId > 9.00719925474099E+15)
            {
                throw new System.Exception("Forbidden value (" + mapId + ") on element of TeleportPlayerCloseMessage.mapId.");
            }

            requesterId = (long)reader.ReadVarUhLong();
            if (requesterId < 0 || requesterId > 9.00719925474099E+15)
            {
                throw new System.Exception("Forbidden value (" + requesterId + ") on element of TeleportPlayerCloseMessage.requesterId.");
            }

        }


    }
}


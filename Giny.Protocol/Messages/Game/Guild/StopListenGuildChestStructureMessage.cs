using System.Collections.Generic;
using Giny.Core.Network.Messages;
using Giny.Protocol.Types;
using Giny.Core.IO.Interfaces;
using Giny.Protocol;
using Giny.Protocol.Enums;

namespace Giny.Protocol.Messages
{     public class StopListenGuildChestStructureMessage : NetworkMessage  
    {         public  const ushort Id = 5498;
        public override ushort MessageId => Id;


        public StopListenGuildChestStructureMessage()
        {
        }
        public override void Serialize(IDataWriter writer)
        {
        }
        public override void Deserialize(IDataReader reader)
        {
        }


    }
}



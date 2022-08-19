﻿using Giny.Core.Network.Messages;
using Giny.Protocol.Enums;
using Giny.Protocol.Messages;
using Giny.World.Managers.Bidshops;
using Giny.World.Managers.Exchanges;
using Giny.World.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giny.World.Handlers.Roleplay.Bidshops
{
    class BidshopsHandler
    {
        [MessageHandler]
        public static void HandleExchangeBidhouseTypes(ExchangeBidHouseTypeMessage message, WorldClient client)
        {
            if (client.Character.IsInDialog<BuyExchange>())
            {
                client.Character.GetDialog<BuyExchange>().ShowTypes((short)message.type);
            }
        }
        [MessageHandler]
        public static void HandleExchangeBidhouseList(ExchangeBidHouseListMessage message, WorldClient client)
        {
            if (client.Character.IsInDialog<BuyExchange>())
            {
                client.Character.GetDialog<BuyExchange>().ShowList((short)message.Id);
            }
        }
        [MessageHandler]
        public static void HandleExchangeBidHouseBuy(ExchangeBidHouseBuyMessage message, WorldClient client)
        {
            if (client.Character.IsInDialog<BuyExchange>())
            {
                client.Character.GetDialog<BuyExchange>().Buy(message.uid, message.qty, message.price);
            }
        }


        [MessageHandler]
        public static void HandleBidHouseSearch(ExchangeBidHouseSearchMessage message, WorldClient client)
        {
            if (client.Character.IsInDialog<BuyExchange>())
            {
                client.Character.GetDialog<BuyExchange>().ShowList((short)message.objectGID);
            }
        }

        [MessageHandler]
        public static void HandleExchangeBidHousePrice(ExchangeBidHousePriceMessage message, WorldClient client)
        {
            long price = BidshopsManager.Instance.GetAveragePrice((short)message.objectGID);

            client.Send(new ObjectAveragePricesMessage(new short[] { message.objectGID }, new long[] { price }));
        }

        [MessageHandler]
        public static void HandleObjectAveragePricesGetMessage(ObjectAveragePricesGetMessage message, WorldClient client)
        {
            var objectPrices = BidshopsManager.Instance.GetAveragePrices();

            client.Send(new ObjectAveragePricesMessage(objectPrices.Keys.ToArray(), objectPrices.Values.ToArray()));
        }
    }
}

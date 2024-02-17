using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Classes.Packets;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    public class SearchableItem
    {
        public string Id;
        public Dictionary<string, SearchedState> States;
        public GridInfo[] Grids;
    }

    public static partial class Serializer
    {
        public static void Deserialize(IReaderStream stream, out SearchableItem item)
        {
            item = null;
            stream.Serialize(ref item);
        }

        public static void Serialize(this ISerializer2 stream, ref SearchableItem @object)
        {
            bool flag = @object == null;
            stream.Serialize(ref flag);
            if (flag)
            {
                return;
            }
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                @object = new SearchableItem();
            }
            stream.SerializeLimitedString(ref @object.Id, ' ', 'z', BitPackingTag.SearchableItemInfoId, new uint?(1200U));
            int num = 0;
            if (@object.States != null)
            {
                num = @object.States.Count;
            }
            stream.Serialize(ref num);
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                @object.States = new Dictionary<string, SearchedState>(num);
            }
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                for (int i = 0; i < num; i++)
                {
                    string key = null;
                    stream.SerializeLimitedString(ref key, ' ', 'z', BitPackingTag.SearchedStateKey, new uint?(1200U));
                    SearchedState value = SearchedState.Unsearched;
                    stream.Serialize<SearchedState>(ref value);
                    @object.States.Add(key, value);
                }
            }
            else
            {
                foreach (KeyValuePair<string, SearchedState> keyValuePair in @object.States)
                {
                    string key2 = keyValuePair.Key;
                    stream.SerializeLimitedString(ref key2, ' ', 'z', BitPackingTag.SearchedStateKey, new uint?(1200U));
                    SearchedState value2 = keyValuePair.Value;
                    stream.Serialize<SearchedState>(ref value2);
                }
            }
            int num2 = 0;
            if (@object.Grids != null)
            {
                num2 = @object.Grids.Length;
            }
            stream.Serialize(ref num2);
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                @object.Grids = new GridInfo[num2];
            }
            for (int j = 0; j < num2; j++)
            {
                GridInfo gridInfo = null;
                if (stream.StreamMode == EBitStreamMode.Writing)
                {
                    gridInfo = @object.Grids[j];
                }
                stream.Serialize(ref gridInfo);
                if (stream.StreamMode == EBitStreamMode.Reading)
                {
                    @object.Grids[j] = gridInfo;
                }
            }
        }

    }
}

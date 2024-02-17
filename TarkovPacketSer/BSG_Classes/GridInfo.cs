using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    public class GridInfo
    {
        public string Id;
        public Dictionary<string, List<string>> KnownItems;
    }
    public static partial class Serializer
    {
        public static void Serialize(this ISerializer2 stream, ref GridInfo @object)
        {
            bool flag = @object == null;
            stream.Serialize(ref flag);
            if (flag)
            {
                return;
            }
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                @object = new GridInfo();
            }
            stream.SerializeLimitedString(ref @object.Id, ' ', 'z', BitPackingTag.SearchableGridInfoId, new uint?(1200U));
            int num = 0;
            if (@object.KnownItems != null)
            {
                num = @object.KnownItems.Count;
            }
            stream.Serialize(ref num);
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                @object.KnownItems = new Dictionary<string, List<string>>(num);
            }
            if (stream.StreamMode == EBitStreamMode.Reading)
            {
                for (int i = 0; i < num; i++)
                {
                    string key = null;
                    stream.SerializeLimitedString(ref key, ' ', 'z', BitPackingTag.KnownItemsDictKey, new uint?(1200U));
                    List<string> list = null;
                    int num2 = 0;
                    stream.Serialize(ref num2);
                    if (stream.StreamMode == EBitStreamMode.Reading)
                    {
                        list = new List<string>(num2);
                    }
                    for (int j = 0; j < num2; j++)
                    {
                        string item = null;
                        if (stream.StreamMode == EBitStreamMode.Writing)
                        {
                            item = list[j];
                        }
                        stream.SerializeLimitedString(ref item, ' ', 'z', BitPackingTag.KnownItemsArrayString, new uint?(1200U));
                        if (stream.StreamMode == EBitStreamMode.Reading)
                        {
                            list.Add(item);
                        }
                    }
                    @object.KnownItems.Add(key, list);
                }
                return;
            }
            foreach (KeyValuePair<string, List<string>> keyValuePair in @object.KnownItems)
            {
                string key2 = keyValuePair.Key;
                stream.SerializeLimitedString(ref key2, ' ', 'z', BitPackingTag.KnownItemsDictKey, new uint?(1200U));
                List<string> list2 = keyValuePair.Value;
                int num3 = 0;
                if (list2 != null)
                {
                    num3 = list2.Count;
                }
                stream.Serialize(ref num3);
                if (stream.StreamMode == EBitStreamMode.Reading)
                {
                    list2 = new List<string>(num3);
                }
                for (int k = 0; k < num3; k++)
                {
                    string item2 = null;
                    if (stream.StreamMode == EBitStreamMode.Writing)
                    {
                        item2 = list2[k];
                    }
                    stream.SerializeLimitedString(ref item2, ' ', 'z', BitPackingTag.KnownItemsDictValue, new uint?(1200U));
                    if (stream.StreamMode == EBitStreamMode.Reading)
                    {
                        list2.Add(item2);
                    }
                }
            }
        }
    }
}
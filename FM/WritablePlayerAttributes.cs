using System.Collections.Generic;

namespace FM
{
    public class WritablePlayerAttributes : PlayerAttributes, IDictionary<PlayerAttribute,int>
    {
        public void Add(KeyValuePair<PlayerAttribute, int> item)
        {
            Attributes.Add(item);
        }

        public void Clear()
        {
            Attributes.Clear();
        }

        public bool Contains(KeyValuePair<PlayerAttribute, int> item)
        {
            return Attributes.Contains(item);
        }

        public void CopyTo(KeyValuePair<PlayerAttribute, int>[] array, int arrayIndex)
        {
            Attributes.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<PlayerAttribute, int> item)
        {
            return Attributes.Remove(item);
        }

        public bool IsReadOnly => Attributes.IsReadOnly;
        public void Add(PlayerAttribute key, int value)
        {
            Attributes.Add(key, value);
        }

        public bool Remove(PlayerAttribute key)
        {
            return Attributes.Remove(key);
        }

        public new int this[PlayerAttribute key]
        {
            get { return Attributes[key]; }
            set { Attributes[key] = value; }
        }

        public new ICollection<PlayerAttribute> Keys => Attributes.Keys;
        public new  ICollection<int> Values => Attributes.Values;
    }
}
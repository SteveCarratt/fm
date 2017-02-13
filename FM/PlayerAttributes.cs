using System;
using System.Collections;
using System.Collections.Generic;

namespace FM
{
    public class PlayerAttributes : IReadOnlyDictionary<PlayerAttribute, int>
    {
        protected readonly IDictionary<PlayerAttribute,int> Attributes = new Dictionary<PlayerAttribute, int>();

        protected PlayerAttributes()
        {
            
        }

        public void Display()
        {
            foreach (var attribute in Attributes)
            {
                Console.WriteLine($"{attribute.Key} - {attribute.Value}");
            }
        }

        public IEnumerator<KeyValuePair<PlayerAttribute, int>> GetEnumerator()
        {
            return Attributes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(PlayerAttribute key)
        {
            return Attributes.ContainsKey(key);
        }

        public bool TryGetValue(PlayerAttribute key, out int value)
        {
            return Attributes.TryGetValue(key, out value);
        }

        public int this[PlayerAttribute key] => Attributes[key];
        public int Count => Attributes.Count;

        public IEnumerable<PlayerAttribute> Keys => Attributes.Keys;
        public IEnumerable<int> Values => Attributes.Values;
    }
}
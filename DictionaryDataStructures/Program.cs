namespace DictionaryDataStructures;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
    }
}

class MyDictionary<Tkey, Tvalue>
{
    private LinkedList<KeyValuePair<Tkey, Tvalue>>[] buckets;
    private int Count = 0;
    private int Size = 10;
    public int GetIndex(Tkey key)
    {
       return Math.Abs(key.GetHashCode()) % Size;
    }

    public void Add(Tkey key, Tvalue value)
    {
        int index = GetIndex(key);
        if (buckets[index] == null)
        {
            buckets[index] = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
        }

        foreach (var dictionary in buckets[index])
        {
            if (dictionary.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists!"); 
            }
        }
        
        buckets[index].AddLast(new KeyValuePair<Tkey,Tvalue>(key, value));

        Count++;
    }

    public bool ContainsKey(Tkey key)
    {
        int index = GetIndex(key);
        if (buckets[index] != null)
            return false;
        foreach (var dictionary in buckets[index])
        {
            if (dictionary.Key.Equals(key))
                return true;
        }
    return false;
    }

    public bool Remove(Tkey key)
    {
        int index = GetIndex(key);
        if (buckets[index] != null) return false;
        LinkedListNode<KeyValuePair<Tkey, Tvalue>> node = buckets[index].First;
        while (node != null)
        {
            if (node.Value.Key.Equals(key))
            {
                buckets[index].Remove(node);
                Count--;
                return true;
            }

            node = node.Next;
        }
        return false;
    }
    
}


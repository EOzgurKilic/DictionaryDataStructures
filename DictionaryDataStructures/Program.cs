using System.Drawing;
using System.Text;

namespace DictionaryDataStructures;

class Program
{
    static void Main(string[] args)
    {
        //IsAnagram
        /*string str1 = "car";
        string str2 = "rat";
        Console.WriteLine(IsAnagram(str1, str2));*/

        //TwoSum
        /*int[] arr = new int[3] { 3, 3, 3 };
        var pair = TwoSum(arr, 6);
        Console.WriteLine(pair[0] + " " +pair[1]);*/


        //LongestCommonPrefix
        /*string[] strs = {"abc", "abcd", "abcde", "abcdef"};
        string pref = LongestCommonPrefix(strs);*/


        /*LinkedList<int> list1 = new LinkedList<int>();
        list1.AddFirst(4);
        list1.AddFirst(3);
        list1.AddFirst(2);
        list1.AddFirst(1);

        LinkedList<int> list2 = new LinkedList<int>();
        LinkedListNode<int> node1 = list1.First;

        while (node1 != null)
        {
            list2.AddFirst(node1.Value);
            node1 = node1.Next;
        }

        foreach (var VARIABLE in list2)
            Console.WriteLine(VARIABLE);*/


        //MyHashMap
        MyHashMap myHashMap = new MyHashMap();
        myHashMap.Put(1, 1);
        myHashMap.Put(2, 2);
        Console.WriteLine(myHashMap.Get(1));
        myHashMap.Get(3);
        myHashMap.Put(2, 1);
        myHashMap.Put(3, 1);
        myHashMap.Put(4, 1);
        myHashMap.Put(5, 1);
        myHashMap.Put(6, 1);
        myHashMap.Put(7, 1);
        myHashMap.Get(2);
        myHashMap.Remove(2);
        myHashMap.Get(2);

        int[] arr1 = new int[10000], _bucket = new int[16], _temp = new int[16];

    arr1[1] = 5;
        _temp = (int[])_bucket.Clone();
        _bucket = new int[2*_bucket.Length];
        _temp.CopyTo(_bucket,0);
        Console.WriteLine(2*_bucket.Length);


    }
    public static bool IsAnagram(string s, string t) //https://leetcode.com/problems/valid-anagram/
    {
        if (s.Length != t.Length)
            return false;
        
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (var str in s)
            if (!dict.ContainsKey(str))
                dict.Add(str, 1);
            else
                dict[str]++;
        
        foreach (char k in t)
            if (!dict.ContainsKey(k) || --dict[k] < 0)
                return false;
    
        return true;
    }
    public static int[] TwoSum(int[] nums, int target) //https://leetcode.com/problems/two-sum/
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(nums[0], 0);
        for (int i = 1; i < nums.Length; i++)
        {
            if (dict.ContainsKey(target - nums[i]))
            {
                return new int[2] {dict[target - nums[i]],i};
            }
            dict[nums[i]] = i;
        }
        return new int[0];
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

public class MyHashMap //https://leetcode.com/problems/design-hashmap/
{
    int[] _bucket, _temp;

    public MyHashMap() {
        _bucket = new int[16];
    }
    
    public void Put(int key, int value) {
        if(key >= _bucket.Length)
            Resize(key);

        _bucket[key] = value + 1;
    }
    
    public int Get(int key)
    {
        if (key >= _bucket.Length)
            return - 1;
        return _bucket[key] - 1;
    }
    
    public void Remove(int key) {
        if (key >= _bucket.Length)
            return;
        _bucket[key] = 0;
    }

    public void Resize(int key)
    {
        if (key < _bucket.Length*2)
            Resize(key);
        _temp = (int[])_bucket.Clone();
        _bucket = new int[2*_bucket.Length];
        _temp.CopyTo(_bucket,0);
    }
}




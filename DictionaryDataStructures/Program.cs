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
        string[] strs = {"abc", "abcd", "abcde", "abcdef"};
        string pref = LongestCommonPrefix(strs);

    }
    public static bool IsAnagram(string s, string t) //https://leetcode.com/problems/valid-anagram/
    {
        if (s.Length != t.Length)
            return false;
        
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (var str in s)
        {
            if (!dict.ContainsKey(str))
                dict.Add(str, 1);
            else
                dict[str]++;
        }

        foreach (var str in t)
        {
            if (!dict.ContainsKey(str))
                return false;
            else if (--dict[str] < 0)
                return false;
        }

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
    
    public static string LongestCommonPrefix(string[] strs) //https://leetcode.com/problems/longest-common-prefix/
    {
        int shortestIndex = 200, counter = 0;
        StringBuilder sb = new StringBuilder();
        sb.Append("");
        for (int i = 1 ; i < strs.Length; i++)
        {
            shortestIndex = shortestIndex > strs[i].Length ? strs[i].Length : shortestIndex;
        }

        for (int i = 0; i < strs.Length; i++)
        {
            for (int j = 0; j < strs[shortestIndex].Length; j++)
            {
                if (strs[shortestIndex][j]==strs[i][j])
                {
                    sb.Append(strs[shortestIndex][j]);
                }
                else
                {
                    return sb.ToString();
                }
            }
        }

        return "";
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


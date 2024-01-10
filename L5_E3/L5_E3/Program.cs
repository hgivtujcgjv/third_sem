using System.Collections;
using System.ComponentModel.Design;

MyDictionary<int, string> test = new MyDictionary<int, string>();

test.Add(15, "15 й");
test.Add(16, "16 й");
test.Add(14, "14 й");
test.Add(1, "1 й");
Console.WriteLine(test.Counter);
foreach (var i in test) { 
    Console.WriteLine(i);
}
class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    TKey[] key_arr = null;
    TValue[] value_arr = null;
    int counter = 0;
    public MyDictionary()
    {
        key_arr = new TKey[0];
        value_arr = new TValue[0];
    }
    public int Counter
    {
        get { return counter; }
    }
    public void Add(TKey key, TValue value)
    {
        ++counter;
        Array.Resize(ref key_arr, counter);
        Array.Resize(ref value_arr, counter);
        key_arr[counter-1] = key;
        value_arr[counter-1] = value;
    }
    public TValue this[TKey key] {
        get{
            int result_ind = 0;
            for (int i = 0; i < counter; ++i) {
                result_ind++;
                if (key.Equals(key_arr[i])) {
                    return value_arr[result_ind-1];
                }
            }
            throw new NotImplementedException();
        }
    }
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < counter; ++i)
        {
            yield return new KeyValuePair<TKey, TValue>(key_arr[i], value_arr[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
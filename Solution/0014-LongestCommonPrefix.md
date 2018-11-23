## Longest Common Prefix

#### 描述： 
找出一组字符串中的最长共同前缀。

#### 分析： 
例如 abc, abd, ab，它们的最长共同前缀是 ab。

#### 思路： 
学习过的 Trie 刚好能解决这个问题，虽然不会是最优解，但可以练练手。 
Trie：http://blog.csdn.net/cuit/article/details/78495561

先定义好 Trie 树 的数据结构： 
这里用 HashMap（C#中是 Dictionary）存储树的子结点，优点是不用存储多余的空数组元素。 
只实现了一个 Add(string s) 方法，用于添加字符串。

#### 实现：
``` C#
public class Trie
{
    public TrieNode Root;

    public Trie()
    {
        Root = new TrieNode();
    }

    public void Add(string s)
    {
        TrieNode runNode = Root;
        for (int i = 0; i < s.Length; i++)
        {
            var children = runNode.Children;
            char c = s[i];
            TrieNode next = null;
            if (children.TryGetValue(c, out next))
            {
                next = children[c];
            }

            if (next == null)
            {
                children.Add(c, new TrieNode());
            }

            runNode = children[c];
        }

        runNode.IsEnd = true;
    }
}
```

然后依次把字符串数组插入Trie中，然后只要找到子结点的数量等于 1 且还有子结点时，即表示这些字符串还在共同前缀的树枝中，反正即表示有分支了，也即这些字符串不再有共同前缀了。

``` c#
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0)
        {
            return "";
        }
        Trie t = new Trie();
        for (int i = 0; i < strs.Length; i++)
        {
            t.Add(strs[i]);
        }
        StringBuilder sb = new StringBuilder();
        TrieNode runNode = t.Root;
        while (runNode.Children.Count == 1 && !runNode.IsEnd)
        {
            var keys = runNode.Children.Keys;
            foreach (var k in keys)
            {
                sb.Append(k);
                runNode = runNode.Children[k];
            }
        }
        return sb.ToString();
    }
```

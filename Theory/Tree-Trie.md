## Trie 字典树

Trie 来自单词 retrieval，发音为 try（避免与tree混淆），也叫做 **单词查找树**，或 **字典树**。 
Trie 是树结构，除根结点外，每个结点都只会有一个父结点。每个结点都有 R 个子结点， R 是字母表的大小，而且可能含有大量的空结点。

假设有字符串：“she sells sea shells by the sea shore”，可以保存成下面这样，让根结点为空：

![](https://img-blog.csdn.net/20171109223501770?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

我们将每个 字符串 关联的值保存在这个 字符串 的最后一个字母对应的结点中，值为空的结点在符号表中没有对应的 key。

从树中查找字符串时，只需要一层层查找，当到达的最后一个字母指向的结点或者遇到了空结点时，
可能有3种情况：
- 字符串的最后一个字母对应的结点的值非空，则认为命中查找。（shells与she）
- 字符串的最后一个字母对应的结点的值为空，则认为是非命中。（shell）
- 查找结束于一个空结点，也是非命中。（shore）

![](https://img-blog.csdn.net/20171109223708773?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 插入字符串： 
插入前需要进行一次查找，当到达最后一个结点或空时，可能有两种情况：
- 在到达字符串的最后一个字母前就遇到了空结点，这时需要为每个其余字母创建结点并将字符串的值保存在最后一个结点中。
- 在遇到空结点之前就到达了字符串的最后一个字母，这时需要把字符串的值保存在最后一个字母对应的结点中（如果已经有值，则覆盖）。

下图是插入“she sells sea shells by the sea shore”的过程：

![](https://img-blog.csdn.net/20171109224415308?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 基于Trie 的数据结构：
``` Java
public class TrieST<Value> {
    private static int R = 256; // radix
    private Node root; // root of trie

    private static class Node {
        private Object val;
        private Node[] next = new Node[R];
    }

    public Value get(String key) {
        Node x = get(root, key, 0);
        if (x == null) {
            return null;
        }
        return (Value) x.val;
    }

    private Node get(Node x, String key, int d) {
        // Return value associated with key in the subtrie rooted at x.
        if (x == null) {
            return null;
        }
        if (d == key.length()) {
            return x;
        }
        char c = key.charAt(d); // Use dth key char to identify subtrie.
        return get(x.next[c], key, d + 1);
    }

    public void put(String key, Value val) {
        root = put(root, key, val, 0);
    }

    private Node put(Node x, String key, Value val, int d) {
        // Change value associated with key if in subtrie rooted at x.
        if (x == null) {
            x = new Node();
        }
        if (d == key.length()) {
            x.val = val;
            return x;
        }
        char c = key.charAt(d); // Use dth key char to identify subtrie.
        x.next[c] = put(x.next[c], key, val, d + 1);
        return x;
    }
}
```

#### 遍历所有字符串：

因为字符串和值是隐式地保存在 trie 中，所有遍历要麻烦一些。 
遍历时，当访问一个结点时，如果它的值为空（不是最后一个字母），则把它的后续结点放进队列中，然后递归地访问它的后续结点列表。

代码如下：
``` Java
    public List<string> keys() {
        return keysWithPrefix("");
    }

    public List<string> keysWithPrefix(string pre) {
        Queue<string> q = new Queue<string>();
        collect(get(root, pre, 0), pre, q);
        return q;
    }

    private void collect(Node x, string pre, Queue<string> q) {
        if (x == null) {
            return;
        }
        if (x.val != null) {
            q.enqueue(pre);
        }
        for (char c = 0; c < R; c++) {
            collect(x.next[c], pre + c, q);
        }
    }
```

遍历的过程如下图：

![](https://img-blog.csdn.net/20171110000007275?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 前缀匹配

![](https://img-blog.csdn.net/20171110000545095?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 通配符匹配

``` Java
    public List<string> keysThatMatch(string pat) {
        Queue<string> q = new Queue<string>();
        collect(root, "", pat, q);
        return q;
    }

    private void collect(Node x, string pre, Queue<string> pat, Queue<string> q) {
        int d = pre.length();
        if (x == null) {
            return;
        }
        if (d == pat.length() && x.val != null) {
            q.enqueue(pre);
        }
        if (d == pat.length()) {
            return;
        }
        char next = pat[d];
        for (char c = 0; c < R; c++) {
            if (next == '.' || next == c) {
                collect(x.next[c], pre + c, pat, q);
            }
        }
    }
```

#### 最长前缀

找最长前缀时，会记录查找路径上找到的最长字符串的长度:
``` Java
    public String longestPrefixOf(String s) {
        int length = search(root, s, 0, 0);
        return s.substring(0, length);
    }

    private int search(Node x, String s, int d, int length) {
        if (x == null) {
            return length;
        }
        if (x.val != null) {
            length = d;
        }
        if (d == s.length()) {
            return length;
        }
        char c = s.charAt(d);
        return search(x.next[c], s, d + 1, length);
    }
```

如下图：

![](https://img-blog.csdn.net/20171110001718086?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 删除字符串

从 Trie 中删去一个字符串的第一步是：找到字符串所对应的结点，把它的值设置为 null。如果这个结点含有一个非空的链接指向其他子结点，则不需要其他操作。如果它的子结点为空，那就需要从 Trie 中删除这个结点，直到子结点不为空时。

``` Java
public void delete(String key) {
        root = delete(root, key, 0);
    }

    private Node delete(Node x, String key, int d) {
        if (x == null) {
            return null;
        }
        if (d == key.length()) {
            x.val = null;
        } else {
            char c = key.charAt(d);
            x.next[c] = delete(x.next[c], key, d + 1);
        }
        if (x.val != null) {
            return x;
        }
        for (char c = 0; c < R; c++) {
            if (x.next[c] != null) {
                return x;
            }
        }
        return null;
    }
```
如图所示：

![](https://img-blog.csdn.net/20171110002158508?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### C# 实现简单的 Trie 结构(内部用hashmap存储)

``` C#
public class Trie {
    public TrieNode root; 
    public Trie() {
        root = new TrieNode(); 
    }
    public void Add(string s) {
        TrieNode runNode = root; 
        for (int i = 0; i < s.Length; i++) {
            var children = runNode.Children; 
            char c = s[i]; 
            TrieNode next = null; 
            if (children.TryGetValue(c, out next)) {
                next = children[c]; 
            }
            if (next == null) {
                children.Add(c, new TrieNode()); 
            }
            runNode = children[c]; 
        }
        runNode.IsEnd = true; 
    }

}
public class TrieNode {
    public bool IsEnd {get; set; }
    public Dictionary < char, TrieNode > Children {get; set; }

    public TrieNode() {
        Children = new Dictionary < char, TrieNode > (); 
        IsEnd = false; 
    }
}
```


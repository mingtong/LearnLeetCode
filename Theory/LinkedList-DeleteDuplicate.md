## 删除链表中的重复结点

#### 单链表数据结构：
```
 //Definition for singly-linked list.
 public class ListNode 
 {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
```


#### 思路： 
比较简单，遍历结点，如果当前结点与下一结点的值相同，则删除下一结点。 
要注意：

头结点或者头结点的下一结点为空的情况。
第n个结点与第n+1，第n+2个结点都相同的情况，需要将这两个结点都删除

```
public ListNode DeleteDuplicates (ListNode head) 
{
    if (head == null || head.next == null) 
    {
        return head;
    }
    ListNode runNode = head;
    while (runNode != null && runNode.next != null) 
    {
        if (runNode.val == runNode.next.val) 
        {
            runNode.next = runNode.next.next;
        } 
        else 
        {
            //注意这里，为了处理第2种情况，
            //不是每次循环都执行，而仅当当前结点与下个结点值不相同时才继续
            runNode = runNode.next;
        }
    }
    return head;
}
```

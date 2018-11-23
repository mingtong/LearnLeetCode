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

#### 非递归思路：
遍历链表，不断将结点插入新链表的头结点。 
使用3个结点：

first：指向原结点其余结点的头结点
second：指向原结点其余结点的头结点的下一个结点
newHead：指向新链表的头结点

```
public ListNode ReverseList(ListNode head) 
{
    ListNode newHead = null;
    ListNode first = head;
    while(first != null)
    {
        ListNode second = first.next; //暂存下一个结点
        first.next = newHead; //将结点插入新链表的头部
        newHead = first; //将新链表的头部指向首结点（新的头部）
        first = second; //指向下一个结点，用于遍历
    }        
    return newHead;
}
```

#### 递归思路： 
先颠倒第 n-1 个结点，然后将原链表的首结点插入到新链表的末尾。
```
public ListNode reverse(ListNode head)
{
    //递归的退出条件
    if(head == null || head.next == null;)
    {
        return head;
    }
    ListNode second = head.next; //暂存下一个结点
    Node rest = reverse(second); //新链表
    second.next = head; //
    head.next = null;
    return rest;
}
```

## Reverse Linked List
Easy

#### 描述： 
Reverse a singly linked list.

Example:
```
Input: 1->2->3->4->5->NULL
Output: 5->4->3->2->1->NULL
```

#### 思路：

先拿出第一个结点当头结点，然后依次把后面（新的）结点插入头结点。

#### 迭代实现代码：
``` kotlin
/**
 * Example:
 * var li = ListNode(5)
 * var v = li.`val`
 * Definition for singly-linked list.
 * class ListNode(var `val`: Int) {
 *     var next: ListNode? = null
 * }
 */
class Solution {
    fun reverseList(head: ListNode?): ListNode? {
        var newHead:ListNode? = null;
        var run:ListNode? = head;
        while(run != null){
            var next = run.next;
            run.next = newHead;
            newHead = run;
            run = next;
        }
        
        return newHead;
    }
}
```

#### 总结：

- 



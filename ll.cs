public ListNode DeleteDuplicates (ListNode head) {
    if (head == null || head.next == null) {
        return head;
    }
    ListNode runNode = head;
    while (runNode != null && runNode.next != null) {
        if (runNode.val == runNode.next.val) {
            runNode.next = runNode.next.next;
        } else {
            //注意这里，为了处理第2种情况，
            //不是每次循环都执行，而仅当当前结点与下个结点值不相同时才继续
            runNode = runNode.next;
        }
    }
    return head;
}
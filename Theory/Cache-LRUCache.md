### LRU-Cache

LRU == Least Recently Used. 
LRU 的内部继承于 LinkedHashMap。LRUCache 将元素按照访问的先后顺序保存在一条双向链接中，并保存指向开头和结尾的指针。将元素作为key，元素在链接中的位置作为value 保存起来。

LRU 的两种操作：
- Get：将它从链表中删除，并插入链表的头部。
- Delete：将它从尾部删除。

Android 中的 LRUCache 实现源码。[Android LRU-Cache](http://grepcode.com/file/repo1.maven.org/maven2/com.google.android/support-v4/r7/android/support/v4/util/LruCache.java#LruCache)

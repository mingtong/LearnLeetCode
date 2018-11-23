### 归并排序
这是一个典型的分治型算法，合并排序的思路是这样的： 
将两个有序的数组归并成一个更大的有序数组。 
先递归地将数组分成两半分别排序，再将结果合并起来。

递归的实现（自上至下）

```
public void sort(int[] a, int low, int high)
{
    if(high <= low)
    {
        return;
    }
    int mid = low + (high -low)/2;
    sort(a, low, mid); //将左半边排序
    sort(a, mid+1, high); //将右半边排序
    merge(a, low, mid, high); //合并两边
}
```

非递归实现（自下向上）

```
public sort(int[] a)
{
    //进行lgN次合并
    //s 是子数组的大小
    for(int s = 1; s < a.Length; s = s+s) 
    {
        //low是子数组索引
        for(int low = 0; low < a.Length - s; low += s)
        {
            merge(a, low, low+s-1, Min(low+s+s-1, a.Length-1) );
        }
    }
}
```

## 二分搜索

#### 查找思路： 
- 在已排序的数组中查找某个元素，不断地从子数组开始查找，注意边界情况。

#### 递归方式：

```
int[] Keys;
public int search(int key, int low, int high)
{
    if(high < low)
    {
        return low;
    }
    int mid = low + (high-low)/2;
    if(key < keys[mid])
    {
        return search(key, low, mid-1);
    }
    else if(key > keys[mid])
    {
        return search(key, mid+1, high);
    }
    else
    {
        return mid;
    }
}
```

#### 迭代方式：

```
int[] Keys;
public int search(int key)
{
    int low = 0;
    high = Keys.Length -1;
    while(low <= high)
    {
        if(key < keys[mid])
        {
            high = mid-1;
        }
        else if(key > keys[mid])
        {
            low = mid+1;
        }
        else
        {
            return mid;
        }   
    }
    return low;
}
```

![](https://algs4.cs.princeton.edu/31elementary/images/rank.png)

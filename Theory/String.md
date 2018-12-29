## String

- string内部用char数组存储。
- ASCII码值: 
  - "0" ~ "9": 48 - 57
  - "A" ~ "Z": 65 ~ 90
  - "a" ~ "z": 97 ~ 122
- char可以直接做 + 或 - 运算:
  ```C#
    a - 32 = 65;
    (char)(a - 32) = A;
  ```
- char[] to string
  ```C#
    string ss = "abcdefg";
    char[] cc = ss.ToCharArray();
  ```
- string to Char[]
  ```C#
    char[] cc = {'a', 'b', 'c'};
    string s = new string(cc);
  ```
- byte <-> string
  ```C#
    byte[] bb = Encoding.UTF8.GetBytes(ss);
    string s = Encoding.UTF8.GetString(bb);
  ```

### Regex

  

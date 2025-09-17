//MyString Replace( MyString str, MyString newstring) - замена всех вхождений строки str
//в исходной строке на строку newstr. Если строки str в объекте нет, то исходная строка не изменяется.
//Возвращается возможно измененный объект

//MyString Replace( String str, String newstring) - замена всех вхождений строки str
//в исходной строке на строку newstr. Если строки newstr в объекте нет, то исходная строка не изменяется
//Возвращается возможно измененный объект

//MyString Replace( char [] str, char[] newstring) - замена всех вхождений символьного массива str
//в исходной строке на символьный массив newstr. Исходная строка не изменяется, если
//символьного массива str в ней нет. Возвращается возможно измененный объект

class MyString
{
    private char[] s;
    private int len;
    
    public MyString()
    {
        len = 0;
        s = new char[1];
        s[0] = '\0';
    }
    
    public MyString(char[] chars)
    {
        len = chars.Length;
        s = new char[len + 1];
        for (int i = 0; i < len; i++)
        {
            s[i] = chars[i];//можно переделать с copyarray
        }
        s[len] = '\0';
    }
    
    public MyString(string str)
    {
        if (str == null || str.Length == 0)
        {
            len = 0;
            s = new char[1];
            s[0] = '\0';
        }
        else
        {
            len = str.Length;
            s = new char[len + 1];
            for (int i = 0; i < len; i++)
            {
                s[i] = str[i];
            }
            s[len] = '\0';
        }
    }
    
    public int Length()
    {
          return len;
    }
    
//возвращает символ позиции index/ если index вне строки, то возвращает терминальный элемент
    public char CharAt(int index)
    {
        if (index >= 0 && index < Length())
            return s[index];
        return '\0';
    }
    
//заменяет символ в исходной строке в позиции index на символ с/ если index вне строки,
//то исходная строка не изменяется
    public MyString SetCharAt(int index, char ch)
    {
        if (index >= 0 && index <= Length())
            s[index] = ch;
        return this;
    }
    
    private static void CopyArray(char[] sourceArray, char[] destinationArray, 
        int sourceIndex, int destinationIndex, int length)
    {
        if (length <= 0) return;
        for (int i = 0; i < length; i++)
            destinationArray[destinationIndex + i] = sourceArray[sourceIndex + i];
    }
    
    public MyString SubString(int start, int end)
    {
        if (start < 0 || end > Length() || end <= start)
            return new MyString(); 
        
        if (end >= Length())
            end = Length() - 1;
                
        int newLen = end - start + 1;
        char[] newChars = new char[newLen];

        CopyArray(s, newChars, start, 0, newLen);
                
        return new MyString(newChars);
    }

//из исходной строки удаляются символы с позиции start до позиции end(не включая end)
    public MyString DelString(int start, int end)
    {
        if (start < 0 || start >= Length() || end > Length() || end <= start)
        {
            return this;
        }
        int deleteLen = end - start + 1;
        CopyArray(s, s, end, start, len - end);
        len -= deleteLen;
        s[len] = '\0';
        return this;
    }
    
    
//добавляет в конец строки символ. возвращается измененный объект.
//исходная строка может быть пустой.
    public MyString Append(char c)
    {
        int newLen = len + 1;
        
        if (newLen + 1 <= s.Length)
        {
            s[len] = c;
            s[newLen] = '\0';
            len = newLen;
        }
        else
        {
            char[] newChars = new char[newLen + 1];
            CopyArray(s, newChars, 0, 0, len);
            newChars[len] = c;
            newChars[len + 1] = '\0';
            s = newChars;
            len = newLen;
        }
        return this;
    }

    //добавляет в конец строки строку str.
    //возвращается измененный объект. исходная строка может быть пустой.
    public MyString Append(MyString str)
    {
        if (str.Length() == 0)
        {
            return this; 
        }
        int newLen = Length() + str.len;
      
        if (newLen + 1 <= s.Length)
        {
            CopyArray(str.s, s, 0, len, str.len);
            s[newLen] = '\0';
            len = newLen;
        }
        
        else
        {
            char[] newChars = new char[newLen + 1];
            CopyArray(s, newChars, 0, 0, len);//копируем исходную строку
            CopyArray(str.s, newChars, 0, len, str.len);//копируем добавляемую строку
            newChars[newLen] = '\0';
            s = newChars;  
            len = newLen;
        }
        return this;
    }
    
    //добавляет в конец строки строку str.
    //возвращается измененный объект. исходная строка может быть пустой.
    public MyString Append(String str)
    {
        return Append(new MyString(str));
    }
    
    //добавляет в конец строки массив символов str.
    //возвращается измененный объект. исходная строка может быть пустой.
    public MyString Append(char[] str)
    {
        return Append(new MyString(str));
    }
    
    //отдельный метод для сдвига чтобы вставить 
    private bool ShiftRight(char[] array, int startIndex, int shiftLength, int elementsToShift)
    {
        if (array == null || 
            startIndex < 0 || 
            startIndex >= array.Length || 
            shiftLength <= 0 || 
            elementsToShift <= 0 || 
            startIndex + elementsToShift + shiftLength > array.Length) 
        {
            return false;
        }
        
        for (int i = elementsToShift-1; i >= 0; i--)
        {
            int sourceIndex = startIndex + i;
            int destIndex = sourceIndex + shiftLength;
            array[destIndex] = array[sourceIndex];
        }
        
        return true;
    }
    
//вставляет в позицию index ту или иную строку( символ бывший в позиции index оказывается после вставленной строки)
    public MyString Insert(int index, MyString str)
    {
        if (str == null || str.Length() == 0 || index < 0 || index > Length())
        {
            return this;
        }
        int newLen = len + str.len;
        if (newLen + 1 <= s.Length)
        {
           bool isShifted = ShiftRight(s, index, str.len, len-index );
           
           if (isShifted)
           {
               CopyArray(str.s, s, 0, index, str.len );
           }
            
            s[newLen] = '\0'; 
            len = newLen;    
        }
   
        else
        {
            char[] newChars = new char[newLen + 1];
            CopyArray(s, newChars, 0, 0, index);
            CopyArray(str.s, newChars, 0, index, str.len);
            CopyArray(s, newChars, index, index + str.len, len - index);
            newChars[newLen] = '\0';
            s = newChars;
            len = newLen;
        }
        return this;
    }
    
    public MyString Insert(int index, String str)
    {
    
        return Insert(index, str == null ? new MyString() : new MyString(str));
    }
    
    public MyString Insert(int index, char[] str)
    {
        return Insert(index, str == null ? new MyString() : new MyString(str));
    }
    
//выводит строку до терминального элемента, а после в скобках реальную длину
    public void Print()
    {
      
       for (int i = 0; i < len; i++)
       {
           Console.Write(s[i]);
       }
       Console.WriteLine($" ({Length()})");
    }
//возвращает истину если строка пустая
    bool Empty()
    {
        return len == 0;
    }
    
    private int CalculateHash(char[] array, int start, int length)
    {
        int hash = 0;
        for (int i = 0; i < length; i++)
        {
            hash += array[start + i];
        }
        return hash;
    }
    
    //метод для сдвига символов влево или вправо
    private bool ShiftRightOrLeft(int startIndex, int delta, int elementsToShift)
    {
        if (s == null || 
            startIndex < 0 || 
            startIndex >= s.Length || 
            elementsToShift < 0 ||
            (delta > 0 && startIndex + elementsToShift + delta > s.Length) || 
            (delta < 0 && startIndex + delta < 0))
        {
            return false;
        }

        if (delta == 0)
            return true; 
        
        if (delta > 0)
        {
            for (int i = elementsToShift - 1; i >= 0; i--)
            {
                s[startIndex + i + delta] = s[startIndex + i];
            }
        }
        else
        {
            for (int i = 0; i < elementsToShift; i++)
            {
                s[startIndex + i + delta] = s[startIndex + i];
            }
        }
        return true;
    }
    
    // замена всех вхождений строки str в исходной строке на строку newstr.
    // если строки str в объекте нет то исходная строка не изменяется возвращается возможно измененный объект
    public MyString Replace(MyString str, MyString newstring)
    {
        if (str == null || str.Length() == 0 || str.Length() > Length())
            return this;
        if (newstring == null)
            newstring = new MyString();
        
        int occurrences = CountOccurances(str);
        if (occurrences == 0)
            return this;

        int newLen = len + (newstring.len - str.len) * occurrences;
        if (newLen < 0)
            newLen = 0;
        
        if (newLen + 1 <= s.Length)
        {
            int delta = newstring.len - str.len;
            int currentIndex = 0;

            while (currentIndex <= Length() - str.len)
            {
                if (IsMatchAt(currentIndex, str))
                {
                    if (delta != 0)
                    {
                        int shiftStart = currentIndex + str.len;
                        int elementsToShift = len - (currentIndex + str.len);
                        ShiftRightOrLeft(shiftStart, delta, elementsToShift);
                        len += delta;
                    }

                    CopyArray(newstring.s, s, 0, currentIndex, newstring.len);
                    currentIndex += newstring.len;
                }
                else
                {
                    currentIndex++;
                }
            }
            s[len] = '\0'; 
            return this;
        }
        else
        {
            char[] newChars = new char[newLen + 1];
            int sourceIndex = 0;
            int destIndex = 0; 

            while (sourceIndex <= len - str.len)
            {
                if (IsMatchAt(sourceIndex, str))
                {
                    CopyArray(newstring.s, newChars, 0, destIndex, newstring.len);
                    destIndex += newstring.len;
                    sourceIndex += str.len; 
                }
                else
                {
                    newChars[destIndex++] = s[sourceIndex++];
                }
            }
            int remaining = len - sourceIndex;
            CopyArray(s, newChars, sourceIndex, destIndex, remaining);
            return new MyString(newChars);
        }
    }

   public MyString Replace(string str, string newstring)
   {
       MyString myStr = (str == null) ? new MyString() : new MyString(str);
       MyString myNewString = (newstring == null) ? new MyString() : new MyString(newstring);
       return Replace(myStr, myNewString);
   }
   
    public MyString Replace(char[] str, char[] newstring)
    {
       
        if (str == null || str.Length == 0)
            return this;
        
        MyString myStr = new MyString(str);
        
        MyString myNewString = (newstring == null) ? new MyString() : new MyString(newstring);
        
        return Replace(myStr, myNewString);
    }
 
    private bool IsMatchAt(int index, MyString str)
    {
        for (int i = 0; i < str.len; i++)
        {
            if (s[index + i] != str.s[i])
            {
                return false;
            }
        }
        return true;
    }
    
//отдельный метод для поиска вхождений и здесь же должен производиться подсчет количества вхождений
       private int CountOccurances(MyString substring)
       {
           if (substring == null || substring.Length() == 0 || substring.Length()> Length())
           {
               return 0;
           }
           int count = 0; 
           int subLen = substring.len; 

           int substringHash = CalculateHash(substring.s, 0, subLen);
           for (int i = 0; i <= len - subLen; i++)
           {
               int currentHash = CalculateHash(s, i, subLen);
               
               if (currentHash == substringHash && IsMatchAt(i, substring))
               {
                   count++;
                   i += subLen - 1;
               }
           }
           return count;
       }
}
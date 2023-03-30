using System;

class StackByArray<T>
{
    private T[] arr;
    private int top;

    public int Count
    {
        get
        {
            return top + 1;
        }
    }
    
    public StackByArray()
    {
        arr = new T[2];
        top = -1;
    }

    public void Push(T data)
    {
        top++;
        if(top >= arr.Length)
        {
            Array.Resize(ref arr, arr.Length * 2);
        }
        arr[top] = data;
    }

    public T Pop()
    {
        if(top < 0)
        {
            throw new IndexOutOfRangeException();
        }
        var ret = arr[top];
        top--;
        return ret;
    }

    public T Peek()
    {
        return arr[top];
    }

    public void Print()
    {
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
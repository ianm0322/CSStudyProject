using System;

class StackByLink<T>
{
    private StackNode<T> top;
    private int count;

    public int Count => count;

    public StackByLink()
    {
        count = 0;
    }

    public void Push(T data)
    {
        count++;
        if(top == null)
        {
            top = new StackNode<T>(data);
        }
        else
        {
            var newNode = new StackNode<T>(data);
            newNode.preNode = top;
            top = newNode;
        }
    }

    public T Pop()
    {
        if (top == null)
            throw new IndexOutOfRangeException();
        else
        {
            count--;
            var ret = top.data;

            top = top.preNode;

            return ret;
        }
    }

    public T Peek()
    {
        if (top == null)
            throw new IndexOutOfRangeException();
        return top.data;
    }

    public void Print()
    {
        T[] ret_arr = new T[count];
        var iter = top;
        while(iter != null)
        {


            iter = iter.preNode;
        }
    }
}

class StackNode<T>
{
    public StackNode<T> preNode;
    public T data;


    public StackNode()
    {
        preNode = null;
        data = default(T);
    }
    public StackNode(T data)
    {
        preNode = null;
        this.data = data;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer 
{
    public int top;
    public CubeManager[] stack;
    public Buffer()
    {
        stack = new CubeManager[48];
        top = -1;
    }

    public void push(CubeManager cur_cubemanager)
    {
        if (top >= 47) return;
        stack[++top] = cur_cubemanager;
    }
    public void Clear()
    {
        top = -1;
    }
    public CubeManager GetTop()
    {
        return stack[top];
    }
    public CubeManager Pop()
    {
        if (top == -1) return null;
        return stack[top--];
    }
}

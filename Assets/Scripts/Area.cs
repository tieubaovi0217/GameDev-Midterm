using System.Collections;
using System.Collections.Generic;

public class Area
{
    public float left;
    public float right;
    public float bottom;
    public float top;
    public Area(float left,  float right, float bottom, float maxY)
    {
        this.left = left;
        this.right = right;
        this.bottom = bottom;
        this.top = maxY;
    }
}

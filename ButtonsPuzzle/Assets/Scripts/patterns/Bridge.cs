using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public abstract class Figure
    {
        public virtual void DrawShape(Line line)
        {

        }
    }
    public abstract class Line
    {

    }
    public class SolidLin : Line
    {

    }
    public class SlimLine : Line
    {

    }
    public class Rect : Figure
    {
        public override void DrawShape(Line line)
        {
            base.DrawShape(line);
        }
        public Rect(int a, int b, int c, int d)
        {

        }
    }
    public void Run()
    {

        Rect rect = new Rect(1,1,1,1);
        SolidLin solidLin = new SolidLin();
        SlimLine slim = new SlimLine();
        rect.DrawShape(solidLin);
        rect.DrawShape(slim);
    }
}

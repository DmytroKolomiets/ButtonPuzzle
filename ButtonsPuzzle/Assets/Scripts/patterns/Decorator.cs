using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decorator : MonoBehaviour
{
    private abstract class Component
    {   
        public abstract void Operation();
    }
    private class Body : Component
    {
        public override void Operation()
        {
            // do stuff
        }
    }
    private class Clouse : Component 
    {
        public Component component{protected get; set;}
        public override void Operation()
        {
            if(component != null)
            component.Operation();
        }
    }
    private class Hoodie : Clouse
    {
        public override void Operation()
        {
            base.Operation();
            // dp stuff
        }
    }
    private class Short : Clouse
    {
        public override void Operation()
        {
            base.Operation();
            // dp stuff
        }
    }
    private void Run()
    {
        Component body = new Body();
        Clouse clouse1 = new Clouse();
        Short clouse2 = new Short();

        clouse1.component = body;
        clouse2.component = clouse1;
        clouse1.Operation();
        
    }
}

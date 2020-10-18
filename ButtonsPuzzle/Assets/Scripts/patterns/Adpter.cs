using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adpter : MonoBehaviour
{
    public class Adaptee
    {
        public void SpecificRequest()
        {

        }
    }
    public interface ITarget
    {
        void Request();
    }
    public class Adapter : ITarget
    {
        private Adaptee adaptee = new Adaptee();
        public void Request()
        {
            adaptee.SpecificRequest(); 
        }
    }
    public class Client
    {
        private ITarget target;
        public Client(ITarget target)
        {
            this.target = target;
        }
        public void Run()
        {
            target.Request();
        }
    }
}

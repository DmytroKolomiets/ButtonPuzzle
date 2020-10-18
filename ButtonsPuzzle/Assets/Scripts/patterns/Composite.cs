using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composite : MonoBehaviour
{
    private abstract class Element
    {
        public abstract void AddElement(Element element);
        public abstract void Operation();
        public abstract void Remove(Element element);
        public abstract Element GetChild(int index);
    }
    private class Branch : Element
    {
        private List<Element> elements = new List<Element>();
        public override void AddElement(Element element)
        {
            elements.Add(element);
        }

        public override Element GetChild(int index)
        {
            return elements[index];
        }

        public override void Operation()
        {
            // do stuff
            foreach (var item in elements)
            {
                item.Operation();
            }
        }

        public override void Remove(Element element)
        {
            elements.Remove(element);
        }
    }
    private class Leaf : Element
    {
        public override void AddElement(Element element)
        {
            throw new System.NotImplementedException();
        }

        public override Element GetChild(int index)
        {
            throw new System.NotImplementedException();
        }

        public override void Operation()
        {
            // do stuff
        }

        public override void Remove(Element element)
        {
            throw new System.NotImplementedException();
        }
    }
    private void Run()
    {
        Branch root = new Branch();
        Branch branch = new Branch();
        Leaf leaf = new Leaf();
        root.AddElement(branch);
        branch.AddElement(leaf);

        branch.Operation();
    }
}

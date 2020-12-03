using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DLL
{

    public class DNode
    {
        public int Value { get; set; }
        public DNode Next { get; set; }
        public DNode Prev { get; set; }

        public DNode(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
        public DNode()
        {
            Next = null;
            Prev = null;
        }
        public DNode(DNode node)
        {
            Next = node.Next;
            Value = node.Value;
            Prev = node.Prev;
        }
    }

 }
    



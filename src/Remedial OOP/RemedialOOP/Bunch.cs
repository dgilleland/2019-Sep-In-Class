using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemedialOOP
{
    public class Node<T>
    {
        public T Thing { get; set; }
        public Node<T> Next { get; set; }
    }
    public class Bunch<T>
    {
        #region Private fields
        private Node<T> _FirstItem;
        private Node<T> _LastItem;
        #endregion

        #region Properties
        public int Count
        {
            get
            {
                int counter = 0;
                var pointer = _FirstItem;
                while(pointer != null)
                {
                    counter++;
                    pointer = pointer.Next;
                }

                return counter;
            }
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            if(_FirstItem == null)
            {
                _FirstItem = new Node<T> { Thing = item };
                _LastItem = _FirstItem;
            }
            else
            {
                _LastItem.Next = new Node<T> { Thing = item };
                _LastItem = _LastItem.Next;
            }
        }
        #endregion
    }
}

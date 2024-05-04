namespace Filas
{
    internal class Queue : OperationalDataStructure
    {
        Node? rear = null;

        public void Enqueue(int item)
        {
            Node node = new Node(item);
            
            if (this.Empty())
            {
                this.top = this.rear = node;
                return;
            }

            this.rear?.SetNext(node);
            this.rear = node;
        }

        public int? Dequeue()
        {
            if (this.top == null)
                return null;

            Node node = this.top;

            this.top = this.top.Next();

            if (this.top == null)
                this.rear = null;

            return node.GetData();
        }

        public Queue Clone()
        {
            Queue queue = new Queue();

            Node? current = this.top;

            while (current != null)
            {
                queue.Enqueue(current.GetData());
                current = current.Next();
            }

            return queue;
        }
    }
}

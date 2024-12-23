namespace Assignment_6_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Assignment 6.3
             * 
             * You are developing a program to manage a call queue of customers 
             * using the Queue in C#. The program creates a queue of callers and 
             * demonstrates the functionality of enqueueing elements into the queue 
             * and iterating over the elements and dequeuing.
             * 
             * Use linked lists.
            */
            Queue queue = new Queue();

            // Enqueue callers
            queue.Enqueue(new Call { CallId = 1, CallerNumber = "Caller 1", CallDateTime = DateTime.Now });
            queue.Enqueue(new Call { CallId = 2, CallerNumber = "Caller 2", CallDateTime = DateTime.Now });
            queue.Enqueue(new Call { CallId = 3, CallerNumber = "Caller 3", CallDateTime = DateTime.Now });

            // Print the queue
            Console.WriteLine("Queue after enqueuing callers:");
            queue.PrintQueue();

            // Dequeue callers
            Console.WriteLine("\nDequeueing caller: " + queue.Dequeue());
            Console.WriteLine("Dequeueing caller: " + queue.Dequeue());

            // Print the queue
            Console.WriteLine("\nQueue after dequeuing callers:");
            queue.PrintQueue();
        }
    }

    public class Call
    {
        public int CallId { get; set; }
        public string CallerNumber { get; set; }
        public DateTime CallDateTime { get; set; }
        public Call Next { get; set; } // Added Next property to support linked list
    }

    public class Queue
    {
        private Call front;
        private Call rear;

        public Queue()
        {
            front = null;
            rear = null;
        }

        // Enqueue operation
        public void Enqueue(Call newCall)
        {
            if (rear == null)
            {
                front = rear = newCall;
            }
            else
            {
                rear.Next = newCall;
                rear = newCall;
            }
        }

        // Dequeue operation
        public Call Dequeue()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty.");
                return null;
            }

            Call dequeuedCall = front;
            front = front.Next;

            if (front == null)
            {
                rear = null;
            }

            return dequeuedCall;
        }

        // Iteration over the queue
        public void PrintQueue()
        {
            Call current = front;

            while (current != null)
            {
                Console.WriteLine($"CallId: {current.CallId}, CallerNumber: {current.CallerNumber}, CallDateTime: {current.CallDateTime}");
                current = current.Next;
            }
        }
    }
}

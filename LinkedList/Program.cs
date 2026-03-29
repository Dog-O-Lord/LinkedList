namespace LinkedList
{
    internal class Program
    {
        public  class DoublyLinkedList
        {
            private Node head; // Голова (начало)
            private Node tail; // Хвост (конец)

            // Добавление в конец (для удобства наполнения списка)
            public void AddLast(int data)
            {
                Node newNode = new Node(data);
                if (head == null) { head = tail = newNode; return; }

                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }

            // 1. Проход в прямом и обратном направлении
            public void PrintForward()
            {
                Node current = head;
                while (current != null) { Console.Write(current.Data + " "); current = current.Next; }
                Console.WriteLine();
            }

            public void PrintBackward()
            {
                Node current = tail;
                while (current != null) { Console.Write(current.Data + " "); current = current.Previous; }
                Console.WriteLine();
            }

            // 2. Поиск элемента
            public Node Find(int value)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == value) return current;
                    current = current.Next;
                }
                return null;
            }

            // 3. Добавление ПОСЛЕ заданного
            public void InsertAfter(Node target, int data)
            {
                if (target == null) return;
                Node newNode = new Node(data);

                newNode.Next = target.Next;
                newNode.Previous = target;

                if (target.Next != null) target.Next.Previous = newNode;
                else tail = newNode; // Если добавляем после последнего

                target.Next = newNode;
            }

            // 4. Удаление элемента
            public void Remove(Node target)
            {
                if (target == null) return;

                if (target.Previous != null) target.Previous.Next = target.Next;
                else head = target.Next; // Если удаляем голову

                if (target.Next != null) target.Next.Previous = target.Previous;
                else tail = target.Previous; // Если удаляем хвост
            }
        }
        public static class Services { 
            public static int Choice { get; set; }
            public static void Output()
            {
                Console.WriteLine("Введите 1 - чтобы вевести список");
                Console.WriteLine("Введите 2 - чтобы произвести поиск");
                Console.WriteLine("Введите 3 - чтобы добавить после эллемента");
                Console.WriteLine("Введите 4 - чтобы удалить эллемент");
                Console.WriteLine("Введите 5 - чтобы закрыть программу");

                int choice = Convert.ToInt32(Console.ReadLine());
                Choice = choice;
            }
            public static void Switch()
            {
                

            }
        }
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(int data)
            {
                Data = data;
            }
        }

        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            Services.Output();
            while (true)
            {


                bool Cycle = true;

                switch (Services.Choice)
                {

                    case 1:
                        do
                        {
                            Console.WriteLine("Введите 1 для прохода с начала до конца или введите 2 для прохода с конца до начала");

                            int choice = Convert.ToInt32(Console.ReadLine());

                            if (choice == 1)
                            {

                                Cycle = false;
                            }

                            if (choice == 2)
                            {

                                Cycle = false;
                            }

                            else Console.WriteLine("Неверное число, попробуйте снова");

                        }
                        while (Cycle == true);
                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали 2");
                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали 3");
                        break;
                    case 4:
                        Console.WriteLine("Вы выбрали 4");
                        break;
                    case 5:
                        Console.WriteLine("Вы выбрали 5");
                        break;
                }
            }
                
        }
    }
}

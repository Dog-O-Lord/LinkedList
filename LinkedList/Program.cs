using System.Collections;

namespace LinkedList
{
    internal class Program
    {
        public  class DoublyLinkedList
        {
            private Node head; 
            private Node tail; 

            public void AddLast(int data)
            {
                Node newNode = new Node(data);
                if (head == null) { head = tail = newNode; }
                else
                {
                    tail.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }

            }

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

            public void InsertAfter(Node target, int data)
            {
                if (target == null) return;
                Node newNode = new Node(data);

                newNode.Next = target.Next;
                newNode.Previous = target;

                if (target.Next != null) target.Next.Previous = newNode;
                else tail = newNode; 

                target.Next = newNode;
            }

            public void Remove(Node target)
            {
                if (target == null) return;

                if (target.Previous != null) target.Previous.Next = target.Next;
                else head = target.Next; 

                if (target.Next != null) target.Next.Previous = target.Previous;
                else tail = target.Previous; 
            }
        }
        public static class Services { 
            
            public static int Output()
            {
                Console.WriteLine("Введите 0 - чтобы заполнить список 5-ю слуйчайными эллементами");
                Console.WriteLine("Введите 1 - чтобы вевести список");
                Console.WriteLine("Введите 2 - чтобы произвести поиск");
                Console.WriteLine("Введите 3 - чтобы добавить после эллемента");
                Console.WriteLine("Введите 4 - чтобы удалить эллемент");
                Console.WriteLine("Введите 5 - чтобы закрыть программу");

                int choice = Convert.ToInt32(Console.Read());
                return choice;
            }
           
        }
        public class Node
        {
            public int Data { get; set; }
            public Node Next;
            public Node Previous; 
            public Node(int data)
            {
                Data = data;
            }
        }

        static void Main(string[] args)
        {

            bool UICycle = true;
            bool Cycle = true;
            DoublyLinkedList list = new DoublyLinkedList();
            int Choice = Services.Output();
            while (UICycle == true)
            {


                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Начинаю генерацию...");
                        Random rng = new Random();
                        for (int i = 0; i < 5; i++)
                        {
                            int num = rng.Next(1, 100);
                            Console.WriteLine($"Добавляю число: {num}");
                            list.AddLast(num);
                            Console.WriteLine("Успешно добавлено.");
                        }
                        Console.WriteLine("Генерация завершена! Нажми ENTER, чтобы вернуться в меню.");
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.WriteLine("Введите 1 для прохода с начала или 2 для прохода с конца");
                        string subChoice = Console.ReadLine(); 

                        if (subChoice == "1")
                        {
                            list.PrintForward();
                        }
                        else if (subChoice == "2")
                        {
                            list.PrintBackward();
                        }
                        else
                        {
                            Console.WriteLine("Неверное число, попробуйте снова");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали 2");
                        Console.WriteLine("/n Введжите число для поиска в диапазоне от 1 д 100");
                        int value = Convert.ToInt32(Console.Read());
                        if ((value >= 1) && (value <= 100))
                        {
                            if (list.Find(value) != null ) Console.WriteLine("Число найдено в списке");
                            else Console.WriteLine("Число не найдено в списке");
                        }
                        else Console.WriteLine("Неверное число, попробуйте снова");
                        break;
                    case 3:
                        Console.WriteLine("Вы выбрали 3");
                        Console.WriteLine("Введите число после которого хотите добавить новый элемент");
                        int targetValue = Convert.ToInt32(Console.Read());
                        list.InsertAfter(list.Find(targetValue), targetValue + 1);
                        Console.WriteLine(list.Find(targetValue).Data + " добавлено после " + targetValue);
                        break;
                    case 4:
                        Console.WriteLine("Вы выбрали 4");
                        Console.WriteLine("Введите число которое хотите удалить");
                        int removeValue = Convert.ToInt32(Console.Read());
                        list.Remove(list.Find(removeValue));
                        break;
                    case 5:
                        Console.WriteLine("Вы выбрали 5");
                        UICycle = false;
                        break;
                }
            }
                
        }
    }
}

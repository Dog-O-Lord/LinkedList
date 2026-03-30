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
                if (head == null)
                {
                    head = tail = newNode;
                }
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
                    if (current.Data == value) 
                    {
                        return current; 
                    }
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

                if (target.Next != null)
                    target.Next.Previous = newNode;
                else
                    tail = newNode; 

                target.Next = newNode;
            }

            public void Remove(int value)
            {
                Node target = Find(value);
                if (target == null) return;

                if (target.Previous != null)
                    target.Previous.Next = target.Next;
                else
                    head = target.Next; // Если удаляем голову

                if (target.Next != null)
                    target.Next.Previous = target.Previous;
                else
                    tail = target.Previous;
            }
        }
        public static class Services { 
            
            public static string Output()
            {
                Console.WriteLine("Введите 0 - чтобы заполнить список 5-ю слуйчайными эллементами");
                Console.WriteLine("Введите 1 - чтобы вевести список");
                Console.WriteLine("Введите 2 - чтобы произвести поиск");
                Console.WriteLine("Введите 3 - чтобы добавить после эллемента");
                Console.WriteLine("Введите 4 - чтобы удалить эллемент");
                Console.WriteLine("Введите 5 - чтобы закрыть программу");

                string choice = Console.ReadLine();
                return choice;
            }
           
        }
        public class Node
        {
            public int Data;
            public Node Next;
            public Node Previous; 
            public Node(int data)
            {
                Data = data;
            }
        }

        static void Main(string[] args)
        {

         
            DoublyLinkedList list = new DoublyLinkedList();
            bool cycle = true;
            while (cycle == true)
            {
                string input = Services.Output();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("\nНачинаю генерацию...");
                        Random rng = new Random();
                        for (int i = 0; i < 5; i++)
                        {
                            int num = rng.Next(1, 100);
                            list.AddLast(num);
                            Console.WriteLine($"Добавлено число: {num}");
                        }
                        Console.WriteLine("Готово! Нажми Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case "1":
                        Console.WriteLine("\nВведите 1 для прохода с начала, 2 - с конца:");
                        string subInput = Console.ReadLine();

                        Console.WriteLine("\n--- Ваш список ---");
                        if (subInput == "1")
                        {
                            list.PrintForward();
                        }
                        else if (subInput == "2")
                        {
                            list.PrintBackward();
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор направления.");
                        }

                        Console.WriteLine("------------------");
                        Console.WriteLine("Нажми Enter для продолжения...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Вы выбрали 2");
                        Console.WriteLine("Введжите число для поиска в диапазоне от 1 д 100");
                        if (int.TryParse(Console.ReadLine(), out int searchNum))
                        {
                            Node foundNode = list.Find(searchNum);

                            if (foundNode != null)
                            {
                                Console.WriteLine($"Успех! Число {searchNum} НАЙДЕНО в списке.");
                            }
                            else
                            {
                                Console.WriteLine("Число не найдено в списке.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: вы ввели не число.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Вы выбрали 3");
                        Console.WriteLine("Введите число после которого хотите добавить новый элемент");
                        if (int.TryParse(Console.ReadLine(), out int targetValue))
                        {
                            Node targetNode = list.Find(targetValue);

                            if (targetNode != null)
                            {
                                Console.Write("Введите значение нового элемента: ");
                                if (int.TryParse(Console.ReadLine(), out int newValue))
                                {
                                    list.InsertAfter(targetNode, newValue);
                                    Console.WriteLine($"Элемент {newValue} успешно добавлен после {targetValue}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка: Число {targetValue} не найдено в списке. Некуда вставлять.");
                            }
                        }

                        Console.WriteLine("Нажми Enter для продолжения...");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Вы выбрали 4");
                        Console.Write("Какое число удалить?: ");
                        if (int.TryParse(Console.ReadLine(), out int delVal))
                        {
                            list.Remove(delVal);
                            Console.WriteLine($"Если число {delVal} было в списке, оно удалено.");
                        }
                        Console.WriteLine("Нажми Enter...");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Вы выбрали 5");
                        cycle = false;
                        break;
                    default:
                        Console.WriteLine("\nНет такого пункта! Нажми Enter и попробуйте снова.");
                        Console.ReadLine(); 
                        break;
                }
            }
        }
                
        }
    }


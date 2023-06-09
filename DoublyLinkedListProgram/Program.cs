namespace DoublyLinkedListProgram
{
	class Node
	{
		public int val;
		public Node? prev;
		public Node? next;

		public Node (int val)
		{
			this.val = val;
			prev = next = null;
		}
	}
	class DoublyLinkedList
	{
		public Node? head;
		public Node? tail;

        public DoublyLinkedList()
        {
			head = null;
			tail = null;
		}

		public void AddToEnd(int val)
		{
			Node node = new Node(val);

			if (head == null)
			{
				head = tail = node;
			}
			else
			{
				tail.next = node;
				node.prev = tail;
				tail = node;
			}
		}

		public void AddToStart(int val)
		{
			Node node = new Node(val);

			if (head == null)
			{
				head = tail = node;
			}
			else
			{
				node.next = head;
				head.prev = node;
				head = node;
			}
		}

		public void AddAfter(int checkVal, int newVal)
		{
			Node node = Find(checkVal);

			if (node == tail)
			{
				AddToEnd(newVal);
			}
			else if (node != null)
			{
				Node curr = head;

				while (curr.next != null)
				{
					if (curr.val == checkVal)
					{
						Node newNode = new Node(newVal);
						Node next = curr.next;
						newNode.next = curr.next;
						next.prev = newNode;
						curr.next = newNode;
						newNode.prev = curr;

						break;
					}

					curr = curr.next;
				}
			}
		}

		public void AddBefore(int checkVal, int newVal)
		{
			Node node = Find(checkVal);

			if (node == head)
			{
				AddToStart(newVal);
			}
			else if (node != null)
			{
				Node newNode = new Node(newVal);
				Node prev = node.prev;
				prev.next = newNode;
				newNode.prev = prev;
				newNode.next = node;
				node.prev = newNode;
			}
		}

		public int RemoveFirst()
		{
			if (head == null)
				throw new Exception("Empty string");

			int result = head.val;
			if (head == tail)
				head = tail = null;
			else
			{
				Node temp = head;
				head = head.next;
				head.prev = null;
				temp.next = null;
			}
			
			return result;
		}

		public int RemoveLast()
		{
			if (tail == null)
				throw new Exception("Empty string!");

			int result = tail.val;

			if (head == tail)
				head = tail = null;
			else
			{
				Node temp = tail;
				tail = tail.prev;
				tail.next = null;
				temp.prev = null;
			}

			return result;
		}

		public void Remove(int val)
		{
			if (Contains(val))
			{
				Node del = Find(val);

				if (del == head)
					RemoveFirst();
				else if (del == tail)
					RemoveLast();
				else
				{
					Node curr = head.next;

					while (curr.next != null)
					{
						if (curr == del)
						{
							Node prev = curr.prev;
							Node next = curr.next;
							prev.next = next;
							curr.next = curr.prev = null;
							break;
						}

						curr = curr.next;
					}
				}
			}
			else
			{
                Console.WriteLine($"Cannot find {val}");
            }
		}

		public bool Contains(int val)
		{
			Node curr = head;

			while(curr != null)
			{
				if (curr.val == val)
					return true;

				curr = curr.next;
			}

			return false;
		}

		public Node Find(int val)
		{
			if (Contains(val))
			{
				Node node = head;

				while (node != null)
				{
					if (node.val == val)
					{
						return node;
					}

					node = node.next;
				}
			}

            Console.WriteLine("No such node");

            return null;
		}

		public void Print()
		{
			Node curr = head;
			while (curr != null)
			{
                Console.Write(curr.val + " ");
				curr = curr.next;
            }
		}

		public void ReversePrint()
		{
			Node curr = tail;
			while (curr != null)
			{
                Console.Write(curr.val + " ");
                curr = curr.prev;
			}
		}

		public void ArrayToLinkedList(int[] arr)
		{
			if (!IsEmpty())
			{
				Clear();
			}

			foreach (int val in arr)
			{
				AddToEnd(val);
			}
		}

		public void Clear()
		{
			if (!IsEmpty())
			{
				while (head != null)
				{
					RemoveFirst();
				}
			}
			else
			{
                Console.WriteLine("List already empty");
            }
		}

		public bool IsEmpty() => head == null;
    }
	internal class Program
	{
		static void Main(string[] args)
		{
			DoublyLinkedList list = new DoublyLinkedList();
			list.AddToEnd(1);
			list.AddToEnd(2);
			list.AddToEnd(3);
			list.AddToEnd(4);
			list.AddBefore(4, 10);
			list.Print();
		}
	}
}
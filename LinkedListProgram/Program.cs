namespace LinkedListProgram
{
	class Node
	{
		public int val;
		public Node? next;

		public Node(int val)
		{
			this.val = val;
			this.next = null;
		}
	}
	class SinglyLinkedList
	{
		private Node? head;
		private Node? tail;
		private int count;

		public Node? Head { get { return head; } }
		public Node? Tail { get { return tail; } }
		public int Count { get { return count; } }

		public SinglyLinkedList()
		{
			head = tail = null;
			count = 0;
		}

		public void AddToEnd(int val)
		{
			Node temp = new Node(val);

			if (tail == null)
			{
				head = tail = temp;
			}
			else
			{
				tail.next = temp;
				tail = temp;
			}

			count++;
		}

		public void AddToStart(int val)
		{
			Node temp = new Node(val);

			if (head == null)
			{
				head = tail = temp;
			}
			else
			{
				temp.next = head;
				head = temp;
			}

			count++;
		}

		public void AddAfter(int newVal, int checkVal)
		{
			if (Contains(checkVal))
			{
				Node node = new Node(newVal);
				Node curr = head;

				while (curr != null)
				{
					if (curr.val == checkVal)
					{
						node.next = curr.next;
						curr.next = node;
						break;
					}

					curr = curr.next;
				}

				count++;
			}
			else
			{
                Console.WriteLine($"{checkVal} does not exist in list");
            }
		}

		public void AddBefore(int newVal, int checkVal)
		{
			if (Contains(checkVal))
			{
				if (head.val == checkVal)
				{
					AddToStart(newVal);
				}
				else
				{
					Node curr = head;
					while(curr.next != null)
					{
						if (curr.next.val == checkVal)
						{
							AddAfter(newVal, curr.val);
							break;
						}

						curr = curr.next;
					}
				}

				count++;
			}
			else
			{
                Console.WriteLine($"{checkVal} does not exits in list");
            }
		}

		public int RemoveFirst()
		{
			if (head == null)
				throw new Exception("Empty list");

			Node temp = head;
			int result = temp.val;
			head = head.next;
			temp.next = null;

			if (head == null)
				tail = null;

			count--;

			return result;
		}

		public int RemoveLast()
		{
			if (tail == null)
			{
				throw new Exception("Empty list");
			}

			int result = tail.val;
			if (head == tail)
			{
				head = tail = null;
			}
			else
			{
				Node temp = head;
				while (temp.next.next != null)
				{
					temp = temp.next;
				}
				tail = temp;
				temp.next = null;
			}

			count--;

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
					Node prev = head;
					Node curr = head.next;
					Node next = curr.next;

					while (curr.next != null)
					{
						if (curr.val == val)
						{
							prev.next = next;
							curr.next = null;
						}
						prev = curr;
						curr = next;
						next = next.next;
					}

					count--;
				}
			}
			else
			{
                Console.WriteLine($"{val} not in list");
            }
		}

		public void RemoveDuplicates()
		{
			Node prev, curr, next;
			curr = head;

			while (curr.next != null)
			{
				next = curr.next;

				if (curr.val == next.val)
				{
					curr.next = next.next;
					next.next = null;
					count--;
				}
				else
				{
					curr = curr.next;
				}
			}
		}

		public bool Contains(int val)
		{
			if (head == null)
				return false;

			Node temp = head;

			while (temp != null)
			{
				if (temp.val == val)
					return true;

				temp = temp.next;
			}

			return false;
		}

		public Node Find(int val)
		{
			if (head == null)
				return null;

			Node temp = head;

			while (temp != null)
			{
				if (temp.val == val)
					return temp;

				temp = temp.next;
			}

			return null;
		}

		public void Clear()
		{
			while (head != null)
			{
				RemoveLast();
			}
		}

		public void ArrayToSinglyLinkedList(int[] arr)
		{
			if (head != null)
			{
				Clear();
			}

			foreach (int number in arr)
			{
				AddToEnd(number);
			}
		}

		public void Print()
		{
			Node temp = head;

			while (temp != null)
			{
				Console.Write(temp.val + " ");
				temp = temp.next;
			}
		}

		public void ReversePrint()
		{
			if (head == null)
				Print();
			else
				ReversePrintHelper(head);
		}

		private void ReversePrintHelper(Node? head)
		{
			if (head.next == null)
			{
                Console.Write(head.val + " ");
            }
			else
			{
				ReversePrintHelper(head.next);
				Console.Write(head.val + " ");
			}

        }

	}
	internal class Program
	{
		static void Main(string[] args)
		{
			SinglyLinkedList list = new SinglyLinkedList();
        }
	}
}
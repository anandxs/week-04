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
		private Node? _head;
		public Node? _tail;
		private int _count;

		public Node? Head { get { return _head; } }
		public int Count { get { return _count; } }

		public SinglyLinkedList()
		{
			_head = _tail = null;
			_count = 0;
		}

		public void AddToEnd(int val)
		{
			Node temp = new Node(val);

			if (_tail == null)
			{
				_head = _tail = temp;
			}
			else
			{
				_tail.next = temp;
				_tail = temp;
			}

			_count++;
		}

		public void AddToStart(int val)
		{
			Node temp = new Node(val);

			if (_head == null)
			{
				_head = _tail = temp;
			}
			else
			{
				temp.next = _head;
				_head = temp;
			}

			_count++;
		}

		public void AddAfter(int newVal, int checkVal)
		{
			if (Contains(checkVal))
			{
				Node node = new Node(newVal);
				Node curr = _head;

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

				_count++;
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
				if (_head.val == checkVal)
				{
					AddToStart(newVal);
				}
				else
				{
					Node curr = _head;
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

				_count++;
			}
			else
			{
                Console.WriteLine($"{checkVal} does not exits in list");
            }
		}

		public int RemoveFirst()
		{
			if (_head == null)
				throw new Exception("Empty list");

			Node temp = _head;
			int result = temp.val;
			_head = _head.next;
			temp.next = null;

			if (_head == null)
				_tail = null;

			_count--;

			return result;
		}

		public int RemoveLast()
		{
			if (_tail == null)
			{
				throw new Exception("Empty list");
			}

			int result = _tail.val;
			if (_head == _tail)
			{
				_head = _tail = null;
			}
			else
			{
				Node temp = _head;
				while (temp.next.next != null)
				{
					temp = temp.next;
				}
				_tail = temp;
				temp.next = null;
			}

			_count--;

			return result;
		}

		public void Remove(int val)
		{
			if (Contains(val))
			{
				Node del = Find(val);

				if (del == _head)
					RemoveFirst();
				else if (del == _tail)
					RemoveLast();
				else
				{
					Node prev = _head;
					Node curr = _head.next;
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

					_count--;
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
			curr = _head;

			while (curr.next != null)
			{
				next = curr.next;

				if (curr.val == next.val)
				{
					curr.next = next.next;
					next.next = null;
					_count--;
				}
				else
				{
					curr = curr.next;
				}
			}
		}

		public bool Contains(int val)
		{
			if (_head == null)
				return false;

			Node temp = _head;

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
			if (_head == null)
				return null;

			Node temp = _head;

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
			while (_head != null)
			{
				RemoveLast();
			}
		}

		public void ArrayToSinglyLinkedList(int[] arr)
		{
			if (_head != null)
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
			Node temp = _head;

			while (temp != null)
			{
				Console.Write(temp.val + " ");
				temp = temp.next;
			}
		}

		public void ReversePrint()
		{
			if (_head == null)
				Print();
			else
				ReversePrintHelper(_head);
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
			list.AddToStart(1);
			list.AddToStart(1);
			list.AddToStart(1);
			list.AddToStart(1);
			list.AddToStart(1);
			Console.WriteLine(list.Count);
			list.RemoveDuplicates();
			Console.WriteLine(list.Count);
        }
	}
}
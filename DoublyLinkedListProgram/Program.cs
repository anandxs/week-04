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
    }
	internal class Program
	{
		static void Main(string[] args)
		{
			DoublyLinkedList list = new DoublyLinkedList();
        }
	}
}
/*var list = new LinkedList();
list.Add(new KeyValuePair("Hello", "olleh"));
list.Add(new KeyValuePair("One", "eno"));
list.Add(new KeyValuePair("Two", "owt"));
Console.WriteLine(list.GetItemWithKey("Hello").Value);
Console.WriteLine(list.GetItemWithKey("One").Value);
Console.WriteLine(list.GetItemWithKey("Two").Value);
Console.WriteLine(list.GetItemWithKey("One").Value);*/

public class KeyValuePair
{
    public string Key { get; }

    public string Value { get; }

    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}

public class LinkedListNode
{
    public KeyValuePair? Pair { get; }
        
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair? pair, LinkedListNode next = null)
    {
        Pair = pair;
        Next = next;
    }
}

public class LinkedList
{
    private LinkedListNode? _first = null;
    private LinkedListNode? _last = null;

    public void Add(KeyValuePair pair)
    {
        // add provided pair to the end of the linked list
        if (_first == null)
        {
            _first = new LinkedListNode(pair);
            _last = new LinkedListNode(pair);
        }
        else
        {
            var node = new LinkedListNode(pair);
            if (_first.Next == null)
            {
                _first.Next = node;
            }
            _last.Next = node;
            _last = node;
        }
    }

    public void RemoveByKey(string key)
    {
        // remove pair with provided key
        var currentNode = _first;
        LinkedListNode? previousNode = null;
        while (currentNode != null)
        {
            if (currentNode.Pair.Key == key)
            {
                previousNode.Next = currentNode.Next;
                break;
            }

            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
    }

    public KeyValuePair? GetItemWithKey(string key)
    {
        // get pair with provided key, return null if not found
        var currentNode = _first;
        while (currentNode != null)
        {
            if (currentNode.Pair.Key == key)
            {
                return currentNode.Pair;
            }

            currentNode = currentNode.Next;
        }

        return null;

    }
}
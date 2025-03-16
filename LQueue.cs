using System;
using System.Collections.Generic;
public class LQueue<T> {
    private List<T> _queue;
    private int _size;
    private int _capacity;
    public LQueue() {
        _queue = new List<T>();
        _size = 0;
    }
    public void Enqueue(T n) {
        _queue.Add(n);
        _size++;
    }
    public T Dequeue() {
        if (_size == 0) {
            throw new InvalidOperationException("Queue is empty");
        }
        T item = _queue[0];
        _queue.RemoveAt(0);
        _size--;
        return item;
    }
    public T Peek() {
        if (_size == 0) {
            throw new InvalidOperationException("Queue is empty");
        }
        return _queue[0];
    }
    public bool Contains(T n) {
        return _queue.Contains(n);
    }
    public void Display() {
        string result =  string.Join(", ", _queue);
        Console.WriteLine(result);
    }
    public int GetSize() {
        return _size;
    }
}
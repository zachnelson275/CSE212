using System;
using System.Collections.Generic;
public class LLQueue<T> {
    private class Node {
        public T data;
        public Node next;

        public Node(T data) {
            this.data = data;
            this.next = null;
        }
    }

    private Node front;
    private Node rear;
    private int size;
    public LLQueue() {
        front = null;
        rear = null;
    }

    public void Enqueue(T value) {
        // Create new node
        Node newNode = new Node(value);
        // If queue is empty, new node is front and rear
        if (rear == null) {
            front = rear = newNode;
            return;
        }
        // Otherwise, add new node to end of the queue, update rear, and increment size
        rear.next = newNode;
        rear = newNode;
        size ++;
    }
    public T Dequeue() {
        // Check if queue is empty
        if (front == null) {
            throw new InvalidOperationException("Queue is empty");
        }
        // Remove front node, update front, and decrement size
        T value = front.data;
        front = front.next;
        if (front == null) { // If queue is now empty, update rear
            rear = null; 
        }
        size --;
        // Return the value of the dequeued node
        return value;
    }
    public T Peek() {
        // Check if queue is empty
        if (front == null) {
            throw new InvalidOperationException("Queue is empty");
        }
        // Otherwise, return the front node
        return front.data;
    }
    public bool Contains(T value) {
        if (front == null) {
            throw new InvalidOperationException("Queue is empty");
        }
        else {
            Node current = front;
            while (current != null) {
                if (current.data.Equals(value)) {
                    return true;
                }
                current = current.next;
            }
        }
        return false;
    }
    public void Display() {
        Node current = front;
        while (current != null) {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }
    public int GetSize() {
        return size;
    }
}
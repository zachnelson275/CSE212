public class AQueue<T> {
    private T[] _queue;
    private int _size;
    private int _capacity;
    private int _front;
    private int _rear;
    public AQueue() {
        var QUEUESIZE = 15;
        T[] _queue = new T[QUEUESIZE];
        _size = 0;
        _capacity = QUEUESIZE;
        _front = 0;
        _rear = 0;
    }
    public void Enqueue(T n) {
        // Check if the next _rear position is _front, which means queue is full
        if ((_rear + 1) % _capacity == _front) {
            throw new InvalidOperationException("Queue is full");
        }
        // Otherwise, add n to back of the queue, advance _rear, and increment _size
        else {
            _queue[_rear] = n;
            _rear = (_rear + 1) % _capacity;
            _size++;
        }
    }
    public T Dequeue() {
        // Check if queue is empty
        if (_front == _rear) {
            throw new InvalidOperationException("Queue is empty");
        }
        // Otherwise, remove front item, advance _front, and decrement _size
        else {
            T item = _queue[_front];
            _queue[_front] = default;
            _front = (_front + 1) % _capacity;
            _size--;
            return item;
        }
    }
    public T Peek() {
        // Check if queue is empty
        if (_front == _rear) {
            throw new InvalidOperationException("Queue is empty");
        }
        // Otherwise, return the item in the front
        else {
            return _queue[_front];
        }
    }
    public bool Containts(T n) {
        // Check if queue is empty
        if (_front == _rear) {
            throw new InvalidOperationException("Queue is empty");
        }
        // Otherwise, iterate through every item in the queue starting with _front. If that item matches our target, return true
        else {
            for (int i = 0; i < _size; i++) {
                int currentIndex = (_front + 1) % _capacity;
                if (_queue[currentIndex].Equals(n)) {
                    return true;
                }
            }
            // If target is not in the queue, return false
            return false;
        }
    }
    public int GetSize() {
        return _size;
    }
}
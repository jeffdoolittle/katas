using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace QueueKata.Tests
{
    public class SimpleStackTests
    {
        [Fact]
        public void first_test()
        {
            var stack = new SimpleStack<Item>();

            stack.Count.Should().Be(0);

            Enumerable
                .Range(0, 10)
                .Select(x => new Item { Index = x })
                .ToList()
                .ForEach(item => stack.Push(item));

            stack.Count.Should().Be(10);

            for (var i = 9; i > -1; i--)
            {
                var current = stack.Pop();
                current.Index.Should().Be(i);
            }

            Action fail = () => stack.Pop();

            fail.Should().Throw<Exception>().Where(_ => _.Message.Contains("empty"));
        }

        public class Item
        {
            public int Index { get; set; }
        }
    }

    public class TwoStackQueueTests
    {
        [Fact]
        public void first_test()
        {
            var queue = new TwoStackQueue<Item>();

            queue.Count.Should().Be(0);

            var items = Enumerable
                .Range(0, 10)
                .Select(x => new Item { Index = x })
                .ToList();

            foreach (var item in items)
            {
                queue.Enqueue(item);
            }

            queue.Count.Should().Be(10);

            var peek = queue.Peek();

            peek.Index.Should().Be(0);

            for (var i = 0; i < 10; i++)
            {
                var current = queue.Dequeue();
                current.Index.Should().Be(i);
            }

            Action fail = () => queue.Dequeue();

            fail.Should().Throw<Exception>().Where(_ => _.Message.Contains("empty"));
        }

        [Fact]
        public void second_test()
        {
            var queue = new TwoStackQueue<Item>();

            queue.Count.Should().Be(0);

            var first = Enumerable
                .Range(0, 5)
                .Select(x => new Item { Index = x })
                .ToList();

            foreach (var item in first)
            {
                queue.Enqueue(item);
            }

            queue.Count.Should().Be(5);

            var firstPeek = queue.Peek();
            firstPeek.Index.Should().Be(0);

            var second = Enumerable
                .Range(5, 5)
                .Select(x => new Item { Index = x })
                .ToList();

            foreach (var item in second)
            {
                queue.Enqueue(item);
            }

            queue.Count.Should().Be(10);

            var peek = queue.Peek();

            peek.Index.Should().Be(0);

            for (var i = 0; i < 10; i++)
            {
                var current = queue.Dequeue();
                current.Index.Should().Be(i);
            }

            Action fail = () => queue.Dequeue();

            fail.Should().Throw<Exception>().Where(_ => _.Message.Contains("empty"));
        }

        public class Item
        {
            public int Index { get; set; }
        }
    }
}

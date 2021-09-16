using Xunit;
using System.Collections.Generic;
using System;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
    
        [Fact]
        public void flatten_given_List_123_456_789_return_123456789()
        {
            var expected = new List<int> {1,2,3,4,5,6,7,8,9};
            var list1 = new List<int>() {1,2,3};
            var list2 = new List<int>() {4,5,6};
            var list3 = new List<int>() {7,8,9};
            var list = new List<List<int>>() {list1, list2, list3};

            var actual = Iterators.Flatten(list);

            Assert.Equal(expected, actual);
            
        }

        [Fact]
        public void filter_given_List_123456789_and_Even_returns_2468()
        {
            Predicate<int> even = Iterators.Even;
            var input = new List<int>() {1,2,3,4,5,6,7,8,9};
            var expected = new List<int>(){2,4,6,8};

            var output = Iterators.Filter(input, even);

            Assert.Equal(expected, output);
        }
    }
}

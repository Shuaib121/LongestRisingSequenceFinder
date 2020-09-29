using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Sam.Coach.Tests
{
    public class UnitTests
    {

        [Theory]
        [InlineData(new [] {4,3,5,8,5,0,0,-3}, new [] {3,5,8})]
        [InlineData(new[] {4,6,-3,3,7,9}, new[] {-3,3,7,9})]
        [InlineData(new[] {9,6,4,5,2,0}, new[] {4,5})]
        [InlineData(new[] {3,10,2,1,20}, new[] {3,10,20})]
        [InlineData(new[] {50,3,10,40,80,7}, new[] {3,10,40,80})]
        [InlineData(new[] {10,22,9,33,21,50,41,60,80}, new[] {10,22,33,50,60,80})]

        // TODO: add more scenarios to ensure finder is working properly
        public async Task Can_Find(IEnumerable<int> data, IEnumerable<int> expected)
        {
            IEnumerable<int> actual = null;

            // TODO: create the finder instance and get the actual result

            await Task.Run(async () =>
            {
                //create a finder instance and check the sequences
                var serviceCollection = Startup.Configure();
                var finder = serviceCollection.BuildServiceProvider().GetService<ILongestRisingSequenceFinder>();

                actual = await finder.Find(data);
            });


            actual.Should().Equal(expected);  
        }
    }
}


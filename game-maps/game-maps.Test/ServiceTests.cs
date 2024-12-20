using game_maps.Application.Interfaces;
using game_maps.Test;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace game_maps.Test.ServiceTest
{
    public class ServiceTest : IClassFixture<TestFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ILocationService? _myService;

        public ServiceTest(TestFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _myService = fixture.ServiceProvider.GetService<ILocationService>();
        }

        [Fact]
        public async Task TestGetAllLocation()
        {
            var result = await _myService!.GetAllLocations("", "the-holy-land", null);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetAllLocationWithUserId()
        {
            var result = await _myService!.GetAllLocations("", "the-holy-land", "fcba5b0a-ba28-4e10-948a-32f2a13358c0");
            Assert.NotNull(result);
            var res2 = result.Any(x => x.Locations.Any(c => c.Checked == true));
            Assert.True(res2);
        }

        [Fact]
        public async Task CheckLocationByUser()
        {
            var result = await _myService!.ToggleLocation(761, "fcba5b0a-ba28-4e10-948a-32f2a13358c0");
            if (result) Assert.True(result);
            else Assert.False(result);
        }

        [Fact]
        public async Task GetLocationCheckedAndCount()
        {
            var locations = await _myService!.GetLocationCount("", ",the-holy-land");
            Assert.Equal(758, locations);
            var checkedCount =
                await _myService!.GetCheckedCount("", "the-holy-land", "fcba5b0a-ba28-4e10-948a-32f2a13358c0");
            Assert.NotEqual(0, checkedCount);
        }

        [Fact]
        public async Task GetLocationsBySearch()
        {
            var result = await _myService!.SearchInLocation("", "the-holy-land", "flag");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGatherAndRunTasks()
        {
            var list = new List<Task>();
            for (var i = 0; i < 10; i++)
            {
                var task = Task.Run(() =>
                {
                    Thread.Sleep(3000);
                    _testOutputHelper.WriteLine($"Task {i} completed");
                });

                list.Add(task);
            }

            var a = list.Count;
            await Task.WhenAll(list);
        }
    }
}
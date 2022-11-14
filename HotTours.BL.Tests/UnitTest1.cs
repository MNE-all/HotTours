using Hot_Tours_BL;
using Hot_Tours_BL.Models; 
namespace HotTours.BL.Tests
{
    public class UnitTest1
    {
        BusinessLogic bl = new BusinessLogic();
        [Fact]
        public void AddTour()
        {
            var item = new Tour                                     
            {
                Guid = Guid.NewGuid(),
                AmountOfDays = 5,
                AmountOfMan = 2,
                Date = DateTime.Now,
                Direction = Direction.Crimea,
                PriceForMan = 990,
                TotalPrice = 2 * 5 * 990 + 2500,
                Surcharge = 2500,
                WiFi = true
            };
            bl.AddTour(item);
            var result = bl.Tours[0];

            result.Should().Be(item);                              
            allitems.Should().HaveCount(1).And.NotBeEmpty();       
        }
    }
}
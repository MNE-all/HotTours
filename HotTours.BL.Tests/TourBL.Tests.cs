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

            Assert.Equal(result, item);      
        }


        [Fact]
        public void DeleteTour()
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
            bl.DeleteTour(item);
            var result = bl.Tours;

            Assert.Empty(result);
        }

        [Fact]
        public void ChangeTour()
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
            var editItem = new Tour
            {
                Guid = item.Guid,
                AmountOfDays = 5,
                AmountOfMan = 2,
                Date = DateTime.Now,
                Direction = Direction.UAE,
                PriceForMan = 1500,
                TotalPrice = 2 * 5 * 1500 + 2500,
                Surcharge = 2500,
                WiFi = true
            };

            bl.AddTour(item);
            bl.EditTour(editItem, 0);
            var result = bl.Tours[0];

            Assert.Equal(result, editItem);
        }
    }
}
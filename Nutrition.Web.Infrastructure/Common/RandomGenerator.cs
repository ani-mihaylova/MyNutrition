namespace Nutrition.Web.Infrastructure.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class RandomGenerator
    {
        private static readonly Random random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            var randomNumber = random.Next(min, max);

            return randomNumber;
        }
    }
}

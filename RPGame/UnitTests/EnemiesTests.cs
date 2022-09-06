using Xunit;
using RPGame;

namespace UnitTests
{
    public class EnemiesTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void DarkElfsHaveTheRightName()
        {
            DarkElf DarkElf = new DarkElf();

            string name = DarkElf._name;

            Assert.Equal("Dark Elf", name);
        }
    }
}

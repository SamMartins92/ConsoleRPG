using Xunit;
using RPGame;

namespace UnitTests
{
    public class BasicTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void FirstWeaponGive10Strenght()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Axe);

            Assert.True(Player.Instance._strength == 10);
        }

      
    }
}
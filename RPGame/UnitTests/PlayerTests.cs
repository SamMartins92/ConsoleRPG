using Xunit;
using RPGame;

namespace UnitTests
{
    public class PlayerTests
    {
        //Pick up weapons

        [Fact]
        public void CanPickUpAxe()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Axe);
            Assert.Equal(Weapon.WeaponType.Axe, Player.Instance.mainWeapon.thisWeaponType);
        }

        [Fact]
        public void CanPickUpSword()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Sword);
            Assert.Equal(Weapon.WeaponType.Sword, Player.Instance.mainWeapon.thisWeaponType);
        }

        [Fact]
        public void CanPickUpBow()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Bow);
            Assert.Equal(Weapon.WeaponType.Bow, Player.Instance.mainWeapon.thisWeaponType);
        }

        [Fact]
        public void CanPickUpDaggers()
        {
            Player.Instance.PickUpWeapon(Weapon.WeaponType.Daggers);
            Assert.Equal(Weapon.WeaponType.Daggers, Player.Instance.mainWeapon.thisWeaponType);
        }

        [Fact]
        public void CanMakeDamage()
        {

        }
    }
}

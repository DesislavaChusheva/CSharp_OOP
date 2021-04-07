using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attackPoints = 10;
    private int durabilityPoints = 10;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attackPoints, durabilityPoints);
        dummy = new Dummy(10, 10);
    }

    [Test]
    public void AxeConstructorWorkingProperly()
    {
        int newAttackPoints = 5;
        int newDurabilityPoints = 5;
        axe = new Axe(newAttackPoints, newDurabilityPoints);

        Assert.That(axe.AttackPoints, Is.EqualTo(newAttackPoints));
        Assert.That(axe.DurabilityPoints, Is.EqualTo(newDurabilityPoints));
    }

    [Test]
    public void WhenAttackedWeapon_ShouldLoosDurability()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durabilityPoints - 1);
    }
    [Test]
    public void WhenAttackWithBrockenWeapon_ShouldThrowException()
    {
        dummy = new Dummy(500, 500);

        Assert.That(() =>
        {
            for (int i = 0; i < durabilityPoints + 1; i++)
            {
                axe.Attack(dummy);
            }
        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }

}
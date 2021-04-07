using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 10;
    private int experience = 10;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void DummyConstructorWorkingProperly()
    {
        int newHealth = 5;
        int newExperience = 5;
        dummy = new Dummy(newHealth, newExperience);

        Assert.AreEqual(dummy.Health, newHealth);
    }
    [Test]

    public void When_DummyIsAttacked_ShouldLooseHealth()
    {
        int attackPoints = 3;
        dummy.TakeAttack(attackPoints);

        Assert.AreEqual(dummy.Health, health - 3);
    }
    [Test]
    public void When_Dead_ShouldReturnFalse()
    {
        dummy = new Dummy(1, experience);
        dummy.TakeAttack(1);

        Assert.AreEqual(dummy.IsDead(), true);
    }
    [Test]
    public void When_DummyIsDead_ShouldGiveExperience()
    {
        dummy = new Dummy(0, experience);

        Assert.AreEqual(dummy.GiveExperience(), experience);
    }
    [Test]
    public void When_DummyIsAlive_ShouldNOTGiveExpersience()
    {
        Assert.That(() => { dummy.GiveExperience(); }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead.") );
    }
    [Test]
    public void When_DeadDummyIsAttacked_ShouldThrowEx()
    {
        dummy = new Dummy(0, experience);
        Assert.That(() => { dummy.TakeAttack(5); }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
}

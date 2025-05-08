using Domain.Base;

namespace BankBlock.Tests.Domain.Base;

file class TestEntity : Entity
{
    public TestEntity() : base() { }
}

public class EntityTests
{
    [Fact]
    public void Constructor_WhenEntityIsCreated_ShouldInitializeId()
    {
        // Arrange & Act
        var entity = new TestEntity();

        // Assert
        Assert.NotEqual(Guid.Empty, entity.Id);
    }

    [Fact]
    public void Constructor_WhenEntityIsCreated_ShouldInitializeCreatedAt()
    {
        // Arrange & Act
        var entity = new TestEntity();
        var umPoucoAntes = DateTime.UtcNow.AddSeconds(-1);
        var umPoucoDepois = DateTime.UtcNow.AddSeconds(1);


        // Assert
        Assert.True(entity.CreatedAt >= umPoucoAntes && entity.CreatedAt <= umPoucoDepois);
    }

    [Fact]
    public void Constructor_WhenEntityIsCreated_ShouldInitializeUpdatedAt()
    {
        // Arrange & Act
        var entity = new TestEntity();
        var umPoucoAntes = DateTime.UtcNow.AddSeconds(-1);
        var umPoucoDepois = DateTime.UtcNow.AddSeconds(1);

        // Assert
        Assert.NotNull(entity.UpdatedAt);
        Assert.True(entity.UpdatedAt.Value >= umPoucoAntes && entity.UpdatedAt.Value <= umPoucoDepois);
    }

    [Fact]
    public void Constructor_WhenEntityIsCreated_UpdatedAtShouldBeCloseToCreatedAt()
    {
        // Arrange & Act
        var entity = new TestEntity();

        // Assert
        Assert.NotNull(entity.UpdatedAt);
        var difference = entity.UpdatedAt.Value - entity.CreatedAt;
        Assert.True(difference.TotalMilliseconds < 100, "UpdatedAt should be very close to CreatedAt upon creation.");
    }
}
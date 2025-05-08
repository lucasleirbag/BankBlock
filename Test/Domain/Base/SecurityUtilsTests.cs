using Domain.Base;

namespace BankBlock.Tests.Domain.Base;

public class SecurityUtilsTests
{
    [Fact]
    public void HashSHA256_GivenKnownString_ReturnsExpectedHash()
    {
        // Arrange
        var input = "HelloWorld";
        var expectedHash = "hy5OUM6ZkNiwQTMMR8nd0Rvsa1A66ThqmdqFhOm7EsQ=";

        // Act
        var actualHash = SecurityUtils.HashSHA256(input);

        // Assert
        Assert.Equal(expectedHash, actualHash);
    }

    [Fact]
    public void HashSHA256_GivenEmptyString_ReturnsCorrectHash()
    {
        // Arrange
        var input = "";
        var expectedHash = "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=";

        // Act
        var actualHash = SecurityUtils.HashSHA256(input);

        // Assert
        Assert.Equal(expectedHash, actualHash);
    }

    [Fact]
    public void HashSHA256_GivenNullString_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => SecurityUtils.HashSHA256(input!));
    }
}
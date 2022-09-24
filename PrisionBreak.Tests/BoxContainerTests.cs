using FluentAssertions;

namespace PrisionBreak.Tests;

public class BoxContainerTests
{
    [Fact]
    public void Scrumble_creates_boxes_accordingly()
    {
        // Arrange
        const int prisioners = 100;

        // Act
        var boxContainer = Enumerable.Range(1, prisioners).ToScrumbled();

        // Assert
        boxContainer.Count.Should().Be(prisioners);
        boxContainer.Should().OnlyHaveUniqueItems();
        boxContainer.Should().OnlyContain(x => x.Identifier >= 1 && x.Identifier <= prisioners);
        boxContainer.Should().OnlyContain(x => x.Number >= 1 && x.Number <= prisioners);
    }

    [Theory]
    [InlineData(100, 3)]
    [InlineData(100, 57)]
    [InlineData(500, 234)]
    [InlineData(1000, 785)]
    public void The_path_leads_to_the_box_with_the_identifier(int prisioners, int boxIdentifier)
    {
        // Arrange
        var boxContainer = Enumerable.Range(1, prisioners).ToScrumbled();

        // Act
        var path = boxContainer.GetPath(boxIdentifier);

        // Assert
        path.Should().NotBeEmpty();
        path.Should().OnlyHaveUniqueItems();
        path[path.Count - 1].Number.Should().Be(boxIdentifier);
    }
}
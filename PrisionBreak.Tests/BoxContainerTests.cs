using FluentAssertions;

namespace PrisionBreak.Tests;

public class BoxContainerTests
{
    [Fact]
    public void Scrumble_creates_boxes_accordingly()
    {
        // Arrange
        const int totalBoxes = 100;
        var playground = new BoxContainer(totalBoxes);

        // Act
        playground.Scramble();

        playground.Count.Should().Be(totalBoxes);
        playground.Should().OnlyHaveUniqueItems();
        playground.Should().OnlyContain(x => x.Identifier >= 1 && x.Identifier <= totalBoxes);
        playground.Should().OnlyContain(x => x.Number >= 1 && x.Number <= totalBoxes);
    }

    [Theory]
    [InlineData(100, 3)]
    [InlineData(100, 57)]
    [InlineData(500, 234)]
    [InlineData(1000, 785)]
    public void The_path_leads_to_the_box_with_the_identifier(int totalBoxes, int boxIdentifier)
    {
        // Arrange
        var playground = new BoxContainer(totalBoxes);
        playground.Scramble();

        // Act
        var path = playground.FindPath(boxIdentifier);

        // Assert
        path.Should().NotBeEmpty();
        path.Should().OnlyHaveUniqueItems();
        path[path.Count - 1].Number.Should().Be(boxIdentifier);
    }
}
using FluentAssertions;

namespace PrisionBreak.Tests;

public class PlaygroundTests
{
    [Fact]
    public void Scrumble_creates_boxes_accordingly()
    {
        // Arrange
        const int totalBoxes = 100;
        var playground = new Playground(totalBoxes);

        // Act
        playground.Scramble();

        playground.Count.Should().Be(totalBoxes);
        playground.Should().OnlyHaveUniqueItems();
        playground.Should().OnlyContain(x => x.Identifier >= 1 && x.Identifier <= totalBoxes);
        playground.Should().OnlyContain(x => x.Number >= 1 && x.Number <= totalBoxes);
    }

    [Fact]
    public void The_path_leads_to_the_box_with_the_identifier()
    {
        // Arrange
        const int totalBoxes = 100;
        const int boxIdentifier = 32;
        var playground = new Playground(totalBoxes);
        playground.Scramble();

        // Act
        var path = playground.FindPath(boxIdentifier);

        // Assert
        path.Should().NotBeEmpty();
        path.Should().OnlyHaveUniqueItems();
        path[path.Count - 1].Number.Should().Be(boxIdentifier);
    }
}
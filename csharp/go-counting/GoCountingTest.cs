// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;
using System;
using System.Collections.Generic;

public class GoCountingTest
{
    [Fact]
    public void Black_corner_territory_on_5x5_board()
    {
        var coordinate = (0, 1);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var actual = sut.Territory(coordinate);
        var expected = (Owner.Black, new[] { (0, 0), (0, 1), (1, 0) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact]
    public void White_center_territory_on_5x5_board()
    {
        var coordinate = (2, 3);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var actual = sut.Territory(coordinate);
        var expected = (Owner.White, new[] { (2, 3) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact]
    public void Open_corner_territory_on_5x5_board()
    {
        var coordinate = (1, 4);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var actual = sut.Territory(coordinate);
        var expected = (Owner.None, new[] { (0, 3), (0, 4), (1, 4) });
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact]
    public void A_stone_and_not_a_territory_on_5x5_board()
    {
        var coordinate = (1, 1);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var actual = sut.Territory(coordinate);
        var expected = (Owner.None, new ValueTuple<int,int>[0]);
        Assert.Equal(expected.Item1, actual.Item1);
        Assert.Equal(expected.Item2, actual.Item2);
    }

    [Fact]
    public void Invalid_because_x_is_too_low_for_5x5_board()
    {
        var coordinate = (-1, 1);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact]
    public void Invalid_because_x_is_too_high_for_5x5_board()
    {
        var coordinate = (5, 1);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact]
    public void Invalid_because_y_is_too_low_for_5x5_board()
    {
        var coordinate = (1, -1);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact]
    public void Invalid_because_y_is_too_high_for_5x5_board()
    {
        var coordinate = (1, 5);
        var board = 
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact]
    public void One_territory_is_the_whole_board()
    {
        var board = " ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, ValueTuple<int,int>[]>
        {
            [Owner.Black] = new ValueTuple<int,int>[0],
            [Owner.White] = new ValueTuple<int,int>[0],
            [Owner.None] = new[] { (0, 0) }
        };
        Assert.Equal(expected.Keys, actual.Keys);
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }

    [Fact]
    public void Two_territory_rectangular_board()
    {
        var board = 
            " BW \n" +
            " BW ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, ValueTuple<int,int>[]>
        {
            [Owner.Black] = new[] { (0, 0), (0, 1) },
            [Owner.White] = new[] { (3, 0), (3, 1) },
            [Owner.None] = new ValueTuple<int,int>[0]
        };
        Assert.Equal(expected.Keys, actual.Keys);
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }

    [Fact]
    public void Two_region_rectangular_board()
    {
        var board = " B ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, ValueTuple<int,int>[]>
        {
            [Owner.Black] = new[] { (0, 0), (2, 0) },
            [Owner.White] = new ValueTuple<int,int>[0],
            [Owner.None] = new ValueTuple<int,int>[0]
        };
        Assert.Equal(expected.Keys, actual.Keys);
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }
}
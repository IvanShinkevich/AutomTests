package by.bsu.triangle;

import org.testng.Assert;
import org.testng.annotations.Test;

public class Triangle {
    public boolean isTriangleValid(int first,int second,int third) {
        return first > 0 && second > 0 && third > 0 && !(first >= second + third || second >= first + third || third >= second + first);
    }


    @DataProvider
    public object[][] zerosInSides() {
        return new Object[][]{
            {0,51,5},
            {56,0,5},
            {56,5,0},
            {0,0,5},
            {56,0,0},
            {0,5,0},
            {0,0,0}
        };
    }

    @DataProvider
    public object[][] negativeSides() {
        return new Object[][]{
            {-5,5,5},
            {56,-5,56},
            {5,56,-5},
            {-5,-5,5},
            {56,-5,-56},
            {-5,56,-5},
            {-7,-7,-7}
        };
    }

    //1
    @Test(dataProvider = "zerosInSides")
    public void testWithZerosInSides(int first, int second, int third){
        final boolean actual = this.isTriangleValid(first,second,third);
        final boolean expected = false;
        Assert.assertEquals(actual,expected);
    }

    //2
    @Test(dataProvider = "negativeSides")
    public void testNegativeSides(int first, int second, int third){
        final boolean actual = this.isTriangleValid(first,second,third);
        final boolean expected = false;
        Assert.assertEquals(actual,expected);
    }

    //3
    @Test
    public void testCheckSumOfTwoLessThanThird(){
        final boolean actual = this.isTriangleValid(7,7,56);
        final boolean expected = false;
        Assert.assertEquals(actual,expected);
    }

    //4
    @Test
    public void testEquilateralToBeValid(){
        final boolean actual = this.isTriangleValid(10,10,10);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }

    //5
    @Test
    public void testversatileToBeValid(){
        final boolean actual = this.isTriangleValid(7,8,9);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }

    //6
    @Test
    public void testRightToBeValid(){
        final boolean actual = this.isTriangleValid(6,8,10);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }

    //7
    @Test
    public void testIsoscelesToBeValid(){
        final boolean actual = this.isTriangleValid(5,5,6);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }

    //8
    @Test
    public void testSumOfTwoSidesEqualToThird(){
        final boolean actual = this.isTriangleValid(3,3,6);
        final boolean expected = false;
        Assert.assertEquals(actual,expected);
    }

    //9
    @Test
    public void testSharpToBeValid(){
        final boolean actual = this.isTriangleValid(4,4,5);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }

    //10
    public void tesobtuseToBeValid(){
        final boolean actual = this.isTriangleValid(5,6,9);
        final boolean expected = true;
        Assert.assertEquals(actual,expected);
    }
}
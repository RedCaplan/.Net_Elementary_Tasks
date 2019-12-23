using System;
using Task3.Models;
using Xunit;


namespace Task3.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void TestTriangleBuildMethod_CreateCorrectTriangle()
        {
            double sideA = 10;
            double sideB = 15;
            double sideC = 20;
            Triangle triangle;
            
            triangle = Triangle.Build(sideA, sideB, sideC);

            Assert.Equal(sideA, triangle.SideA);
            Assert.Equal(sideB, triangle.SideB);
            Assert.Equal(sideC, triangle.SideC);
        }

        [Fact] public void TestTrianglePerimeterCalculateCorrect()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double expectedPerimeter = 12;
            Triangle triangle;

            triangle = Triangle.Build(sideA, sideB, sideC);

            Assert.Equal(expectedPerimeter, triangle.Perimeter);
        }

        [Fact]
        public void TestTriangleAreaCalculateCorrect()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double expectedArea = 6;
            Triangle triangle;

            triangle = Triangle.Build(sideA, sideB, sideC);

            Assert.Equal(expectedArea, triangle.Area);
        }

        [Fact]
        public void TestTriangleCompareCorrect()
        {
            Triangle triangleFirst = Triangle.Build(3,4,5);
            Triangle triangleSecond = Triangle.Build(5, 6, 9);
            int expectedResult = -1;
            int result;

            result = triangleFirst.CompareTo(triangleSecond);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestTriangleBuildMethod_ThrowException_ForNonExistentTriangle()
        {
            double sideA = 10;
            double sideB = 7;
            double sideC = 20;

            Assert.Throws<ArgumentOutOfRangeException>(()=>Triangle.Build(sideA, sideB, sideC));
        }
    }
}

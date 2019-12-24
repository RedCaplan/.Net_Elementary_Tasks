using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Task3.Models;

namespace Task3
{
    public class TriangleController
    {
        private static readonly string[] CONTINUE_KEY = { "y", "yes" };

        private readonly TriangleView _triangleView;
        private readonly List<Triangle> _triangles;

        public TriangleController(TriangleView triangleView)
        {
            _triangleView = triangleView;
            _triangles = new List<Triangle>();
        }

        public TriangleController() : this(new TriangleView())
        {
        }

        public void Run()
        {
            bool isActive = true;
            while (isActive)
            {
                string message = string.Empty;

                try
                {
                    Log.Information("Getting triangle");
                    Triangle triangle = GetInputTriangle();
                    _triangles.Add(triangle);
                    message = "Triangle added";
                }
                catch (FormatException ex)
                {
                    message = ex.Message;
                    Log.Error(ex, "Exception thrown");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    message = ex.Message;
                    Log.Error(ex, "Exception thrown");
                }
                catch (OverflowException ex)
                {
                    message = ex.Message;
                    Log.Error(ex, "Exception thrown");
                }

                _triangleView.Display(message);
                _triangleView.DisplayContinue();

                string userInput = _triangleView.GetInput()?.ToLower();
                isActive = CONTINUE_KEY.Contains(userInput);
            }
            _triangles.Sort();
            _triangleView.DisplayTriangles(_triangles.AsReadOnly());
        }

        private Triangle GetInputTriangle()
        {
            TriangleDTO triangleDTO = _triangleView.RequestTriangle();

            Log.Information("Getted triangle: {name}, {sideA}, {sideB}, {sideC}",
                triangleDTO.Name, triangleDTO.SideA, triangleDTO.SideB, triangleDTO.SideC);

            if (triangleDTO.SideA <= 0)
            {
                throw new ArgumentOutOfRangeException("SideA", "Must be greater than 0");
            }

            if (triangleDTO.SideB <= 0)
            {
                throw new ArgumentOutOfRangeException("SideB", "Must be greater than 0");
            }

            if (triangleDTO.SideC <= 0)
            {
                throw new ArgumentOutOfRangeException("SideC", "Must be greater than 0");
            }

            return Triangle.Build(triangleDTO);
        }

    }
}

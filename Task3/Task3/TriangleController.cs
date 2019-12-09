using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using Task3.Models;

namespace Task3
{
    public class TriangleController
    {
        private const int DEFAULT_COMMANDLINE_ARGS_COUNT = 0;

        private static readonly string[] CONTINUE_KEY = { "y", "yes" };

        private readonly string[] _args;
        private readonly TriangleView _triangleView;
        private readonly List<Triangle> _triangles;

        public TriangleController(TriangleView triangleView, string[] args)
        {
            _args = args ?? new string[] { };
            _triangleView = triangleView;
            _triangles = new List<Triangle>();
        }
        public TriangleController(string[] args = null) : this(new TriangleView(), args)
        {
        }

        public void Run()
        {
            if (_args.Length != DEFAULT_COMMANDLINE_ARGS_COUNT)
            {
                _triangleView.DisplayInstruction();
                return;
            }

            string message = "";
            bool isActive = true;
            while (isActive)
            {
                try
                {
                    Log.Information("Getting triangle");
                    Triangle triangle = GetInputTriangle();
                    _triangles.Add(triangle);
                    message = "Triangle added";
                }
                catch (Exception ex) when (ex is FormatException
                                           || ex is ArgumentOutOfRangeException
                                           || ex is OverflowException)
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
            _triangleView.Triangles = _triangles.ToList();
            _triangleView.DisplayTriangles();
        }

        private Triangle GetInputTriangle()
        {
            TriangleDTO triangleDTO = _triangleView.RequestTriangle();

            Log.Information("Getted triangle: {name}, {sideA}, {sideB}, {sideC}",
                triangleDTO.Name, triangleDTO.Sides.SideA, triangleDTO.Sides.SideB, triangleDTO.Sides.SideC);

            if (triangleDTO.Sides.SideA <= 0)
            {
                throw new ArgumentOutOfRangeException("SideA", "Must be greater than 0");
            }

            if (triangleDTO.Sides.SideB <= 0)
            {
                throw new ArgumentOutOfRangeException("SideB", "Must be greater than 0");
            }

            if (triangleDTO.Sides.SideC <= 0)
            {
                throw new ArgumentOutOfRangeException("SideC", "Must be greater than 0");
            }

            return Triangle.Build(triangleDTO.Sides, triangleDTO.Name);
        }

    }
}

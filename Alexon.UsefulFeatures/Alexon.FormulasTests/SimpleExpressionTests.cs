using NUnit.Framework;
using System.Linq.Expressions;
using FluentAssertions;

namespace Alexon.Formulas.Tests
{
    [TestFixture()]
    public class SimpleExpressionTests
    {
        [Test()]
        public void SimpleExpressionTestWithConstant()
        {
            var speedFormula = new SimpleExpression
            {
                Left = Expression.Parameter(typeof(double), "l"),
                Right = Expression.Parameter(typeof(double), "t"),
                NodeType = ExpressionType.Divide
            };

            var left = speedFormula.TwoParamFunc.Body;
            var right = Expression.Parameter(typeof(double), "t");

            var accelerationFormula = new SimpleExpression
            {
                Left = left,
                Right = Expression.Parameter(typeof(double), "t"),
                NodeType = ExpressionType.Divide
            };

            accelerationFormula.Formula.ToString().Should().Be("((l / t) / t)");
            //var acceleration = accelerationFormula.Calculate(10, 2); // Assuming l=10, t=2

            //acceleration.Should().Be(2.5); // (10 / 2) / 2 = 2.5

        }

        [Test()]
        public void SimpleExpressionTest()
        {
            var speedFormula = new SimpleExpression
            {
                Left = Expression.Parameter(typeof(double), "l"),
                Right = Expression.Parameter(typeof(double), "t"),
                NodeType = ExpressionType.Divide
            };

            var speed = speedFormula.Calculate(10, 2); // Assuming l=10, t=2
            speed.Should().Be(5); // 10 / 2 = 5
        }

        [Test()]
        public void ConvertStringToSimpleExpression()
        {
            var speedFormula = "l / t".ToSimpleExpression();
            speedFormula.Left.Should().BeAssignableTo<ParameterExpression>();
            speedFormula.Left.ToString().Should().Be("l");
            speedFormula.NodeType.Should().Be(ExpressionType.Divide);
            speedFormula.Right.Should().BeAssignableTo<ParameterExpression>();
            speedFormula.Right.ToString().Should().Be("t");

            var speed = speedFormula.Calculate(10, 2); // Assuming l=10, t=2
            speed.Should().Be(5); // 10 / 2 = 5

        }

        [Test()]
        public void ConvertStringToSimpleExpressionWithLeftConstant()
        {
            var speedFormula = "10 / t".ToSimpleExpression();
            speedFormula.Left.Should().BeAssignableTo<ConstantExpression>();
            speedFormula.Left.ToString().Should().Be("10");
            speedFormula.NodeType.Should().Be(ExpressionType.Divide);
            speedFormula.Right.Should().BeAssignableTo<ParameterExpression>();
            speedFormula.Right.ToString().Should().Be("t");
            var speed = speedFormula.Calculate(2); // Assuming t=2
            speed.Should().Be(5); // 10 / 2 = 5
        }

        [Test()]
        public void ConvertStringToSimpleExpressionWithRightConstant()
        {
            var speedFormula = "l / 2".ToSimpleExpression();
            speedFormula.Left.Should().BeAssignableTo<ParameterExpression>();
            speedFormula.Left.ToString().Should().Be("l");
            speedFormula.NodeType.Should().Be(ExpressionType.Divide);
            speedFormula.Right.Should().BeAssignableTo<ConstantExpression>();
            speedFormula.Right.ToString().Should().Be("2");
            var speed = speedFormula.Calculate(10); // Assuming l=10
            speed.Should().Be(5); // 10 / 2 = 5
        }

        [Test()]
        public void AllOperationsTest()
        {
            var divide = "x / 2".ToSimpleExpression();
            divide.OneParamFunc?.ToString().Should().Be("x => (x / 2)");
            divide.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x * 2)");

            var multiply = "x * 2".ToSimpleExpression();
            multiply.OneParamFunc?.ToString().Should().Be("x => (x * 2)");
            multiply.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x / 2)");

            var add = "x + 2".ToSimpleExpression();
            add.OneParamFunc?.ToString().Should().Be("x => (x + 2)");
            add.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x - 2)");

            var subtract = "x - 2".ToSimpleExpression();
            subtract.OneParamFunc?.ToString().Should().Be("x => (x - 2)");
            subtract.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x + 2)");

            var power = "x ^ 2".ToSimpleExpression();
            power.OneParamFunc?.ToString().Should().Be("x => (x ** 2)");
            power.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x ** (1 / 2))");

        }

        [Test()]
        public void DivideTest()
        {
            var divide = "x / 2".ToSimpleExpression();
            divide.OneParamFunc?.ToString().Should().Be("x => (x / 2)");
            divide.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x * 2)");
            var result = divide.Calculate(10.0);
            result.Should().Be(5.0);
            var inverseResult = divide.LeftInversedOneParamFunc?.Compile()(result);
            inverseResult.Should().Be(10.0);
        }

        [Test()]
        public void DivideTest2()
        {
            var divide = "10 / x".ToSimpleExpression();
            divide.OneParamFunc?.ToString().Should().Be("x => (10 / x)");
            divide.LeftInversedOneParamFunc?.ToString().Should().Be("x => (10 * x)");
            divide.RightInversedOneParamFunc?.ToString().Should().Be("x => (10 / x)");
            var result = divide.Calculate(2.0);
            result.Should().Be(5.0);
            var inverseResult = divide.RightInversedOneParamFunc?.Compile()(result);
            inverseResult.Should().Be(2.0);
        }

        [Test] public void DivideTest2Param()
        {             
            var divide = "a / b".ToSimpleExpression();
            divide.TwoParamFunc?.ToString().Should().Be("(a, b) => (a / b)");
            divide.LeftInversedTwoParamFunc?.ToString().Should().Be("(a, b) => (a * b)");
            var result = divide.Calculate(10.0, 2.0);
            result.Should().Be(5.0);
            var inverseResult = divide.LeftInversedTwoParamFunc?.Compile()(result, 2.0);
            inverseResult.Should().Be(10.0);
        }

        [Test()]
        public void PowerTest()
        {
            var power = "x ^ 5".ToSimpleExpression();
            power.OneParamFunc?.ToString().Should().Be("x => (x ** 5)");
            power.LeftInversedOneParamFunc?.ToString().Should().Be("x => (x ** (1 / 5))");

            var powerResult = power.Calculate(2.0);
            powerResult.Should().Be(32.0);

            var roootResult = power.LeftInversedOneParamFunc?.Compile()(powerResult);
            roootResult.Should().Be(2.0);

        }

        [Test()]
        public void PowerTest2Param()
        {
            var power = "a ^ x".ToSimpleExpression();
            power.OneParamFunc?.ToString().Should().Be("x => (a ** x)");
            power.LeftInversedTwoParamFunc?.ToString().Should().Be("(a, x) => (a ** (1 / x))");

            var powerResult = power.Calculate(2.0, 5.0);
            powerResult.Should().Be(32.0);

            var roootResult = power.LeftInversedTwoParamFunc?.Compile()(powerResult, 5.0);
            roootResult.Should().Be(2.0);

        }

        [Test()]
        public void RootTest()
        {
            var expected = 5.0;
            var number = Expression.Constant(expected, typeof(double));
            var power = Expression.Constant(2.0, typeof(double));
            var radicand = Expression.Constant(25.0, typeof(double));

            var powerExpression = Expression.Power(number, power);
            var powerFunc = Expression.Lambda<Func<double>>(powerExpression);
            var powerTesult = powerFunc.Compile().Invoke();
            powerTesult.Should().Be(25);

            Expression rootExpression = SimpleExpression.Root(power, radicand);
            var rootFunc = Expression.Lambda<Func<double>>(rootExpression);
            var rootResult = rootFunc.Compile().Invoke();
            rootResult.Should().Be(expected);

        }

        [Test()]
        public void RevertExpressionTest()
        {
            var binaryExpression = Expression.MakeBinary(ExpressionType.Power,
                 Expression.Parameter(typeof(double), "x"),
                 Expression.Constant(5.0, typeof(double)));

            var revertedExpression = (BinaryExpression)SimpleExpression.RevertExpression(binaryExpression);
            revertedExpression?.ToString().Should().Be("(x ** (1 / 5))");

        }

        [Test()]
        public void GetExpressionPartsTest()
        {
            var expression = "l / t";
            var (left, operand, right) = expression.ParseExpressionParts();
            left.Should().Be("l");
            operand.Should().Be("/");
            right.Should().Be("t");

        }
    }
}
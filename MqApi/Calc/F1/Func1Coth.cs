﻿using MqApi.Calc.Except;
using MqApi.Calc.Func;
using MqApi.Calc.Util;
using MqApi.Util;
namespace MqApi.Calc.F1{
	internal class Func1Coth : Func1{
		internal override double NumEvaluateDouble(double x){
			return 1.0 / Math.Tanh(x);
		}
		internal override Tuple<double, double> NumEvaluateComplexDouble(double re, double im){
			throw new CannotEvaluateComplexDoubleException();
		}
		internal override bool HasComplexArgument => true;
		internal override ReturnType GetValueType(ReturnType returnType){
			return ReturnType.Real;
		}
		internal override TreeNode RealPart(TreeNode re, TreeNode im){
			throw new CannotCalculateRealPartException();
		}
		internal override TreeNode ImaginaryPart(TreeNode re, TreeNode im){
			throw new CannotCalculateImaginaryPartException();
		}
		internal override TreeNode OuterDerivative(TreeNode arg){
			return Minus(Inverse(Square(Sinh(arg))));
		}
		internal override TreeNode IndefiniteIntegral(TreeNode x){
			throw new CannotCalculateIndefiniteIntegralException();
		}
		internal override TreeNode OuterNthDerivative(TreeNode x, TreeNode n){
			throw new CannotCalculateNthDerivativeException();
		}
		internal override TreeNode DomainMin => throw new CannotCalculateDomainException();
		internal override TreeNode DomainMax => throw new CannotCalculateDomainException();
		internal override string ShortName => "coth";
		internal override string Name => "";
		internal override string Description => "";
		internal override DocumentType DescriptionType => DocumentType.PlainText;
		internal override Topic Topic => Topic.Unknown;
	}
}
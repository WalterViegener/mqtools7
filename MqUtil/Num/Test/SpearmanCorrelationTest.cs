namespace MqUtil.Num.Test{
	public class SpearmanCorrelationTest{
		public static double Test(double r, int n){
			double bothtails;
			double lefttail;
			double righttail;
			Test(r, n, out bothtails, out lefttail, out righttail);
			return bothtails;
		}
		public static void Test(double r, int n, out double bothtails, out double lefttail, out double righttail){
			if (n < 5){
				bothtails = 1.0;
				lefttail = 1.0;
				righttail = 1.0;
				return;
			}
			double t;
			double p;
			if (r >= 1){
				t = 1.0E10;
			} else{
				if (r <= -1){
					t = -1.0E10;
				} else{
					t = r * Math.Sqrt((n - 2) / (1 - r * r));
				}
			}
			if (t < 0){
				p = Spearmantail(t, n);
				bothtails = 2 * p;
				lefttail = p;
				righttail = 1 - p;
			} else{
				p = Spearmantail(-t, n);
				bothtails = 2 * p;
				lefttail = 1 - p;
				righttail = p;
			}
		}
		/*************************************************************************
		Tail(S, 5)
		*************************************************************************/
		private static double Spearmantail5(double s){
			double result;
			if (s < 0.000e+00){
				result = StudentsT.Cumulative(3, -s);
				return result;
			}
			if (s >= 3.580e+00){
				result = 8.304e-03;
				return result;
			}
			if (s >= 2.322e+00){
				result = 4.163e-02;
				return result;
			}
			if (s >= 1.704e+00){
				result = 6.641e-02;
				return result;
			}
			if (s >= 1.303e+00){
				result = 1.164e-01;
				return result;
			}
			if (s >= 1.003e+00){
				result = 1.748e-01;
				return result;
			}
			if (s >= 7.584e-01){
				result = 2.249e-01;
				return result;
			}
			if (s >= 5.468e-01){
				result = 2.581e-01;
				return result;
			}
			if (s >= 3.555e-01){
				result = 3.413e-01;
				return result;
			}
			if (s >= 1.759e-01){
				result = 3.911e-01;
				return result;
			}
			if (s >= 1.741e-03){
				result = 4.747e-01;
				return result;
			}
			if (s >= 0.000e+00){
				result = 5.248e-01;
				return result;
			}
			result = 0;
			return result;
		}
		/*************************************************************************
		Tail(S, 6)
		*************************************************************************/
		private static double Spearmantail6(double s){
			double result;
			if (s < 1.001e+00){
				result = StudentsT.Cumulative(4, -s);
				return result;
			}
			if (s >= 5.663e+00){
				result = 1.366e-03;
				return result;
			}
			if (s >= 3.834e+00){
				result = 8.350e-03;
				return result;
			}
			if (s >= 2.968e+00){
				result = 1.668e-02;
				return result;
			}
			if (s >= 2.430e+00){
				result = 2.921e-02;
				return result;
			}
			if (s >= 2.045e+00){
				result = 5.144e-02;
				return result;
			}
			if (s >= 1.747e+00){
				result = 6.797e-02;
				return result;
			}
			if (s >= 1.502e+00){
				result = 8.752e-02;
				return result;
			}
			if (s >= 1.295e+00){
				result = 1.210e-01;
				return result;
			}
			if (s >= 1.113e+00){
				result = 1.487e-01;
				return result;
			}
			if (s >= 1.001e+00){
				result = 1.780e-01;
				return result;
			}
			result = 0;
			return result;
		}
		/*************************************************************************
		Tail(S, 7)
		*************************************************************************/
		private static double Spearmantail7(double s){
			double result;
			if (s < 1.001e+00){
				result = StudentsT.Cumulative(5, -s);
				return result;
			}
			if (s >= 8.159e+00){
				result = 2.081e-04;
				return result;
			}
			if (s >= 5.620e+00){
				result = 1.393e-03;
				return result;
			}
			if (s >= 4.445e+00){
				result = 3.398e-03;
				return result;
			}
			if (s >= 3.728e+00){
				result = 6.187e-03;
				return result;
			}
			if (s >= 3.226e+00){
				result = 1.200e-02;
				return result;
			}
			if (s >= 2.844e+00){
				result = 1.712e-02;
				return result;
			}
			if (s >= 2.539e+00){
				result = 2.408e-02;
				return result;
			}
			if (s >= 2.285e+00){
				result = 3.320e-02;
				return result;
			}
			if (s >= 2.068e+00){
				result = 4.406e-02;
				return result;
			}
			if (s >= 1.879e+00){
				result = 5.478e-02;
				return result;
			}
			if (s >= 1.710e+00){
				result = 6.946e-02;
				return result;
			}
			if (s >= 1.559e+00){
				result = 8.331e-02;
				return result;
			}
			if (s >= 1.420e+00){
				result = 1.001e-01;
				return result;
			}
			if (s >= 1.292e+00){
				result = 1.180e-01;
				return result;
			}
			if (s >= 1.173e+00){
				result = 1.335e-01;
				return result;
			}
			if (s >= 1.062e+00){
				result = 1.513e-01;
				return result;
			}
			if (s >= 1.001e+00){
				result = 1.770e-01;
				return result;
			}
			result = 0;
			return result;
		}
		/*************************************************************************
		Tail(S, 8)
		*************************************************************************/
		private static double Spearmantail8(double s){
			double result;
			if (s < 2.001e+00){
				result = StudentsT.Cumulative(6, -s);
				return result;
			}
			if (s >= 1.103e+01){
				result = 2.194e-05;
				return result;
			}
			if (s >= 7.685e+00){
				result = 2.008e-04;
				return result;
			}
			if (s >= 6.143e+00){
				result = 5.686e-04;
				return result;
			}
			if (s >= 5.213e+00){
				result = 1.138e-03;
				return result;
			}
			if (s >= 4.567e+00){
				result = 2.310e-03;
				return result;
			}
			if (s >= 4.081e+00){
				result = 3.634e-03;
				return result;
			}
			if (s >= 3.697e+00){
				result = 5.369e-03;
				return result;
			}
			if (s >= 3.381e+00){
				result = 7.708e-03;
				return result;
			}
			if (s >= 3.114e+00){
				result = 1.087e-02;
				return result;
			}
			if (s >= 2.884e+00){
				result = 1.397e-02;
				return result;
			}
			if (s >= 2.682e+00){
				result = 1.838e-02;
				return result;
			}
			if (s >= 2.502e+00){
				result = 2.288e-02;
				return result;
			}
			if (s >= 2.340e+00){
				result = 2.883e-02;
				return result;
			}
			if (s >= 2.192e+00){
				result = 3.469e-02;
				return result;
			}
			if (s >= 2.057e+00){
				result = 4.144e-02;
				return result;
			}
			if (s >= 2.001e+00){
				result = 4.804e-02;
				return result;
			}
			result = 0;
			return result;
		}
		/*************************************************************************
		Tail(S, 9)
		*************************************************************************/
		private static double Spearmantail9(double s){
			double result;
			if (s < 2.001e+00){
				result = StudentsT.Cumulative(7, -s);
				return result;
			}
			if (s >= 9.989e+00){
				result = 2.306e-05;
				return result;
			}
			if (s >= 8.069e+00){
				result = 8.167e-05;
				return result;
			}
			if (s >= 6.890e+00){
				result = 1.744e-04;
				return result;
			}
			if (s >= 6.077e+00){
				result = 3.625e-04;
				return result;
			}
			if (s >= 5.469e+00){
				result = 6.450e-04;
				return result;
			}
			if (s >= 4.991e+00){
				result = 1.001e-03;
				return result;
			}
			if (s >= 4.600e+00){
				result = 1.514e-03;
				return result;
			}
			if (s >= 4.272e+00){
				result = 2.213e-03;
				return result;
			}
			if (s >= 3.991e+00){
				result = 2.990e-03;
				return result;
			}
			if (s >= 3.746e+00){
				result = 4.101e-03;
				return result;
			}
			if (s >= 3.530e+00){
				result = 5.355e-03;
				return result;
			}
			if (s >= 3.336e+00){
				result = 6.887e-03;
				return result;
			}
			if (s >= 3.161e+00){
				result = 8.598e-03;
				return result;
			}
			if (s >= 3.002e+00){
				result = 1.065e-02;
				return result;
			}
			if (s >= 2.855e+00){
				result = 1.268e-02;
				return result;
			}
			if (s >= 2.720e+00){
				result = 1.552e-02;
				return result;
			}
			if (s >= 2.595e+00){
				result = 1.836e-02;
				return result;
			}
			if (s >= 2.477e+00){
				result = 2.158e-02;
				return result;
			}
			if (s >= 2.368e+00){
				result = 2.512e-02;
				return result;
			}
			if (s >= 2.264e+00){
				result = 2.942e-02;
				return result;
			}
			if (s >= 2.166e+00){
				result = 3.325e-02;
				return result;
			}
			if (s >= 2.073e+00){
				result = 3.800e-02;
				return result;
			}
			if (s >= 2.001e+00){
				result = 4.285e-02;
				return result;
			}
			result = 0;
			return result;
		}
		/*************************************************************************
		Tail(T,N), accepts T<0
		*************************************************************************/
		private static double Spearmantail(double t, int n){
			if (n == 5){
				return Spearmantail5(-t);
			}
			if (n == 6){
				return Spearmantail6(-t);
			}
			if (n == 7){
				return Spearmantail7(-t);
			}
			if (n == 8){
				return Spearmantail8(-t);
			}
			if (n == 9){
				return Spearmantail9(-t);
			}
			return StudentsT.Cumulative(n - 2, t);
		}
	}
}
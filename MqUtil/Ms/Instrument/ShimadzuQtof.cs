﻿namespace MqUtil.Ms.Instrument{
	public class ShimadzuQtof : QtofInstrument{
		public ShimadzuQtof(int index) : base(index){
		}
		public override string Name => "Shimadzu Q-TOF";
		public override bool UseMs1CentroidsDefault => false;
		public override bool UseMs2CentroidsDefault => false;
		public override double DiaMinMsmsIntensityForQuantDefault => 0;
	}
}
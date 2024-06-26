using System.Diagnostics;
using System.IO;
using System.Linq;
using MqApi.Document;
using MqApi.Drawing;
using MqApi.Generic;
using MqApi.Matrix;
using MqApi.Param;
using MqApi.Util;
using MqUtil;
namespace PluginInterop{
	/// <summary>
	/// Language agnostic MatrixProcessing implementation.
	///
	/// This class serves as a basis for language-specific implementations.
	/// </summary>
	public abstract class MatrixProcessing : InteropBase, IMatrixProcessing{
		public abstract string Name{ get; }
		public abstract string Description{ get; }
		public virtual float DisplayRank => 1;
		public virtual bool IsActive => true;
		public virtual int GetMaxThreads(Parameters parameters) => 1;
		public virtual bool HasButton => false;
		public virtual Bitmap2 DisplayImage => null;
		public virtual string Url => projectUrl;
		public virtual string Heading => "External";
		public virtual string HelpOutput => "";
		public virtual string[] HelpSupplTables => new string[0];
		public virtual int NumSupplTables => 0;
		public virtual string[] HelpDocuments => new string[0];
		public virtual int NumDocuments => 0;
		protected virtual bool AdditionalMatrices => false;
		/// <summary>
		/// Process data with the given parameters and matrix data. Overwrite this function for
		/// full control of the execution process.
		/// </summary>
		public virtual void ProcessData(IMatrixData mdata, Parameters param, ref IMatrixData[] supplTables,
			ref IDocumentData[] documents, ProcessInfo processInfo){
			string remoteExe = param.GetParam<string>(InterpreterLabel).Value;
			if (string.IsNullOrWhiteSpace(remoteExe)){
				processInfo.ErrString = remoteExeNotSpecified;
				return;
			}
			string inFile = Path.GetTempFileName();
			PerseusUtils.WriteMatrixToFile(mdata, inFile, AdditionalMatrices);
			string outFile = Path.GetTempFileName();
			if (!TryGetCodeFile(param, out string codeFile)){
				processInfo.ErrString = $"Code file '{codeFile}' was not found";
				return;
			}
			if (supplTables == null){
				supplTables = Enumerable.Range(0, NumSupplTables).Select(i => (IMatrixData) mdata.CreateNewInstance())
					.ToArray();
			}
			string[] suppFiles = supplTables.Select(i => Path.GetTempFileName()).ToArray();
			string commandLineArguments = GetCommandLineArguments(param);
			string args = $"{codeFile} {commandLineArguments} {inFile} {outFile} {string.Join(" ", suppFiles)}";
			Debug.WriteLine($"executing > {remoteExe} {args}");
			if (Utils.RunProcess(remoteExe, args, processInfo.Status, out string processInfoErrString) != 0){
				processInfo.ErrString = processInfoErrString;
				return;
			}
			mdata.Clear();
			PerseusUtil.ReadMatrixFromFile(mdata, processInfo, outFile, '\t');
			for (int i = 0; i < NumSupplTables; i++){
				PerseusUtil.ReadMatrixFromFile(supplTables[i], processInfo, suppFiles[i], '\t');
			}
		}
		/// <summary>
		/// Create the parameters for the GUI with default of generic 'Code file'
		/// and 'Additional arguments' parameters. Overwrite this function for custom structured parameters.
		/// You might have to additionally override <see cref="GetCommandLineArgument"/> to match
		/// your custom parameters. To pass parameters as XML file you can use <see cref="Utils.WriteParametersToFile"/>.
		/// </summary>
		protected virtual Parameter[] SpecificParameters(IMatrixData data, ref string errString){
			return new Parameter[]{CodeFileParam(), AdditionalArgumentsParam()};
		}
		/// <summary>
		/// Create the parameters for the GUI with default of generic 'Executable', 'Code file' and 'Additional arguments' parameters.
		/// Includes buttons for preview downloads of 'Data' and 'Parameters' for development purposes.
		/// Overwrite <see cref="SpecificParameters"/> to add specific parameter. Overwrite this function for full control.
		/// </summary>
		public virtual Parameters GetParameters(IMatrixData data, ref string errString){
			Parameters parameters = new Parameters();
			Parameter[] specificParameters = SpecificParameters(data, ref errString);
			if (!string.IsNullOrEmpty(errString)){
				return null;
			}
			parameters.AddParameterGroup(specificParameters, "Specific", false);
			Parameter previewButton = Utils.DataPreviewButton(data);
			Parameter parametersPreviewButton = Utils.ParametersPreviewButton(parameters);
			parameters.AddParameterGroup(new[]{ExecutableParam(), previewButton, parametersPreviewButton}, "Generic",
				false);
			return parameters;
		}
	}
}
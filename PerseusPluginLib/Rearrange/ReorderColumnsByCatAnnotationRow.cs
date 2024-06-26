using MqApi.Document;
using MqApi.Drawing;
using MqApi.Generic;
using MqApi.Matrix;
using MqApi.Num;
using MqApi.Param;
namespace PerseusPluginLib.Rearrange{
	public class ReorderColumnsByCatAnnotationRow : IMatrixProcessing{
		public bool HasButton => false;
		public Bitmap2 DisplayImage => null;
		public string HelpOutput => "Same matrix but with columns in the new order implied by a categorical row.";
		public string[] HelpSupplTables => new string[0];
		public int NumSupplTables => 0;
		public string Heading => "Rearrange";
		public string Name => "Reorder columns by categorical annotation row";
		public bool IsActive => true;
		public float DisplayRank => 2.95f;
		public string[] HelpDocuments => new string[0];
		public int NumDocuments => 0;
		public string Url =>
            "https://cox-labs.github.io/coxdocs/reordercolumnsbynumannotationrow.html";
		public string Description =>
			"The order of the columns as they appear in the matrix is changed according to the values in a categorical row." +
			" This can be useful for displaying columns in a specific order in a heat map.";
		public int GetMaxThreads(Parameters parameters){
			return 1;
		}
		public void ProcessData(IMatrixData data, Parameters param, ref IMatrixData[] supplTables,
			ref IDocumentData[] documents, ProcessInfo processInfo){
			if (data.CategoryRowCount == 0){
				processInfo.ErrString = "Data contains no categorical rows";
			}
			int rowInd = param.GetParam<int>("Categorical row").Value;
			string[][] vals = data.GetCategoryRowAt(rowInd);
			string[] v = new string[vals.Length];
			for (int i = 0; i < v.Length; i++){
				v[i] = string.Concat(vals[i]);
			}
			int[] o = v.Order();
			data.ExtractColumns(o);
		}
		public Parameters GetParameters(IMatrixData mdata, ref string errorString){
			return new Parameters(new SingleChoiceParam("Categorical row"){
				Value = 0,
				Values = mdata.CategoryRowNames,
				Help = "Specify here the categorical row according to which the columns will be reordered."
			});
		}
	}
}
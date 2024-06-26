using System.Collections.Generic;
using MqApi.Document;
using MqApi.Drawing;
using MqApi.Generic;
using MqApi.Matrix;
using MqApi.Num;
using MqApi.Param;
using PerseusPluginLib.Utils;
namespace PerseusPluginLib.Rearrange{
	public class ReorderRemoveColumns : IMatrixProcessing{
		public bool HasButton => false;
		public Bitmap2 DisplayImage => null;
		public string HelpOutput => "Same matrix but with columns in the new order.";
		public string[] HelpSupplTables => new string[0];
		public int NumSupplTables => 0;
		public string Heading => "Rearrange";
		public string Name => "Reorder/remove columns";
		public bool IsActive => true;
		public float DisplayRank => 2.8f;
		public string[] HelpDocuments => new string[0];
		public int NumDocuments => 0;
		public string Url
			=> "http://coxdocs.org/doku.php?id=perseus:user:activities:MatrixProcessing:Rearrange:ReorderRemoveColumns";
		public string Description
			=>
				"The order of the columns as they appear in the matrix can be changed. Columns can also be omitted. For example, " +
				"this can be useful for displaying columns in a specific order in a heat map.";
		public int GetMaxThreads(Parameters parameters){
			return 1;
		}
		public void ProcessData(IMatrixData data, Parameters param, ref IMatrixData[] supplTables,
			ref IDocumentData[] documents, ProcessInfo processInfo){
			int[] exColInds = param.GetParam<int[]>("Main columns").Value;
			int[] numColInds = param.GetParam<int[]>("Numerical columns").Value;
			int[] multiNumColInds = param.GetParam<int[]>("Multi-numerical columns").Value;
			int[] catColInds = param.GetParam<int[]>("Categorical columns").Value;
			int[] textColInds = param.GetParam<int[]>("Text columns").Value;
			data.ExtractColumns(exColInds);
			data.NumericColumns = data.NumericColumns.SubList(numColInds);
			data.NumericColumnNames = data.NumericColumnNames.SubList(numColInds);
			data.NumericColumnDescriptions = data.NumericColumnDescriptions.SubList(numColInds);
			data.MultiNumericColumns = data.MultiNumericColumns.SubList(multiNumColInds);
			data.MultiNumericColumnNames = data.MultiNumericColumnNames.SubList(multiNumColInds);
			data.MultiNumericColumnDescriptions = data.MultiNumericColumnDescriptions.SubList(multiNumColInds);
			data.CategoryColumns = PerseusPluginUtils.GetCategoryColumns(data, catColInds);
			data.CategoryColumnNames = data.CategoryColumnNames.SubList(catColInds);
			data.CategoryColumnDescriptions = data.CategoryColumnDescriptions.SubList(catColInds);
			data.StringColumns = data.StringColumns.SubList(textColInds);
			data.StringColumnNames = data.StringColumnNames.SubList(textColInds);
			//      data.ColumnDescriptions = ArrayUtils.SubList(data.ColumnDescriptions, textColInds);
			//  data.ColumnNames = ArrayUtils.SubList(data.ColumnNames, exColInds);
			//       data.StringColumnDescriptions = ArrayUtils.SubList(data.StringColumnDescriptions, textColInds);
		}
		public Parameters GetParameters(IMatrixData mdata, ref string errorString){
			List<string> exCols = mdata.ColumnNames;
			List<string> numCols = mdata.NumericColumnNames;
			List<string> multiNumCols = mdata.MultiNumericColumnNames;
			List<string> catCols = mdata.CategoryColumnNames;
			List<string> textCols = mdata.StringColumnNames;
			return
				new Parameters(new MultiChoiceParam("Main columns"){
					Value = ArrayUtils.ConsecutiveInts(exCols.Count),
					Values = exCols,
					Help = "Specify here the new order in which the main columns should appear."
				}, new MultiChoiceParam("Numerical columns"){
					Value = ArrayUtils.ConsecutiveInts(numCols.Count),
					Values = numCols,
					Help = "Specify here the new order in which the numerical columns should appear."
				}, new MultiChoiceParam("Multi-numerical columns"){
					Value = ArrayUtils.ConsecutiveInts(multiNumCols.Count),
					Values = multiNumCols,
					Help = "Specify here the new order in which the numerical columns should appear."
				}, new MultiChoiceParam("Categorical columns"){
					Value = ArrayUtils.ConsecutiveInts(catCols.Count),
					Values = catCols,
					Help = "Specify here the new order in which the categorical columns should appear."
				}, new MultiChoiceParam("Text columns"){
					Value = ArrayUtils.ConsecutiveInts(textCols.Count),
					Values = textCols,
					Help = "Specify here the new order in which the text columns should appear."
				});
		}
	}
}
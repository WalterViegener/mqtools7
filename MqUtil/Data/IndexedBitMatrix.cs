namespace MqUtil.Data{
	public class IndexedBitMatrix{
		private readonly SortedSet<int>[] data;
		public IndexedBitMatrix(int nrows, int ncols){
			RowCount = nrows;
			ColumnCount = ncols;
			data = new SortedSet<int>[nrows];
		}
		public int RowCount{ get; }
		public int ColumnCount{ get; }
		public void Set(int row, int col, bool val){
			if (data[row] == null){
				data[row] = new SortedSet<int>();
			}
			if (val){
				data[row].Add(col);
			} else{
				data[row].Remove(col);
			}
		}
		public bool Get(int row, int col){
			return data[row] != null && data[row].Contains(col);
		}
	}
}